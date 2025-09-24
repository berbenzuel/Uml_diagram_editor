using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.Common;

namespace Uml_diagram_editor.Model
{
    public class Block
    {
        public string Name { get; set; } = string.Empty;
        public List<string>? Attributes { get; set; } //like lists, or just string?
        public List<string>? Methods { get; set; } 

        private int X { get; set; }
        private int Y { get; set; }

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

        public Block(string name, Point point)
        {
            Name = name;
            Location = point;
        }

        public Block() => this.Location = new Point(0,0); 


        public void Draw(Graphics g)
        {
            using var for_brus = IsSelected ? new SolidBrush(Palette.ForegroundColorActive) : new SolidBrush(Palette.ForegroundColor);
            using var bac_brus = IsSelected ? new SolidBrush(Palette.BackgroundColorActive) : new SolidBrush(Palette.BackgroundColor);
            // Draw the block rectangle
            g.DrawRectangle(new Pen(for_brus), Bounds);
            g.FillRectangle(bac_brus, Bounds);
            // Draw the block name
            using (var font = new Font("Comic Sans", 10, FontStyle.Bold))
            {
                var nameSize = g.MeasureString(Name, font);
                g.DrawString(Name, font, for_brus, X + (Width - nameSize.Width) / 2, Y + 5);
            }
            // Draw attributes
            if (Attributes != null && Attributes.Count > 0)
            {
                using (var font = new Font("Comic Sans", 8))
                {
                    float attrY = Y + 25; // Start below the name
                    foreach (var attr in Attributes)
                    {
                        g.DrawString(attr, font, for_brus, X + 5, attrY);
                        attrY += 15; // Move down for the next attribute
                    }
                }
            }
            // Draw methods
            if (Methods != null && Methods.Count > 0)
            {
                using (var font = new Font("Comic Sans", 8))
                {
                    float methodY = Y + 25 + (Attributes?.Count ?? 0) * 15; // Start below attributes
                    foreach (var method in Methods)
                    {
                        g.DrawString(method, font, for_brus, X + 5, methodY);
                        methodY += 15; // Move down for the next method
                    }
                }
            }
        }

        public bool Detect(Point point)
        {
            return this.Bounds.Contains(point);
        }

    }
}
