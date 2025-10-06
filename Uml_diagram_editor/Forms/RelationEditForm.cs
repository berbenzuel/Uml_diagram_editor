using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Uml_diagram_editor.DataContent.BlockContent.Methods;
using Uml_diagram_editor.DataContent.RelationContent;
using Uml_diagram_editor.Model;
using Uml_diagram_editor.Model.Relations;

namespace Uml_diagram_editor.Forms
{
    public partial class RelationEditForm : Form
    {
        public Relation Relation { get; set; }

        public RelationEditForm(Relation relation, List<Block> blocks)
        {
            InitializeComponent();

            Relation = relation;

            this.BlockFromComboBox.DataSource = blocks.ToList();
            this.BlockFromComboBox.ValueMember = "Name";


            this.BlockToComboBox.DataSource = blocks.ToList();
            this.BlockToComboBox.ValueMember = "Name";

            this.BlockFromComboBox.SelectedIndex = blocks.IndexOf(relation.BlockFrom);
            this.BlockToComboBox.SelectedIndex = blocks.IndexOf(relation.BlockTo);

            this.okButton.DialogResult = DialogResult.OK;
            this.cancelButton.DialogResult = DialogResult.Cancel;

            this.relationTypeComboBox.DataSource = Enum.GetValues(typeof(RelationType));
            this.relationTypeComboBox.SelectedIndex = (int)GetRelationType(relation);

            this.cardinalFromComboBox.DataSource = Enum.GetValues(typeof(Cardinal));
            this.CardinalToComboBox.DataSource = Enum.GetValues(typeof(Cardinal));

            if (HaveCardinals(relation))
            {
                this.cardinalPanel.Visible = true;
                cardinalFromComboBox.SelectedIndex = (int)((ICardinal)relation).FromCardinal; 
                CardinalToComboBox.SelectedIndex = (int)((ICardinal)relation).ToCardinal;
            }
            else
            {
                this.cardinalPanel.Visible =false;
            }

            Invalidate();
        }

        private RelationType GetRelationType(Relation relation)
        {
            return relation switch
            {
                AggregationRelation => RelationType.Aggregation,
                AssociationRelation => RelationType.Association,
                CompositionRelation => RelationType.Composition,
                DependencyRelation => RelationType.Dependency,
                InheritanceRelation => RelationType.Inheritance,
                RealizationRelation => RelationType.Realization,
                _ => RelationType.Association

            };
        }

        private Relation GetRelation(RelationType relationType)
        {
            var blockFrom = (Block)BlockFromComboBox.SelectedItem;
            var blockTo = (Block)BlockToComboBox.SelectedItem;
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

        private bool HaveCardinals(Relation relation)
        {
            return relation is ICardinal;
        }

        private void relationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Relation = GetRelation((RelationType)relationTypeComboBox.SelectedValue);
            this.cardinalPanel.Visible = HaveCardinals(this.Relation);
        }

        private void RelationEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (BlockFromComboBox.SelectedItem is null) errorProvider1.SetError(BlockFromComboBox, "Selection cannot be empty");
                if (BlockToComboBox.SelectedItem is null) errorProvider1.SetError(BlockToComboBox, "Selection cannot be empty");
                if (BlockToComboBox.SelectedItem == BlockFromComboBox) errorProvider1.SetError(BlockToComboBox, "Selection must differ from previous");


                Relation.BlockFrom = (Block)BlockFromComboBox.SelectedItem;
                Relation.BlockTo = (Block)BlockToComboBox.SelectedItem;
                if (Relation is ICardinal cardinal)
                {
                    cardinal.FromCardinal = (Cardinal)cardinalFromComboBox.SelectedItem;
                    cardinal.ToCardinal = (Cardinal)CardinalToComboBox.SelectedItem;
                }
                var foo = this.Relation as ICardinal;
            }
        }
    }
}

