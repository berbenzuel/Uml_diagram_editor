namespace Uml_diagram_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            addBlockButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            addNewBlockToolStripMenuItem = new ToolStripMenuItem();
            deleteBlockToolStripMenuItem = new ToolStripMenuItem();
            editBlockToolStripMenuItem = new ToolStripMenuItem();
            zoomTrackBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)zoomTrackBar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(199, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(958, 715);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            pictureBox1.MouseDoubleClick += pictureBox1_MouseDoubleClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseHover += pictureBox1_MouseHover;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(51, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "snap";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = SystemColors.AppWorkspace;
            flowLayoutPanel1.Controls.Add(checkBox1);
            flowLayoutPanel1.Controls.Add(addBlockButton);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(199, 715);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // addBlockButton
            // 
            addBlockButton.ImageAlign = ContentAlignment.MiddleLeft;
            addBlockButton.Location = new Point(3, 28);
            addBlockButton.Name = "addBlockButton";
            addBlockButton.Size = new Size(193, 23);
            addBlockButton.TabIndex = 4;
            addBlockButton.Text = "add new Block";
            addBlockButton.UseVisualStyleBackColor = true;
            addBlockButton.Click += AddBlock;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { addNewBlockToolStripMenuItem, deleteBlockToolStripMenuItem, editBlockToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(152, 70);
            // 
            // addNewBlockToolStripMenuItem
            // 
            addNewBlockToolStripMenuItem.Name = "addNewBlockToolStripMenuItem";
            addNewBlockToolStripMenuItem.Size = new Size(151, 22);
            addNewBlockToolStripMenuItem.Text = "add new block";
            addNewBlockToolStripMenuItem.Click += AddBlock;
            // 
            // deleteBlockToolStripMenuItem
            // 
            deleteBlockToolStripMenuItem.Name = "deleteBlockToolStripMenuItem";
            deleteBlockToolStripMenuItem.Size = new Size(151, 22);
            deleteBlockToolStripMenuItem.Text = "delete block";
            deleteBlockToolStripMenuItem.Click += deleteBlockToolStripMenuItem_Click;
            // 
            // editBlockToolStripMenuItem
            // 
            editBlockToolStripMenuItem.Name = "editBlockToolStripMenuItem";
            editBlockToolStripMenuItem.Size = new Size(151, 22);
            editBlockToolStripMenuItem.Text = "edit block";
            editBlockToolStripMenuItem.Click += editBlockToolStripMenuItem_Click;
            // 
            // zoomTrackBar
            // 
            zoomTrackBar.LargeChange = 50;
            zoomTrackBar.Location = new Point(205, 670);
            zoomTrackBar.Maximum = 200;
            zoomTrackBar.Minimum = 1;
            zoomTrackBar.Name = "zoomTrackBar";
            zoomTrackBar.Size = new Size(210, 45);
            zoomTrackBar.TabIndex = 3;
            zoomTrackBar.Value = 100;
            zoomTrackBar.Visible = false;
            zoomTrackBar.Scroll += zoomTrackBar_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 715);
            Controls.Add(zoomTrackBar);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)zoomTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button addBlockButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem addNewBlockToolStripMenuItem;
        private ToolStripMenuItem deleteBlockToolStripMenuItem;
        private ToolStripMenuItem editBlockToolStripMenuItem;
        private TrackBar zoomTrackBar;
    }
}
