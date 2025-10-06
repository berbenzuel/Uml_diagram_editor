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
    internal class AggregationRelation : Relation, ICardinal
    {
        public Cardinal FromCardinal { get; set; } = default;
        public Cardinal ToCardinal { get; set; } = default;

        private Size PolygonSize { get; set; } = new Size(40, 20);

        public AggregationRelation(Block blockFrom, Block blockTo) : base(blockFrom, blockTo)
        {
        }

        public override void DrawRelation(Graphics g)
        {
            var path = new GraphicsPath();

            // Helper function to offset a point (since Point.Offset is void and mutates in-place)
            static Point OffsetPoint(Point p, int dx, int dy) => new Point(p.X + dx, p.Y + dy);

            var points = _direction switch
            {
                Direction.Left => new[]
                {
                    StartPoint,
                    OffsetPoint(StartPoint, PolygonSize.Width / 2, PolygonSize.Height / 2),
                    OffsetPoint(StartPoint, PolygonSize.Width, 0),
                    OffsetPoint(StartPoint, PolygonSize.Width / 2, -PolygonSize.Height / 2)
                },
                Direction.Right => new[]
                {
                    StartPoint,
                    OffsetPoint(StartPoint, -PolygonSize.Width / 2, PolygonSize.Height / 2),
                    OffsetPoint(StartPoint, -PolygonSize.Width, 0),
                    OffsetPoint(StartPoint, -PolygonSize.Width / 2, -PolygonSize.Height / 2)
                },
                Direction.Up => new[]
                {
                    StartPoint,
                    OffsetPoint(StartPoint, PolygonSize.Height / 2, PolygonSize.Width / 2),
                    OffsetPoint(StartPoint, 0, PolygonSize.Width),
                    OffsetPoint(StartPoint, -PolygonSize.Height / 2, PolygonSize.Width / 2)
                },
                Direction.Down => new[]
                {
                    StartPoint,
                    OffsetPoint(StartPoint, PolygonSize.Height / 2, -PolygonSize.Width / 2),
                    OffsetPoint(StartPoint, 0, -PolygonSize.Width),
                    OffsetPoint(StartPoint, -PolygonSize.Height / 2, -PolygonSize.Width / 2)
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
            StartPoint = _direction switch
            {
                Direction.Left => new Point(StartPoint.X - PolygonSize.Width, StartPoint.Y),
                Direction.Right => new Point(StartPoint.X + PolygonSize.Width, StartPoint.Y),
                Direction.Up => new Point(StartPoint.X, StartPoint.Y - PolygonSize.Width),
                Direction.Down => new Point(StartPoint.X,StartPoint.Y + PolygonSize.Width),
            };
        }

        protected override void DrawGlow(Graphics g)
        {
            // Draw glow effect by drawing the path multiple times with increasing pen width and decreasing alpha
            int glowLayers = 8;
            int baseGlowWidth = 30;
            Point[] points = _direction switch
            {
                Direction.Left => [StartPoint, new Point(StartPoint.X + PolygonSize.Width, StartPoint.Y)],
                Direction.Right => [StartPoint, new Point(StartPoint.X - PolygonSize.Width, StartPoint.Y)],
                Direction.Up => [StartPoint, new Point(StartPoint.X, StartPoint.Y + PolygonSize.Width)],
                Direction.Down => [StartPoint, new Point(StartPoint.X, StartPoint.Y - PolygonSize.Width)],
            };

            var path = new GraphicsPath();
            path.AddLine(points[0], points[1]);
            path.AddPath(_path, true);
            for (int i = glowLayers; i > 0; i--)
            {
                int width = baseGlowWidth * i / glowLayers;
                int alpha = 15 * i / glowLayers; // 30 is max alpha for glow
                                                 //implement color to match the main block -> inharitance main block is derived class -> class color(yes next switch:))                   
                using var glowPen = new Pen(Color.FromArgb(alpha, Palette.BlockBackgroundColorActive(BlockFrom.Stereotype)), width)
                {
                    LineJoin = LineJoin.Round
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
