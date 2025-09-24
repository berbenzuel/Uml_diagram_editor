using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.Model;

namespace Uml_diagram_editor
{
    public partial class BlockEditForm : Form
    {
        public Block Content { get; private set; }

        public BlockEditForm(Block block)
        {
            this.Content = block;
            InitializeComponent();

            InitializeData();

        }

        public BlockEditForm()
        {
            InitializeComponent();
            this.Content = new Block();
        }

        private void InitializeData()
        {
            this.nameTextBox.Text = Content.Name;
        }
    }
}
