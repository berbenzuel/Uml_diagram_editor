namespace Uml_diagram_editor.BlockEditForms
{
    partial class MethodeAttributesEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            attributesBindingSource = new BindingSource(components);
            methodItemBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            attributeTypeColumn = new DataGridViewComboBoxColumn();
            flowLayoutPanel4 = new FlowLayoutPanel();
            okButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)attributesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)methodItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(141, 27);
            label1.TabIndex = 0;
            label1.Text = "foo attributes";
            // 
            // attributesBindingSource
            // 
            attributesBindingSource.DataMember = "Attributes";
            attributesBindingSource.DataSource = methodItemBindingSource;
            // 
            // methodItemBindingSource
            // 
            methodItemBindingSource.DataSource = typeof(DataContent.BlockContent.Methods.MethodItem);
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, attributeTypeColumn });
            dataGridView1.DataSource = attributesBindingSource;
            dataGridView1.Location = new Point(12, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(514, 235);
            dataGridView1.TabIndex = 3;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // attributeTypeColumn
            // 
            attributeTypeColumn.DataPropertyName = "AttributeType";
            attributeTypeColumn.HeaderText = "AttributeType";
            attributeTypeColumn.Name = "attributeTypeColumn";
            attributeTypeColumn.Resizable = DataGridViewTriState.True;
            attributeTypeColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.Controls.Add(okButton);
            flowLayoutPanel4.Controls.Add(cancelButton);
            flowLayoutPanel4.Location = new Point(12, 327);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(514, 29);
            flowLayoutPanel4.TabIndex = 14;
            // 
            // okButton
            // 
            okButton.Location = new Point(3, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 4;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(84, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // MethodeAttributesEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 358);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "MethodeAttributesEditForm";
            Text = "MethodeAttributesEditingForm";
            FormClosed += MethodeAttributesEditForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)attributesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)methodItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private BindingSource attributesBindingSource;
        private BindingSource methodItemBindingSource;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn attributeTypeColumn;
        private FlowLayoutPanel flowLayoutPanel4;
        private Button okButton;
        private Button cancelButton;
    }
}