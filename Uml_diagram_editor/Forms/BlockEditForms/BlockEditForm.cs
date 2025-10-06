using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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
        public Block EditableContent { get; private set; }
        private Block _originalContent { get; set; }

        private BindingList<PropertyItem> _properties = new();
        private BindingList<MethodItem> _methods = new();

        public BlockEditForm(Block block)
        {
            _originalContent = block;
            this.EditableContent = DeepCopy(block);
            InitializeComponent();

            this.okButton.DialogResult = DialogResult.OK;
            this.cancelButton.DialogResult = DialogResult.Cancel;


            InitializeData();




        }

        private void InitializeData()
        {
            nameTextBox.Text = EditableContent.Name;
            stereotypeComboBox.DataSource = Enum.GetValues(typeof(Stereotype)); // stereotypeList should be a List<Stereotype>
            stereotypeComboBox.DataBindings.Add("SelectedItem", EditableContent, "Stereotype", true, DataSourceUpdateMode.OnPropertyChanged);



            isAbstractCheckBox.Checked = EditableContent.IsAbstract;
            isStaticCheckBox.Checked = EditableContent.IsStatic;


            this._properties = new(EditableContent.Properties);
            this._methods = new(EditableContent.Methods);

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
                EditableContent.Methods[e.RowIndex] = form.Method;
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
            if (e.Cancel) return;

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
                EditableContent.Name = nameTextBox.Text;
                EditableContent.Stereotype = (Stereotype)stereotypeComboBox.SelectedItem;
                EditableContent.Properties = new(this._properties);
                EditableContent.Methods = new(this._methods);
                EditableContent.IsAbstract = isAbstractCheckBox.Checked;
                EditableContent.IsStatic = isStaticCheckBox.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BlockEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                _originalContent.Name = EditableContent.Name;
                _originalContent.Stereotype = EditableContent.Stereotype;
                _originalContent.Properties = EditableContent.Properties;
                _originalContent.Methods = EditableContent.Methods;
                _originalContent.IsAbstract = EditableContent.IsAbstract;
                _originalContent.IsStatic = EditableContent.IsStatic;

                return;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;

            }
        }

        private void BlockEditForm_Load(object sender, EventArgs e)
        {

        }

        public Block DeepCopy(Block block)
        {
            return JsonSerializer.Deserialize<Block>(JsonSerializer.Serialize(block));
        }

        private void BlockEditForm_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrEmpty(nameTextBox.Text))
            {
                errorProvider1.SetError(nameTextBox, "cannot be empty");
                e.Cancel = true;
            }
        }
    }
}
