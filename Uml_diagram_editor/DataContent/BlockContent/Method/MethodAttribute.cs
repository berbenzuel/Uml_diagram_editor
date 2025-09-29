using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.DataContent.BlockContent.Method;

namespace Uml_diagram_editor.DataContent.BlockContent.Methods
{
    public class MethodAttribute
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public MethodAttributeType AttributeType { get; set; }
        
        public override string ToString()
        {
            return $"{AttributeType.ToString().ToLower()} {Name}: {Type}";
        }
    }
}
