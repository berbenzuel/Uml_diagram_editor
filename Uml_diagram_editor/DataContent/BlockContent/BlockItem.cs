using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.DataContent.BlockContent
{
    public abstract class BlockItem
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsStatic { get; set; } = false;
        public bool IsAbstract { get; set; } = false;
        public AccessType AccessType { get; set; } = AccessType.Public;

        public abstract override string ToString();
    }
}
