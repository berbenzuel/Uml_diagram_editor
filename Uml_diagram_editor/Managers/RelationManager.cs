using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.DataContent;
using Uml_diagram_editor.DataContent.RelationContent;
using Uml_diagram_editor.DataContent.SavableContent;
using Uml_diagram_editor.Forms;
using Uml_diagram_editor.Model;
using Uml_diagram_editor.Model.Relations;

namespace Uml_diagram_editor.Managers
{
    public class RelationManager
    {
        public List<Relation> Relations { get; private set; } = new List<Relation>();

        public bool EditRelation(Relation relation, List<Block> blocks)
        {
            Relations.Remove(relation);
            var form = new RelationEditForm(relation, blocks);
            var result = form.ShowDialog();
            Relations.Add(form.Relation);
            return result == DialogResult.OK;
        }

        public bool AddRelation(RelationType relationType, List<Block> blocks, Block blockFrom, Block blockTo)
        {
            var form = new RelationEditForm(GetRelation(relationType, blockFrom, blockTo), blocks);
            var result = form.ShowDialog();
            Relations.Add(form.Relation);
            return result == DialogResult.OK;
        }


        public Relation GetRelation(RelationType relationType, Block blockFrom, Block blockTo)
        {
            return relationType switch
            {
                RelationType.Aggregation => new AggregationRelation(blockFrom, blockTo),
                RelationType.Association => new AssociationRelation(blockFrom, blockTo),
                RelationType.Composition => new CompositionRelation(blockFrom, blockTo),
                RelationType.Dependency => new DependencyRelation(blockFrom, blockTo),
                RelationType.Inheritance => new InheritanceRelation(blockFrom, blockTo),
                RelationType.Realization => new RealizationRelation(blockFrom, blockTo),
                _ => throw new ArgumentException()
            };
        }

        public void ProcessContent(Content content)
        {
            Relations.Clear();
            Relations = content.Relations;
        }
    }

}
