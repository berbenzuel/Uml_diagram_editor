using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent;
using Uml_diagram_editor.DataContent.BlockContent;
using Uml_diagram_editor.DataContent.BlockContent.Method;
using Uml_diagram_editor.DataContent.BlockContent.Methods;
using Uml_diagram_editor.DataContent.RelationContent;
using Uml_diagram_editor.Forms;
using Uml_diagram_editor.Managers;
using Uml_diagram_editor.Model;
using Uml_diagram_editor.Model.Relations;

namespace Uml_diagram_editor
{
    public partial class Form1 : Form
    {


        private BlockManager blockManager { get; set; }
        private RelationManager relationManager { get; set; }
        private IoManager IoManager { get; set; }
        private Block? _selectedBlock { get; set; }
        private List<Relation>? _selectedRelations { get; set; }

        private Point _picBoxMousePosition { get; set; }
        private Point _pictureBoxAbsolutePoint = new Point(0, 0);

        private Grid? grid = null;
        //private const int Palette.Palette.GridSize = 10;

        private bool _relationSelectionEnabled = false;
        private RelationType? CurrentRelationType = null;

        private float zoom => zoomTrackBar.Value / 100.0f;
        public Form1()
        {
            InitializeComponent();

            blockManager = new BlockManager();
            relationManager = new RelationManager();
            IoManager = new IoManager();
        }

        private void InvalidateWithOffset(Rectangle bounds)
        {
            var rect = new Rectangle(bounds.Location, bounds.Size);
            rect.X += _pictureBoxAbsolutePoint.X;
            rect.Y += _pictureBoxAbsolutePoint.Y;

            pictureBox1.Invalidate(rect, true);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //quite unoptimized, use bitmap maybe into picture box?
            var g = e.Graphics;

            g.ScaleTransform(zoom, zoom);
            //posunuti boud na zaklade zvetseni podle pozici mysi
            g.TranslateTransform(_pictureBoxAbsolutePoint.X, _pictureBoxAbsolutePoint.Y);



            if (grid is not null)
            {
                grid.Draw(g, pictureBox1.ClientRectangle, _pictureBoxAbsolutePoint, zoom);
            }
            foreach (var block in blockManager.Blocks)
            {
                block.Draw(g, Palette.GridSize);
            }
            foreach (var relation in relationManager.Relations)
            {
                relation.Draw(g, Palette.GridSize);
            }


        }

