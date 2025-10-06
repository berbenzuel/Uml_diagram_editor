using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.DataContent.BlockContent.Method;
using Uml_diagram_editor.DataContent.BlockContent.Methods;

namespace Uml_diagram_editor.BlockEditForms
{
    public partial class MethodeAttributesEditForm : Form
    {
        public MethodItem Method;
        public MethodeAttributesEditForm(MethodItem method)
        {
            Method = method;
            InitializeComponent();

            this.okButton.DialogResult = DialogResult.OK;
            this.cancelButton.DialogResult = DialogResult.Cancel;

            this.dataGridView1.DataBindings.Add(nameof(DataGridView.DataSource), Method, nameof(Method.Attributes), false, DataSourceUpdateMode.Never);
            this.attributeTypeColumn.DataSource = Enum.GetValues(typeof(MethodAttributeType));
            this.dataGridView1.AllowUserToAddRows = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void MethodeAttributesEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.dataGridView1.EndEdit();
                this.dataGridView1.DataBindings[0].WriteValue();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
