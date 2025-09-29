using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.DataContent.BlockContent
{
    public class PropertyItem : BlockItem
    {
        public bool IsReadOnly { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(AccessType.AsSymbol());
            sb.Append(' ');
            sb.Append(Name);
            sb.Append(": ");
            sb.Append(Type);
            if(IsReadOnly)
            {
                sb.Append(" {ReadOnly}");
            }
            return sb.ToString();
        }
    }
}
