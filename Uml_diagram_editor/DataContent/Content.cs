using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.Model;
using Uml_diagram_editor.Model.Relations;

namespace Uml_diagram_editor.DataContent
{
    public class Content
    {
        public List<Block> Blocks { get; set; } = new();
        public List<Relation> Relations { get; set; } = new();
    }
}
