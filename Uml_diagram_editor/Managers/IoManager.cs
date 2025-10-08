using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent;
using Uml_diagram_editor.DataContent.RelationContent;
using Uml_diagram_editor.DataContent.SavableContent;
using Uml_diagram_editor.Model;
using Uml_diagram_editor.Model.Relations;

namespace Uml_diagram_editor.Managers
{
    public class IoManager
    {
        public IoManager() { }

        private FileInfo? _file;



        public bool SaveContent(Span<Block> blocks, Span<Relation> relations)
        {
            if (_file == null) SaveContentAs(blocks, relations);

            var json = JsonSerializer.Serialize<SavableContent>(GetContent(relations, blocks));
            
            using var str = _file.OpenWrite();
            using var sr = new StreamWriter(str, Encoding.UTF8);
            sr.Write(json);
            return true;
        }
        public bool SaveContentAs(Span<Block> blocks, Span<Relation> relations)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "UMLDiagram| *.umld";
                dialog.DefaultExt = "umld";
                dialog.FileName = "untitled.umld";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _file = new FileInfo(dialog.FileName);
                    return SaveContent(blocks, relations);
                }
                return false;
            }
        }

        public void ExportToPng(Span<Block> blocks, Span<Relation> relations)
        {
            if (blocks.IsEmpty)
            {
                MessageBox.Show("There is no block to export!");
                return;
            }
            var leftTopPoint = blocks[0].Location;
            var rightBottomPoint = blocks[0].Location;
            rightBottomPoint.Offset(blocks[0].Width, blocks[0].Height);

           
            foreach (var block in blocks)
            {
                if(block.Location.X < leftTopPoint.X) leftTopPoint.X = block.Location.X;
                if(block.Location.X + block.Width > rightBottomPoint.X) rightBottomPoint.X = block.Location.X + block.Width;
                if(block.Location.Y < leftTopPoint.Y) leftTopPoint.Y = block.Location.Y;
                if(block.Location.Y + block.Height > rightBottomPoint.Y) rightBottomPoint.Y = block.Location.Y + block.Height;
            }

            var bounds = new Rectangle(leftTopPoint, new Size(rightBottomPoint.X - leftTopPoint.X, rightBottomPoint.Y - leftTopPoint.Y));
            bounds.Inflate(50, 50);//make it little bigger:)


            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                dialog.DefaultExt = "png";
                dialog.FileName = "diagram.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var bitmap = new Bitmap(bounds.Width, bounds.Height);
                    using var g = Graphics.FromImage(bitmap);
                    g.Clear(Palette.Background);
                    g.TranslateTransform(-bounds.X, -bounds.Y);
                    foreach (var block in blocks)
                    {
                        block.IsSelected = false;
                        block.Draw(g, Palette.GridSize);
                    }
                    foreach (var relation in relations)
                    {
                        relation.IsSelected = false;
                        relation.Draw(g, Palette.GridSize);
                    }
                    bitmap.Save(dialog.FileName);
                }
            }
        }

        public SavableContent? OpenContent()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "UMLDiagram| *.umld";
                dialog.DefaultExt = "umld";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var file = new FileInfo(dialog.FileName);
                   
                    using var str = file.OpenRead();
                    using var sr = new StreamReader(str, Encoding.UTF8);
                    var content = JsonSerializer.Deserialize<SavableContent>(sr.ReadToEnd());
                    return content ?? throw new InvalidOperationException("Data deserialization from .umld failed");
                }
            }
            return null;
        }

        public Content ProcessContent(SavableContent sContent)
        {
            var content = new Content();
            sContent.Blocks.ForEach(b =>
            {
                content.Blocks.Add(new(b.Name, b.Point)
                {
                    IsAbstract = true,
                    IsStatic = true,
                    Methods = b.Methods,
                    Properties = b.Properties,
                    Stereotype = b.Stereotype,
                    BlockIdentity = b.Identity
                });
            });

            sContent.Relations.ForEach(r =>
            {
                var blockFrom = content.Blocks.First(b => b.BlockIdentity == r.BlockFromIdentity) ?? throw new InvalidDataException("missing block from relative");
                var blockTo = content.Blocks.First(a => a.BlockIdentity == r.BlockToIdentity) ?? throw new InvalidDataException("missing block to relative");
                Relation rel = r.RelationType switch
                {
                    RelationType.Aggregation => new AggregationRelation(blockFrom, blockTo),
                    RelationType.Association => new AssociationRelation(blockFrom, blockTo),
                    RelationType.Composition => new CompositionRelation(blockFrom, blockTo),
                    RelationType.Dependency => new DependencyRelation(blockFrom, blockTo),
                    RelationType.Inheritance => new InheritanceRelation(blockFrom, blockTo),
                    RelationType.Realization => new RealizationRelation(blockFrom, blockTo),
                    _ => throw new ArgumentException()
                };

                if(rel is ICardinal card)
                {
                    card.ToCardinal = r.CardinalTo ?? throw new ArgumentNullException("cardinal to not found");
                    card.FromCardinal = r.CardinalFrom ?? throw new ArgumentNullException("cardinal to not found");
                }
                content.Relations.Add(rel);
            });

            return content;
        }

        private SavableContent GetContent(Span<Relation> relations, Span<Block> blocks)
        {
            return new SavableContent()
            {
                Blocks = ConvertBlocks(blocks),
                Relations = ConvertRelations(relations)
            };
        }


        private List<RelationDTO> ConvertRelations(Span<Relation> relations)
        {
            var list = new List<RelationDTO>();
            foreach (var rel in relations)
            {
                list.Add(new RelationDTO()
                {
                    RelationType = rel switch
                    {
                        AggregationRelation => RelationType.Aggregation,
                        CompositionRelation => RelationType.Composition,
                        InheritanceRelation => RelationType.Inheritance,
                        RealizationRelation => RelationType.Realization,
                        AssociationRelation => RelationType.Association,
                        DependencyRelation => RelationType.Dependency,
                        _ => throw new NotImplementedException()
                    },
                    CardinalFrom = rel is ICardinal c ? c.FromCardinal : null,
                    CardinalTo = rel is ICardinal ca ? ca.ToCardinal : null,
                    BlockFromIdentity = rel.BlockFrom.BlockIdentity,
                    BlockToIdentity = rel.BlockTo.BlockIdentity,
                });
            }
            return list;
        }

        private List<BlockDTO> ConvertBlocks(Span<Block> blocks)
        {
            var list = new List<BlockDTO>();
            foreach (var block in blocks)
            {
                list.Add(new BlockDTO()
                {
                    Identity = block.BlockIdentity,
                    Methods = block.Methods,
                    Properties = block.Properties,
                    Name = block.Name,
                    IsAbstract = block.IsAbstract,
                    IsStatic = block.IsStatic,
                    Stereotype = block.Stereotype,
                    Point = block.Location,
                });
            }
            return list;
        }
    }
}
