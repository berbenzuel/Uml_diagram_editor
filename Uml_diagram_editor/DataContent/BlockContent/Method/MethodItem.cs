using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.DataContent.BlockContent.Methods
{
    public class MethodItem: BlockItem
    {
        public BindingList<MethodAttribute> Attributes { get; set; } = new();
        public override string ToString()
        {
            return $"{AccessType.AsSymbol()} {Name}({string.Join(", ", Attributes)}): {Type}";
        }
        
    }
}
