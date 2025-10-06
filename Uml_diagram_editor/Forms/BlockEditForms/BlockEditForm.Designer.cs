using Uml_diagram_editor.DataContent.BlockContent;

namespace Uml_diagram_editor
{
    partial class BlockEditForm
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
            label2 = new Label();
            nameTextBox = new TextBox();
            label1 = new Label();
            propertiesView = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            propertiesAccessTypeColumn = new DataGridViewComboBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            IsReadOnly = new DataGridViewCheckBoxColumn();
            propertyItemBindingSource2 = new BindingSource(components);
            okButton = new Button();
            cancelButton = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            stereotypeComboBox = new ComboBox();
            blockBindingSource = new BindingSource(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            methodsView = new DataGridView();
            aghfoo = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            methodsAccessTypeColumn = new DataGridViewComboBoxColumn();
            attributesColumn = new DataGridViewTextBoxColumn();
            IsAbstract = new DataGridViewCheckBoxColumn();
            IsStatic = new DataGridViewCheckBoxColumn();
            methodItemBindingSource = new BindingSource(components);
            propertyItemBindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            propertyItemBindingSource = new BindingSource(components);
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            accessTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isAbstractCheckBox = new CheckBox();
            isStaticCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)propertiesView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)propertyItemBindingSource2).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blockBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)methodsView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)methodItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)propertyItemBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)propertyItemBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 3;
            label2.Text = "properties";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(88, 3);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(327, 23);
            nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 1;
            label1.Text = "name";
            // 
            // propertiesView
            // 
            propertiesView.AutoGenerateColumns = false;
            propertiesView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            propertiesView.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, propertiesAccessTypeColumn, dataGridViewCheckBoxColumn1, dataGridViewCheckBoxColumn2, IsReadOnly });
            propertiesView.DataSource = propertyItemBindingSource2;
            propertiesView.Location = new Point(3, 18);
            propertiesView.Name = "propertiesView";
            propertiesView.Size = new Size(715, 100);
            propertiesView.TabIndex = 2;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Type";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // propertiesAccessTypeColumn
            // 
            propertiesAccessTypeColumn.DataPropertyName = "AccessType";
            propertiesAccessTypeColumn.HeaderText = "AccessType";
            propertiesAccessTypeColumn.Name = "propertiesAccessTypeColumn";
            propertiesAccessTypeColumn.Resizable = DataGridViewTriState.True;
            propertiesAccessTypeColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "IsStatic";
            dataGridViewCheckBoxColumn1.HeaderText = "IsStatic";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCheckBoxColumn2.DataPropertyName = "IsAbstract";
            dataGridViewCheckBoxColumn2.HeaderText = "IsAbstract";
            dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // IsReadOnly
            // 
            IsReadOnly.DataPropertyName = "IsReadOnly";
            IsReadOnly.HeaderText = "IsReadOnly";
            IsReadOnly.Name = "IsReadOnly";
            // 
            // propertyItemBindingSource2
            // 
            propertyItemBindingSource2.DataSource = typeof(PropertyItem);
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
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Controls.Add(propertiesView);
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(719, 121);
            flowLayoutPanel3.TabIndex = 11;
            flowLayoutPanel3.Paint += flowLayoutPanel3_Paint;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.Controls.Add(okButton);
            flowLayoutPanel4.Controls.Add(cancelButton);
            flowLayoutPanel4.Location = new Point(6, 415);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(725, 29);
            flowLayoutPanel4.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 50);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 1;
            label4.Text = "annotation";
            label4.Click += label4_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.4851761F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.5148239F));
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(nameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(stereotypeComboBox, 1, 1);
            tableLayoutPanel1.Location = new Point(3, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(418, 100);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // stereotypeComboBox
            // 
            stereotypeComboBox.DataSource = blockBindingSource;
            stereotypeComboBox.DisplayMember = "Stereotype";
            stereotypeComboBox.FormattingEnabled = true;
            stereotypeComboBox.Location = new Point(88, 53);
            stereotypeComboBox.Name = "stereotypeComboBox";
            stereotypeComboBox.Size = new Size(327, 23);
            stereotypeComboBox.TabIndex = 2;
            // 
            // blockBindingSource
            // 
            blockBindingSource.DataSource = typeof(Model.Block);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel2.Location = new Point(0, 146);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(725, 256);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(methodsView);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 130);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(719, 121);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 8;
            label3.Text = "methods";
            // 
            // methodsView
            // 
            methodsView.AutoGenerateColumns = false;
            methodsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            methodsView.Columns.AddRange(new DataGridViewColumn[] { aghfoo, typeDataGridViewTextBoxColumn1, methodsAccessTypeColumn, attributesColumn, IsAbstract, IsStatic });
            methodsView.DataSource = methodItemBindingSource;
            methodsView.Location = new Point(3, 18);
            methodsView.Name = "methodsView";
            methodsView.Size = new Size(715, 100);
            methodsView.TabIndex = 7;
            methodsView.CellContentClick += dataGridView2_CellContentClick;
            // 
            // aghfoo
            // 
            aghfoo.DataPropertyName = "Name";
            aghfoo.HeaderText = "Name";
            aghfoo.Name = "aghfoo";
            // 
            // typeDataGridViewTextBoxColumn1
            // 
            typeDataGridViewTextBoxColumn1.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn1.HeaderText = "Type";
            typeDataGridViewTextBoxColumn1.Name = "typeDataGridViewTextBoxColumn1";
            // 
            // methodsAccessTypeColumn
            // 
            methodsAccessTypeColumn.DataPropertyName = "AccessType";
            methodsAccessTypeColumn.HeaderText = "AccessType";
            methodsAccessTypeColumn.Name = "methodsAccessTypeColumn";
            methodsAccessTypeColumn.Resizable = DataGridViewTriState.True;
            methodsAccessTypeColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // attributesColumn
            // 
            attributesColumn.HeaderText = "Attributes";
            attributesColumn.Name = "attributesColumn";
            attributesColumn.ReadOnly = true;
            attributesColumn.Resizable = DataGridViewTriState.True;
            // 
            // IsAbstract
            // 
            IsAbstract.DataPropertyName = "IsAbstract";
            IsAbstract.HeaderText = "IsAbstract";
            IsAbstract.Name = "IsAbstract";
            // 
            // IsStatic
            // 
            IsStatic.DataPropertyName = "IsStatic";
            IsStatic.HeaderText = "IsStatic";
            IsStatic.Name = "IsStatic";
            // 
            // methodItemBindingSource
            // 
            methodItemBindingSource.DataSource = typeof(DataContent.BlockContent.Methods.MethodItem);
            // 
            // propertyItemBindingSource1
            // 
            propertyItemBindingSource1.DataSource = typeof(PropertyItem);
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // propertyItemBindingSource
            // 
            propertyItemBindingSource.DataSource = typeof(PropertyItem);
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // typeDataGridViewTextBoxColumn2
            // 
            typeDataGridViewTextBoxColumn2.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn2.HeaderText = "Type";
            typeDataGridViewTextBoxColumn2.Name = "typeDataGridViewTextBoxColumn2";
            // 
            // accessTypeDataGridViewTextBoxColumn
            // 
            accessTypeDataGridViewTextBoxColumn.DataPropertyName = "AccessType";
            accessTypeDataGridViewTextBoxColumn.HeaderText = "AccessType";
            accessTypeDataGridViewTextBoxColumn.Name = "accessTypeDataGridViewTextBoxColumn";
            // 
            // isAbstractCheckBox
            // 
            isAbstractCheckBox.AutoSize = true;
            isAbstractCheckBox.Location = new Point(495, 45);
            isAbstractCheckBox.Name = "isAbstractCheckBox";
            isAbstractCheckBox.Size = new Size(68, 19);
            isAbstractCheckBox.TabIndex = 18;
            isAbstractCheckBox.Text = "abstract";
            isAbstractCheckBox.UseVisualStyleBackColor = true;
            // 
            // isStaticCheckBox
            // 
            isStaticCheckBox.AutoSize = true;
            isStaticCheckBox.Location = new Point(495, 70);
            isStaticCheckBox.Name = "isStaticCheckBox";
            isStaticCheckBox.Size = new Size(54, 19);
            isStaticCheckBox.TabIndex = 19;
            isStaticCheckBox.Text = "static";
            isStaticCheckBox.UseVisualStyleBackColor = true;
            // 
            // BlockEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 456);
            Controls.Add(isStaticCheckBox);
            Controls.Add(isAbstractCheckBox);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel4);
            Name = "BlockEditForm";
            Text = "Form2";
            FormClosing += BlockEditForm_FormClosing;
            FormClosed += BlockEditForm_FormClosed;
            Load += BlockEditForm_Load;
            Validating += BlockEditForm_Validating;
            ((System.ComponentModel.ISupportInitialize)propertiesView).EndInit();
            ((System.ComponentModel.ISupportInitialize)propertyItemBindingSource2).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)blockBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)methodsView).EndInit();
            ((System.ComponentModel.ISupportInitialize)methodItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)propertyItemBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)propertyItemBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox nameTextBox;
        private Label label1;
        private DataGridView propertiesView;
        private Button okButton;
        private Button cancelButton;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private BindingSource propertyItemBindingSource1;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private BindingSource propertyItemBindingSource;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private DataGridView methodsView;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn accessTypeDataGridViewTextBoxColumn;
        private BindingSource propertyItemBindingSource2;
        private BindingSource methodItemBindingSource;
        private CheckBox isStaticCheckBox;
        private CheckBox isAbstractCheckBox;
        private ComboBox stereotypeComboBox;
        private BindingSource blockBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn propertiesAccessTypeColumn;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewCheckBoxColumn IsReadOnly;
        private DataGridViewTextBoxColumn aghfoo;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
        private DataGridViewComboBoxColumn methodsAccessTypeColumn;
        private DataGridViewTextBoxColumn attributesColumn;
        private DataGridViewCheckBoxColumn IsAbstract;
        private DataGridViewCheckBoxColumn IsStatic;
    }
}