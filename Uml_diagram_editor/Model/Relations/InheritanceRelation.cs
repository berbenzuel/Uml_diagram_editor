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
    internal class InheritanceRelation : Relation, ICardinal
    {
        public Cardinal FromCardinal { get; set; } = default;
        public Cardinal ToCardinal { get; set; } = default;

        private Size PolygonSize { get; set; } = new Size(20, 20);

        public InheritanceRelation(Block blockFrom, Block blockTo) : base(blockFrom, blockTo)
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
                    offsetPoint(EndPoint, -PolygonSize.Width, 0),
                    offsetPoint(EndPoint, 0, PolygonSize.Height / 2),
                    offsetPoint(EndPoint, 0, -PolygonSize.Height / 2)
                },
                Direction.Right => new[]
                {
                    offsetPoint(EndPoint, PolygonSize.Width, 0),
                    offsetPoint(EndPoint, 0, PolygonSize.Height / 2),
                    offsetPoint(EndPoint, 0, -PolygonSize.Height / 2)
                },
                Direction.Up => new[]
                {
                    offsetPoint(EndPoint, 0, -PolygonSize.Width),
                    offsetPoint(EndPoint, PolygonSize.Height / 2, 0),
                    offsetPoint(EndPoint, -PolygonSize.Height / 2, 0)
                },
                Direction.Down => new[]
                {
                    offsetPoint(EndPoint, 0, PolygonSize.Width),
                    offsetPoint(EndPoint, PolygonSize.Height / 2, 0),
                    offsetPoint(EndPoint, -PolygonSize.Height / 2, 0)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(_direction), $"Unhandled direction: {_direction}")
            };

            path.AddPolygon(points);
            using var pen = new Pen(Palette.PathColor, Palette.PathWidth);

            g.DrawPath(pen, path);
            g.DrawPath(pen, _path);

            DrawCardinals(g);
        }

        protected override void CalculatePoints()
        {
            base.CalculatePoints();
            EndPoint = _direction switch
            {
                Direction.Left => new Point(EndPoint.X +PolygonSize.Width, EndPoint.Y),
                Direction.Right => new Point(EndPoint.X - PolygonSize.Width, EndPoint.Y),
                Direction.Up => new Point(EndPoint.X, EndPoint.Y + PolygonSize.Width),
                Direction.Down => new Point(EndPoint.X, EndPoint.Y - PolygonSize.Width),
            };
        }

        protected override void DrawGlow(Graphics g)
        {
            // Draw glow effect by drawing the path multiple times with increasing pen width and decreasing alpha
            int glowLayers = 8;
            int baseGlowWidth = 30;
            Point[] points = _direction switch
            {
                Direction.Left => [EndPoint, new Point(EndPoint.X - PolygonSize.Width, EndPoint.Y)],
                Direction.Right => [EndPoint, new Point(EndPoint.X + PolygonSize.Width, EndPoint.Y)],
                Direction.Up => [EndPoint, new Point(EndPoint.X, EndPoint.Y - PolygonSize.Width)],
                Direction.Down => [EndPoint, new Point(EndPoint.X, EndPoint.Y + PolygonSize.Width)],
            };

            var path = new GraphicsPath();
            path.AddPath(_path, true);
            path.AddLine(points[1], points[0]);
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
        public void DrawCardinals(Graphics g)
        {
            var brush = new SolidBrush(Palette.BlockForegroundColor);

            var modificatorX = 10;
            var modificatorY = 10;

            var fromTextSize = g.MeasureString(this.FromCardinal.ToSymbol(), Palette.DefaultFont);
            var toTextSize = g.MeasureString(this.ToCardinal.ToSymbol(), Palette.DefaultFont);

            var fromPoint = _direction switch
            {
                Direction.Left => new Point(StartPoint.X - modificatorX - (int)fromTextSize.Width, StartPoint.Y + modificatorY),
                Direction.Right => new Point(StartPoint.X + modificatorX, StartPoint.Y + modificatorY),
                Direction.Up => new Point(StartPoint.X + modificatorY, StartPoint.Y - modificatorX - (int)fromTextSize.Height),
                Direction.Down => new Point(StartPoint.X + modificatorY, StartPoint.Y + modificatorX),
            };

            var toPoint = _direction switch
            {
                Direction.Left => new Point(EndPoint.X + modificatorX, EndPoint.Y + modificatorY),
                Direction.Right => new Point(EndPoint.X - modificatorX - (int)toTextSize.Width, EndPoint.Y + modificatorY),
                Direction.Up => new Point(EndPoint.X + modificatorY, EndPoint.Y + modificatorX),
                Direction.Down => new Point(EndPoint.X + modificatorY, EndPoint.Y - modificatorX - (int)toTextSize.Height),
            };

            g.DrawString(this.FromCardinal.ToSymbol(), Palette.DefaultFont, brush, fromPoint);
            g.DrawString(this.ToCardinal.ToSymbol(), Palette.DefaultFont, brush, toPoint);
        }

    }
}
