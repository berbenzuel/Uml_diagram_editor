using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.DataContent.BlockContent;
using Uml_diagram_editor.DataContent.BlockContent.Methods;

namespace Uml_diagram_editor.DataContent.SavableContent
{
    public record BlockDTO
    {
        public int Identity { get; set; }
        public string Name { get; set; } = string.Empty;
        public Stereotype Stereotype { get; set; }
        public List<PropertyItem> Properties { get; set; } = new();
        public List<MethodItem> Methods { get; set; } = new();

        public bool IsStatic { get; set; } = false;
        public bool IsAbstract { get; set; } = false;

        public Point Point { get; set; }
    }
}
