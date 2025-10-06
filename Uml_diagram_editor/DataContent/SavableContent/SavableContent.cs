using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.DataContent.SavableContent
{
    public record SavableContent
    {
        public List<BlockDTO> Blocks { get; set; }
        public List<RelationDTO> Relations { get; set; }
    }
}
