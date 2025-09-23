using Uml_diagram_editor.Common;
using Uml_diagram_editor.Model;

namespace Uml_diagram_editor
{
    public partial class Form1 : Form
    {
        Block Block { get; set; }
        public Form1()
        {
            InitializeComponent();
            Block = new Block("MyClass", new Point(0, 0))
            {
                Attributes = new List<string> { "int id", "string name" },
                Methods = new List<string> { "void SetName(string name)", "string GetName()" }
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (checkBox1.Checked)
            {
                Grid.Draw(g, pictureBox1.ClientRectangle, Convert.ToInt32(numericUpDown1.Value));
            }

            Block.Draw(g);



        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Block.Bounds.Contains(e.Location))
            {
                Block.IsSelected = true;
            }
            else
            {
                Block.IsSelected = false;
            }
            Invalidate(true);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && Block.Bounds.Contains(e.Location) && Block.IsSelected)
            {

                Block.Location = new Point(e.X - Block.Width / 2, e.Y - Block.Height / 2);

                Invalidate(true);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                Block.Location = Grid.Snap(Block.Location, Convert.ToInt32(numericUpDown1.Value));
                Invalidate(true);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
