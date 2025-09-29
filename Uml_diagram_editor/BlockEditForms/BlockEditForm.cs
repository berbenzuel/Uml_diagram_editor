using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.BlockEditForms;
using Uml_diagram_editor.DataContent;
using Uml_diagram_editor.DataContent.BlockContent;
using Uml_diagram_editor.DataContent.BlockContent.Method;
using Uml_diagram_editor.DataContent.BlockContent.Methods;
using Uml_diagram_editor.Model;

namespace Uml_diagram_editor
{
    public partial class BlockEditForm : Form
    {
        public Block Content { get; private set; }

        private BindingList<PropertyItem> _properties = new();
        private BindingList<MethodItem> _methods = new();

        public BlockEditForm(Block block)
        {
            this.Content = block;
            InitializeComponent();

            this.okButton.DialogResult = DialogResult.OK;
            this.cancelButton.DialogResult = DialogResult.Cancel;


            InitializeData();




        }

        private void InitializeData()
        {
            nameTextBox.Text = Content.Name;
            stereotypeComboBox.DataSource = Enum.GetValues(typeof(Stereotype)); // stereotypeList should be a List<Stereotype>
            stereotypeComboBox.DataBindings.Add("SelectedItem", Content, "Stereotype", true, DataSourceUpdateMode.OnPropertyChanged);



            isAbstractCheckBox.Checked = Content.IsAbstract;
            isStaticCheckBox.Checked = Content.IsStatic;


            this._properties = Content.Properties;
            this._methods = Content.Methods;

            this.propertiesView.DataSource = this._properties;
            this.methodsView.DataSource = this._methods;

            this.propertiesAccessTypeColumn.DataSource = Enum.GetValues(typeof(AccessType));
            this.methodsAccessTypeColumn.DataSource = Enum.GetValues(typeof(AccessType));

            attributesColumn.ValueType = typeof(string);
            attributesColumn.DefaultCellStyle.NullValue = "[]";
            attributesColumn.ToolTipText = "Click to edit attributes";
            methodsView.CellClick += GetMethodsView_CellContentClick;
            Invalidate();
        }

        private void GetMethodsView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != attributesColumn.Index || e.RowIndex < 0)
                return;
            var methodItem = methodsView.Rows[e.RowIndex].DataBoundItem as MethodItem;
            methodItem ??= new MethodItem();
            var form = new MethodeAttributesEditForm(methodItem);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Content.Methods[e.RowIndex] = form.Method;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BlockEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                Content.Name = nameTextBox.Text;
                Content.Stereotype = stereotypeComboBox.SelectedItem as Stereotype?;
                Content.Properties = this._properties;
                Content.Methods = this._methods;
                Content.IsAbstract = isAbstractCheckBox.Checked;
                Content.IsStatic = isStaticCheckBox.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
    }
}
