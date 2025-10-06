using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent.RelationContent;

namespace Uml_diagram_editor.Model.Relations
{
    public class DependencyRelation : Relation
    {
        private Size PolygonSize { get; set; } = new Size(20, 20);

        public DependencyRelation(Block blockFrom, Block blockTo) : base(blockFrom, blockTo)
        {
        }


        public override void DrawRelation(Graphics g)
        {
            var path = new GraphicsPath();

            // Helper function to offset a point (since Point.Offset is void and mutates in-place)
            var offsetPoint = delegate (Point p, int dx, int dy)
            {
                return new Point(p.X + dx, p.Y + dy);
            };

            var points = _direction switch
            {
                Direction.Left => new[]
                {
                    EndPoint,
                    offsetPoint(EndPoint, PolygonSize.Width, PolygonSize.Height / 2),
                    offsetPoint(EndPoint, PolygonSize.Width, -PolygonSize.Height / 2)
                },
                Direction.Right => new[]
                {
                    EndPoint,
                    offsetPoint(EndPoint, -PolygonSize.Width, PolygonSize.Height / 2),
                    offsetPoint(EndPoint, -PolygonSize.Width, -PolygonSize.Height / 2)
                },
                Direction.Up => new[]
                {
                    EndPoint,
                    offsetPoint(EndPoint, PolygonSize.Height / 2, PolygonSize.Width),
                    offsetPoint(EndPoint, -PolygonSize.Height / 2, PolygonSize.Width)
                },
                Direction.Down => new[]
                {
                    EndPoint,
                    offsetPoint(EndPoint, PolygonSize.Height / 2, -PolygonSize.Width),
                    offsetPoint(EndPoint, -PolygonSize.Height / 2, -PolygonSize.Width)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(_direction), $"Unhandled direction: {_direction}")
            };
            path.AddLine(points[0], points[1]);
            path.AddLine(points[0], points[2]);
            using var pen = new Pen(Palette.PathColor, Palette.PathWidth);
            
            g.DrawPath(pen, path);
            pen.DashStyle = DashStyle.Dash;
            g.DrawPath(pen, _path);
        }

        protected override void DrawGlow(Graphics g)
        {
            // Draw glow effect by drawing the path multiple times with increasing pen width and decreasing alpha
            int glowLayers = 8;
            int baseGlowWidth = 30;

            var path = new GraphicsPath();
            path.AddPath(_path, true);
            for (int i = glowLayers; i > 0; i--)
            {
                int width = baseGlowWidth * i / glowLayers;
                int alpha = 15 * i / glowLayers; // 30 is max alpha for glow
                                                 //implement color to match the main block -> inharitance main block is derived class -> class color(yes next switch:))                   
                using var glowPen = new Pen(Color.FromArgb(alpha, Palette.BlockBackgroundColorActive(BlockFrom.Stereotype)), width)
                {
                    LineJoin = LineJoin.Miter
                };

                g.DrawPath(glowPen, path);
            }
        }
    }
}
