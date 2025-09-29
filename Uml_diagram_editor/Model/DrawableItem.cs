using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.Model
{
    public abstract class DrawableItem
    {
        protected int X { get; set; }
        protected int Y { get; set; }

        public Point Location
        {
            get => new Point(X, Y);
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public int Width { get; set; } = 100;
        public int Height { get; set; } = 100;

        public bool IsSelected { get; set; } = false;

        public Rectangle Bounds => new Rectangle(X, Y, Width, Height);


    }
}
