using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.DataContent;
using Uml_diagram_editor.DataContent.SavableContent;
using Uml_diagram_editor.Model;

namespace Uml_diagram_editor.Managers
{
    public class BlockManager
    {
        public List<Block> Blocks = new();
        private int lastIdentity = 0;


        public Block? AddBlock(Point location)
        {
            var block = new Block(location);
            var form = new BlockEditForm(block);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                lastIdentity++;
                block.BlockIdentity = lastIdentity;
                Blocks.Add(block);
                return block;
            }
            return null;

        }

        public bool RemoveBlock(Block block)
        {
            return Blocks.Remove(block);
        }

        public Block? RemoveBlockAt(int index)
        {
            try
            {
                var block = Blocks[index];
                RemoveBlock(block);
                return block;
            }
            catch {
                return null;
            }
        }

        public bool EditBlock(Block block)
        {

            var form = new BlockEditForm(block);
            return form.ShowDialog() == DialogResult.OK;

        }
        

        public void ProcessContent(Content content)
        {
            
            this.Blocks.Clear();
            this.Blocks = content.Blocks;
            lastIdentity = Blocks.Max(b=> b.BlockIdentity);
        }
    }
}
