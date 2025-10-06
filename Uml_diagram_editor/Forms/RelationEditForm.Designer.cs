namespace Uml_diagram_editor.Forms
{
    partial class RelationEditForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            BlockFromComboBox = new ComboBox();
            BlockToComboBox = new ComboBox();
            blockManagerBindingSource = new BindingSource(components);
            okButton = new Button();
            cancelButton = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            relationTypeComboBox = new ComboBox();
            cardinalPanel = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            cardinalFromComboBox = new ComboBox();
            CardinalToComboBox = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)blockManagerBindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            cardinalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.286396F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.7136F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(BlockFromComboBox, 1, 0);
            tableLayoutPanel1.Controls.Add(BlockToComboBox, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(419, 62);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Block from";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 31);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "Block to";
            // 
            // BlockFromComboBox
            // 
            BlockFromComboBox.FormattingEnabled = true;
            BlockFromComboBox.Location = new Point(88, 3);
            BlockFromComboBox.Name = "BlockFromComboBox";
            BlockFromComboBox.Size = new Size(328, 23);
            BlockFromComboBox.TabIndex = 2;
            // 
            // BlockToComboBox
            // 
            BlockToComboBox.FormattingEnabled = true;
            BlockToComboBox.Location = new Point(88, 34);
            BlockToComboBox.Name = "BlockToComboBox";
            BlockToComboBox.Size = new Size(328, 23);
            BlockToComboBox.TabIndex = 3;
            // 
            // blockManagerBindingSource
            // 
            blockManagerBindingSource.DataSource = typeof(Managers.BlockManager);
            // 
            // okButton
            // 
            okButton.Location = new Point(12, 321);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 1;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(93, 321);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.6730766F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.32692F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(relationTypeComboBox, 1, 0);
            tableLayoutPanel2.Location = new Point(12, 94);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(419, 31);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 0;
            label3.Text = "Relation Type";
            // 
            // relationTypeComboBox
            // 
            relationTypeComboBox.FormattingEnabled = true;
            relationTypeComboBox.Location = new Point(89, 3);
            relationTypeComboBox.Name = "relationTypeComboBox";
            relationTypeComboBox.Size = new Size(327, 23);
            relationTypeComboBox.TabIndex = 1;
            relationTypeComboBox.SelectedIndexChanged += relationTypeComboBox_SelectedIndexChanged;
            // 
            // cardinalPanel
            // 
            cardinalPanel.ColumnCount = 2;
            cardinalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.0338974F));
            cardinalPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.9661F));
            cardinalPanel.Controls.Add(label4, 0, 0);
            cardinalPanel.Controls.Add(label5, 0, 1);
            cardinalPanel.Controls.Add(cardinalFromComboBox, 1, 0);
            cardinalPanel.Controls.Add(CardinalToComboBox, 1, 1);
            cardinalPanel.Location = new Point(15, 157);
            cardinalPanel.Name = "cardinalPanel";
            cardinalPanel.RowCount = 2;
            cardinalPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardinalPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            cardinalPanel.Size = new Size(413, 61);
            cardinalPanel.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 0;
            label4.Text = "Cardinal from";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 30);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 1;
            label5.Text = "Cardinal to";
            // 
            // cardinalFromComboBox
            // 
            cardinalFromComboBox.FormattingEnabled = true;
            cardinalFromComboBox.Location = new Point(94, 3);
            cardinalFromComboBox.Name = "cardinalFromComboBox";
            cardinalFromComboBox.Size = new Size(316, 23);
            cardinalFromComboBox.TabIndex = 2;
            // 
            // CardinalToComboBox
            // 
            CardinalToComboBox.FormattingEnabled = true;
            CardinalToComboBox.Location = new Point(94, 33);
            CardinalToComboBox.Name = "CardinalToComboBox";
            CardinalToComboBox.Size = new Size(316, 23);
            CardinalToComboBox.TabIndex = 3;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // RelationEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 356);
            Controls.Add(cardinalPanel);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(tableLayoutPanel1);
            Name = "RelationEditForm";
            Text = "RelationEditForm";
            FormClosed += RelationEditForm_FormClosed;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)blockManagerBindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            cardinalPanel.ResumeLayout(false);
            cardinalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ComboBox BlockFromComboBox;
        private ComboBox BlockToComboBox;
        private BindingSource blockManagerBindingSource;
        private Button okButton;
        private Button cancelButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private ComboBox relationTypeComboBox;
        private TableLayoutPanel cardinalPanel;
        private Label label4;
        private Label label5;
        private ComboBox cardinalFromComboBox;
        private ComboBox CardinalToComboBox;
        private ErrorProvider errorProvider1;
    }
}