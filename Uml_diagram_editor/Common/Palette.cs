using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.Common
{
    public static class Palette
    {
        public static Mode Mode { get; set; } = Mode.Dark;
        

        public static Color BackgroundColor { get
            {
                if (Mode == Mode.Dark) return Color.DarkOrange;
                else return Color.Orange;
            }
        }
        public static Color ForegroundColor
        {
            get
            {
                if (Mode == Mode.Dark) return Color.White;
                else return Color.Black;
            }
        }

        public static Color BackgroundColorActive
        {
            get
            {
                if (Mode == Mode.Dark) return Color.Yellow;
                else return Color.Blue;
            }
        }

        public static Color ForegroundColorActive
        {
            get
            {
                if (Mode == Mode.Dark) return Color.Black;
                else return Color.Black;
            }
        }



    }
}