        private Point GetRelative(Point point)
        {

            var _point = new Point((int)(point.X / zoom - _pictureBoxAbsolutePoint.X), (int)(point.Y / zoom - _pictureBoxAbsolutePoint.Y));
            //i have this for debuging purposes
            //pictureBox1.CreateGraphics().DrawRectangle(Pens.Red, new Rectangle(_point, new Size(1,1)));
            return _point;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var blockDetected = false;
                var temp = blockManager.Blocks.Find(b => b.Equals(_selectedBlock));
                for (var block_index = blockManager.Blocks.Count - 1; block_index >= 0; block_index--)
                {
                    var block = blockManager.Blocks[block_index];
                    if (!blockDetected && block.Detect(GetRelative(e.Location)))
                    {
                        if (_relationSelectionEnabled)
                        {
                            AddRelationAterClick((RelationType)CurrentRelationType, _selectedBlock, block);
                            _relationSelectionEnabled = false;
                            CurrentRelationType = null;
                        }
                        _selectedBlock = block;
                        block.IsSelected = true;
                        blockDetected = true;
                        _selectedRelations = new();
                    }
                    else
                    {
                        if (block.IsSelected)
                        {
                            block.IsSelected = false;
                            _selectedBlock = blockDetected ? _selectedBlock : null;
                        }
                    }
                }
                if (_relationSelectionEnabled)
                {
                    AddRelationAterClick((RelationType)CurrentRelationType, temp, null);
                    _relationSelectionEnabled = false;
                    CurrentRelationType = null;
                }


                foreach (var relation in relationManager.Relations)
                {
                    if (blockDetected)
                    {
                        //fill selected relations
                        if (relation.BlockFrom.Equals(_selectedBlock))
                        {
                            relation.IsSelected = true;
                            _selectedRelations.Add(relation);
                            continue;
                        }
                        relation.IsSelected = false;

                    }
                    else
                    {
                        if (relation.Detect(GetRelative(e.Location)))
                        {
                            _selectedRelations = new() { relation };

                            relation.IsSelected = true;
                            blockDetected = true;
                            continue;
                        }
                        relation.IsSelected = false;
                    }
                }
                Invalidate(true);
            }
            if (e.Button == MouseButtons.Right)
            {
                var screenPoint = pictureBox1.PointToScreen(e.Location);
                contextMenuStrip1.Show(screenPoint);
            }
            if (e.Button == MouseButtons.Middle)
            {

            }
            //_picBoxMousePosition = new((int)(e.Location.X / zoom), (int)(e.Location.Y / zoom));
            _picBoxMousePosition = new((int)(e.Location.X / zoom), (int)(e.Location.Y / zoom));
        }





        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left &&
                _selectedBlock is Block block &&
                block.IsSelected &&
                block.Detect(GetRelative(e.Location)))
            {
                var oldBounds = block.Bounds;
                oldBounds.Inflate(5, 5);
                block.Location = new Point((int)(e.X / zoom - _pictureBoxAbsolutePoint.X - block.Width / 2),
                    (int)(e.Y / zoom - _pictureBoxAbsolutePoint.Y - block.Height / 2));

                Invalidate(true);
            }
            if (e.Button == MouseButtons.Middle)
            {
                var _deltaX = (e.Location.X / zoom - _picBoxMousePosition.X);
                var _deltaY = (e.Location.Y / zoom - _picBoxMousePosition.Y);
                var point = new Point(_pictureBoxAbsolutePoint.X + (int)_deltaX, _pictureBoxAbsolutePoint.Y + (int)_deltaY);
                _pictureBoxAbsolutePoint = new Point((int)(point.X), (int)(point.Y));
                _picBoxMousePosition = new((int)(e.Location.X / zoom), (int)(e.Y / zoom));
                Invalidate(Region, true);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var grid = this.checkBox1.Checked ? new Grid(Palette.GridSize) : null;
            this.grid = grid;
            pictureBox1.Invalidate(true);
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (grid is not null &&
                _selectedBlock is Block block)
            {
                block.Location = grid.Snap(block.Location);
                Invalidate(true);
            }
        }

        private void AddBlock(object sender, EventArgs e)
        {
            var point = _picBoxMousePosition;
            point.Offset(-_pictureBoxAbsolutePoint.X, -_pictureBoxAbsolutePoint.Y);
            var block = blockManager.AddBlock(point);
            if (block is not null)
            {
                InvalidateWithOffset(block.Bounds);
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var detected = false;
            for (var block_index = blockManager.Blocks.Count - 1; block_index >= 0; block_index--)
            {
                var block = blockManager.Blocks[block_index];
                if (!detected && block.Detect(GetRelative(e.Location)))
                {
                    block.IsSelected = true;
                    _selectedBlock = block;
                    EditBlock(block);
                }
                else
                {
                    block.IsSelected = false;
                }
            }
            Invalidate();
        }

        private void EditBlock(Block block)
        {
            if (blockManager.EditBlock(block))
            {
                Invalidate(true); //implement func for offcet
            }
        }
        private void EditRelation(Relation relation)
        {
            if (relationManager.EditRelation(relation, blockManager.Blocks))
            {
                Invalidate(true);
            }
        }

        private void AddRelation(RelationType relation)
        {
            if (blockManager.Blocks.Count < 2)
            {
                return;
            }
            if (_selectedBlock is null)
            {
                AddRelationAterClick(relation, null, null);
            }

            _relationSelectionEnabled = true;
            CurrentRelationType = relation;
        }
        private void AddRelationAterClick(RelationType relation, Block? from, Block? to)
        {
            var res = relationManager.AddRelation(relation, blockManager.Blocks, from, to ?? blockManager.Blocks[1]);
            if (res)
            {
                Invalidate(true);
            }
        }

        private void deleteBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedBlock is Block block)
            {
                blockManager.Blocks.Remove(block);
                _selectedBlock = null;
                relationManager.Relations.RemoveAll(connection => connection.BlockFrom.Equals(block) && connection.BlockTo.Equals(block));
                pictureBox1.Invalidate(true);
            }
            if (_selectedRelations is not null)
            {
                foreach (var rel in _selectedRelations)
                {
                    relationManager.Relations.Remove(rel);
                }
                Invalidate(true);
            }

        }

        private void editBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedBlock is Block block) EditBlock(block);
            else if (_selectedRelations is List<Relation> relation)
            {
                EditRelation(relation.Last());
            }
            Invalidate(true);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            foreach (var block in blockManager.Blocks)
            {
                block.Width = (int)(block.Width * zoom);
                block.Height = (int)(block.Height * zoom);
            }
            pictureBox1.Invalidate(true);
        }

        private void aggregationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRelation(RelationType.Aggregation);
        }

        private void associationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRelation(RelationType.Association);
        }

        private void compositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRelation(RelationType.Composition);
        }

        private void dependencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRelation(RelationType.Dependency);
        }

        private void inheritanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRelation(RelationType.Inheritance);
        }

        private void realizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRelation(RelationType.Realization);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IoManager.SaveContentAs(CollectionsMarshal.AsSpan(blockManager.Blocks), CollectionsMarshal.AsSpan(relationManager.Relations));
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IoManager.ExportToPng(CollectionsMarshal.AsSpan(blockManager.Blocks), CollectionsMarshal.AsSpan(relationManager.Relations));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IoManager.SaveContent(CollectionsMarshal.AsSpan(blockManager.Blocks), CollectionsMarshal.AsSpan(relationManager.Relations));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rawContent = IoManager.OpenContent();
            if (rawContent is null) return;
            var cont = IoManager.ProcessContent(rawContent);
            
            blockManager.ProcessContent(cont);
            relationManager.ProcessContent(cont);

            Invalidate(true);

        }
    }
}
