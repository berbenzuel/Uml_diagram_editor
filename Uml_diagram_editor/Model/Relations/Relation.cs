using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent.RelationContent;

namespace Uml_diagram_editor.Model.Relations
{
    public abstract class Relation : DrawableItem
    {
        public Block BlockFrom{ get; set; } //always the main
        public Block BlockTo { get; set; }


        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        protected GraphicsPath _path { get; set; }

        protected Direction _direction;

        public Relation(Block blockFrom, Block blockTo)
        {
            BlockFrom = blockFrom;
            BlockTo = blockTo;
        }

        override public void Draw(Graphics g, int gridSize)
        {
            CalculatePoints();
            CalculatePath();

            if (IsSelected)
            {
                DrawGlow(g);
            }

            DrawRelation(g);
        }

        protected virtual void DrawGlow(Graphics g)
        {
            // Draw glow effect by drawing the path multiple times with increasing pen width and decreasing alpha
            int glowLayers = 8;
            int baseGlowWidth = 30;
            for (int i = glowLayers; i > 0; i--)
            {
                int width = baseGlowWidth * i / glowLayers;
                int alpha = 15 * i / glowLayers; // 30 is max alpha for glow
                                                 //implement color to match the main block -> inharitance main block is derived class -> class color(yes next switch:))                   
                using var glowPen = new Pen(Color.FromArgb(alpha, Palette.BlockBackgroundColorActive(BlockFrom.Stereotype)), width)
                {
                    LineJoin = LineJoin.Round
                };
                g.DrawPath(glowPen, _path);
            }
        }

        public virtual void DrawRelation(Graphics g) 
        {
            g.DrawPath(new Pen(Palette.BlockForegroundColor, Palette.PathWidth), _path);
        }

        protected virtual void CalculatePoints()
        {
            var deltaX = BlockFrom.Location.X - BlockTo.Location.X;
            var deltaY = BlockFrom.Location.Y - BlockTo.Location.Y;
            
            if (Math.Abs(deltaX) > Math.Abs(deltaY)) //left or right
            {
                if (deltaX > 0) //left
                {
                    _direction = Direction.Left;
                    StartPoint = new Point(BlockFrom.Location.X, BlockFrom.Location.Y + BlockFrom.Height / 2);
                    EndPoint = new Point(BlockTo.Location.X + BlockTo.Width, BlockTo.Location.Y + BlockTo.Height / 2);
                }
                else //right
                {
                    _direction = Direction.Right;
                    StartPoint = new Point(BlockFrom.Location.X + BlockFrom.Width, BlockFrom.Location.Y + BlockFrom.Height / 2);
                    EndPoint = new Point(BlockTo.Location.X, BlockTo.Location.Y + BlockTo.Height / 2);
                }
            }
            else //up or down
            {
                if (deltaY > 0) //up
                {
                    _direction = Direction.Up;
                    StartPoint = new Point(BlockFrom.Location.X + BlockFrom.Width / 2, BlockFrom.Location.Y);
                    EndPoint = new Point(BlockTo.Location.X + BlockTo.Width / 2, BlockTo.Location.Y + BlockTo.Height);
                }
                else //down
                {
                    _direction = Direction.Down;
                    StartPoint = new Point(BlockFrom.Location.X + BlockFrom.Width / 2, BlockFrom.Location.Y + BlockFrom.Height);
                    EndPoint = new Point(BlockTo.Location.X + BlockTo.Width / 2, BlockTo.Location.Y);
                }
            }
        }

        protected void CalculatePath()
        {
            var path = new GraphicsPath();

            var controlFirst = _direction switch
            {
                Direction.Left => new Point(EndPoint.X, StartPoint.Y),
                Direction.Right => new Point(EndPoint.X, StartPoint.Y),
                Direction.Up => new Point(StartPoint.X, EndPoint.Y),
                Direction.Down => new Point(StartPoint.X, EndPoint.Y),
                _ => throw new Exception(),
            };
            var controlSecond = _direction switch
            {
                Direction.Left => new Point(StartPoint.X, EndPoint.Y),
                Direction.Right => new Point(StartPoint.X, EndPoint.Y),
                Direction.Up => new Point(EndPoint.X, StartPoint.Y),
                Direction.Down => new Point(EndPoint.X, StartPoint.Y),
                _ => throw new Exception(),
            };
            
            path.AddBezier(StartPoint, controlFirst, controlSecond, EndPoint);
            _path = path;
            Bounds = Rectangle.Ceiling(path.GetBounds());
        }

        public override bool Detect(Point point)
        {
            if (!Bounds.Contains(point))
            {
                return false;
            }

            return _path.IsOutlineVisible(point, new Pen(Palette.BlockForegroundColor, Palette.PathWidth));
            
        }
    }
}
