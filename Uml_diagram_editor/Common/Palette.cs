using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.DataContent.BlockContent;

namespace Uml_diagram_editor.Common
{
    public static class Palette
    {
       public static Color Background => Color.FromKnownColor(KnownColor.Control);
        public static Color BlockBackgroundColor(Stereotype stereotype)
        {
            switch(stereotype) 
            {
                case Stereotype.Default:
                    return Color.LightGray;
                case Stereotype.Interface:
                    return Color.LightYellow;
                case Stereotype.Enum:
                    return Color.LightGreen;
                case Stereotype.Struct:
                    return Color.LightCyan;
                case Stereotype.Delegate:
                    return Color.LightSalmon;
                case Stereotype.Record:
                    return Color.LightCoral;
                case Stereotype.Class:
                    return Color.LightPink;
                default:
                    return Color.White;
            }
        }
        public static Color BlockForegroundColor => Color.Black;

        public static Color BlockBackgroundColorActive(Stereotype stereotype)
        {
            switch (stereotype)
            {
                case Stereotype.Default:
                    return Color.Gray;
                case Stereotype.Interface:
                    return Color.Gold;
                case Stereotype.Enum:
                    return Color.Green;
                case Stereotype.Struct:
                    return Color.Cyan;
                case Stereotype.Delegate:
                    return Color.OrangeRed;
                case Stereotype.Record:
                    return Color.Red;
                case Stereotype.Class:
                    return Color.DeepPink;
                default:
                    return Color.DarkGray;
            }
        }

        public static Font DefaultFont => new Font("Comic Sans MS", 8);


        public static int PathWidth => 3;
        public static Color PathColor => Color.Black;
        public static Color PathColorActive => Color.LightPink;
        



    }
}
