using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.DataContent.RelationContent;

namespace Uml_diagram_editor.Model.Relations
{
    public interface ICardinal
    {
        Cardinal FromCardinal {  get; set; }
        Cardinal ToCardinal { get; set; }

        void DrawCardinals(Graphics g);
    }
}
