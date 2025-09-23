using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.Common
{
    internal static class Grid
    {
        public static void Draw(Graphics g, Rectangle area, int gridSize)
        {
            using (var pen = new Pen(Color.LightGray))
            {
                for (int y = 0; y < area.Height; y += gridSize)
                {
                    for (int x = 0; x < area.Width; x += gridSize)
                    {
                        g.FillEllipse(new SolidBrush(Color.Red), x, y, 2, 2);
                    }
                    
                }
            }
        }

        public static Point Snap(Point point, int gridSize)
        {
            int x = (point.X / gridSize) * gridSize;
            int y = (point.Y / gridSize) * gridSize;
            return new Point(x, y);
        }

    }
}
