using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.Common
{
    internal class Grid
    {
        public int GridSize { get; set; }

        public Grid(int gridSize) 
        {
            GridSize = gridSize;
        }
        public void Draw(Graphics g, Rectangle area, Point offset, float zoom)
        {
            using (var pen = new Pen(Color.LightGray))
            {
                var rect = area;
                var deltaX = offset.X - offset.X % GridSize;
                var deltaY = offset.Y - offset.Y % GridSize;

                rect.X -= deltaX;
                rect.Y -= deltaY;

                for (int y = 0; y < rect.Height /zoom; y += GridSize)
                {
                    for (int x = 0; x < rect.Width / zoom; x += GridSize)
                    {
                        g.FillRectangle(new SolidBrush(Color.DarkGray), x + rect.X, y + rect.Y, 2, 2);
                    }   
                }
            }
        }

        public Point Snap(Point point)
        {
            int x = (point.X / GridSize) * GridSize;
            int y = (point.Y / GridSize) * GridSize;
            return new Point(x, y);
        }

    }
}
