using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent.BlockContent;
using Uml_diagram_editor.DataContent.BlockContent.Methods;

namespace Uml_diagram_editor.Model
{
    public sealed class Block : DrawableItem
    {
        public string Name { get; set; } = string.Empty;
        public Stereotype? Stereotype { get; set; }
        public  BindingList<PropertyItem> Properties { get; set; } = new();
        public BindingList<MethodItem> Methods { get; set; } = new();

        public bool IsStatic { get; set; } = false;
        public bool IsAbstract { get; set; } = false;


       
        private const int _padding = 5;
        private const int _fontSize = 8;
        private const int _nameFontSize = 10;
        private const string _fontFamily = "Comic Sans MS";
        private const int _lineWidth = 2;


        private Font _font = Palette.DefaultFont;

        private int _defaultLineHeight = TextRenderer.MeasureText("Foo", Palette.DefaultFont).Height;

        public Block(string name, Point point)
        {
            Name = name;
            Location = point;
        }

        public Block(Point point) => this.Location = point; 

        public Block() { }
        

        public void Draw(Graphics g, int gridSize)
        {
            using var for_brus = IsSelected ? new SolidBrush(Palette.ForegroundColorActive) : new SolidBrush(Palette.ForegroundColor);
            using var bac_brus = IsSelected ? new SolidBrush(Palette.BackgroundColorActive) : new SolidBrush(Palette.BackgroundColor);

            //using var nameFont = new Font(_fontFamily, _nameFontSize);
            var _lineHeight = g.MeasureString("Foo", _font).Height;


            var bounds = CalculateBlockArea(_lineHeight, gridSize);
            this.Width = (int)bounds.Width;
            this.Height = (int)bounds.Height;

            

            // Draw background
            g.FillRectangle(bac_brus, bounds);
            
            float actualY = Y + _padding;
            if (Stereotype is { } st && st != DataContent.BlockContent.Stereotype.Default)
            {
                var _lineAnnotation = g.MeasureString($"<<{Stereotype}>>", _font);
                var font = GetFont(IsStatic, IsAbstract);
                g.DrawString($"<<{Stereotype}>>", font, for_brus,X + (bounds.Width - _lineAnnotation.Width)/2 , actualY); // Draw annotation at the top with padding
                actualY += _defaultLineHeight; // Move down for the name
                //actualY += _padding; // Additional padding before the name
                //actualY += _padding; // Additional padding after the line
            }

            g.DrawString(Name, new Font(_font, FontStyle.Bold), for_brus, X + _padding, actualY);
            actualY += _defaultLineHeight; // Move down for the attributes
            actualY += _padding; // Additional padding before the attributes
            if(Properties.Any())
            {
                DrawLine(g, actualY, for_brus); // Line above the attributes
                actualY += _lineWidth; // Move down after the line
                DrawContentFromEnumerable(g, Properties.Select(p => p.ToString()), ref actualY, for_brus, _font);
                actualY += _padding; // Additional padding after the attributes
            }
            if(Methods.Any())
            {
                DrawLine(g, actualY, for_brus); // Line above the methods
                actualY += _lineWidth; // Move down after the line
                DrawContentFromEnumerable(g, Methods.Select(m => m.ToString()), ref actualY, for_brus, _font);
                actualY += _padding; // Additional padding after the methods
            }

        }

        private Font GetFont(bool isStatic, bool isAbstract)
        {
            FontStyle style = FontStyle.Regular;
            if (isStatic) style |= FontStyle.Underline;
            if (isAbstract) style |= FontStyle.Italic;
            return new Font(_fontFamily, _fontSize, style);
        }

        private void DrawLine(Graphics g, float y, Brush brush)
        {
            g.DrawLine(new Pen(brush, _lineWidth), X, y, X + Width, y);
        }


        private RectangleF CalculateBlockArea(float _lineheight, int gridSize)
        {
            var rect = new RectangleF(X, Y, 0,0);

            rect.Height += _padding; // Top padding

            if (Stereotype is { } st && st != DataContent.BlockContent.Stereotype.Default )
            {
                rect.Height += _defaultLineHeight; // Move down for the name
            }
            rect.Height += _lineheight; // Height of the annotation;
            rect.Height += _padding; // Space for the name
            if (Properties.Any())
            {
                rect.Height += _lineWidth; // Space for a line between attributes and methods
                rect.Height += Properties.Count * (_lineheight); // Space for attributes
                rect.Height += _padding;
            }
            
            if (Methods.Any())
            {
                rect.Height += _lineWidth; // Space for a line between attributes and methods
                rect.Height += Methods.Count * (_lineheight); // Space for methods
                rect.Height += _padding;
            }

            var widths = (IEnumerable<int>)[TextRenderer.MeasureText(Name, _font).Width,
                TextRenderer.MeasureText(Stereotype.ToString(), _font).Width, 
                Properties.Any() ? Properties.Max(p => TextRenderer.MeasureText(p.ToString(), _font).Width) : 0,
                Methods.Any() ? Methods.Max(m => TextRenderer.MeasureText(m.ToString(), _font).Width) : 0];
            rect.Width = widths.Max();
            rect.Width += _padding*2;

            rect.Width = (float)(Math.Ceiling(rect.Width / gridSize) * gridSize);
            rect.Height = (float)(Math.Ceiling(rect.Height / gridSize) * gridSize);
            return rect;
        }


        private void DrawContentFromEnumerable(Graphics g, IEnumerable<string> items, ref float currentY, Brush brush, Font font)
        {

            foreach (var item in items)
            {
                g.DrawString(item, font, brush, X + _padding, currentY);
                currentY += g.MeasureString(item, font).Height; // Move down for the next item
            }
        }

        public bool Detect(Point point)
        {
            return this.Bounds.Contains(point);
        }

        

    }
}
