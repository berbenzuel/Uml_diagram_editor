using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.DataContent.RelationContent;

namespace Uml_diagram_editor.DataContent.SavableContent
{
    public record RelationDTO
    {
        public RelationType RelationType { get; set; }
        public int BlockFromIdentity { get; set; }
        public int BlockToIdentity { get; set; }

        public Cardinal? CardinalFrom { get; set; } = null;
        public Cardinal? CardinalTo { get; set; } = null;
    }
}
