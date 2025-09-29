using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.Model;
using System.Text.Json;

namespace Uml_diagram_editor.Managers
{
    public class BlockManager
    {
        public List<Block> Blocks = new();
        
        public Block? AddBlock(Point location)
        {
            var block = new Block(location);
            var form = new BlockEditForm(block);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
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
            // Make a deep copy of the block to avoid modifying the original unless confirmed
            var blockCopy = DeepCopy(block); // Assumes Block implements ICloneable or has a Clone method
            var form = new BlockEditForm(blockCopy);
                
            if (form.ShowDialog() == DialogResult.OK)
            {
                Blocks.Remove(block);
                Blocks.Add(form.Content);
            }

            return form.DialogResult == DialogResult.OK;
        }

        public Block? EditBlockAt(int index)
        {
            try
            {
                var block = Blocks[index];
                EditBlock(block);
                return block;
            }
            catch
            {
                return null;
            }
        }
        public Block DeepCopy(Block block)
        {
            var json = JsonSerializer.Serialize(block);
            return JsonSerializer.Deserialize<Block>(json);
        }
    }
}
