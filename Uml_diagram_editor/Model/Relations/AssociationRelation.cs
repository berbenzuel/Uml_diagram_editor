using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent.RelationContent;

namespace Uml_diagram_editor.Model.Relations
{
    internal class AssociationRelation : Relation, ICardinal
    {
        public Cardinal FromCardinal { get; set; } = default;
        public Cardinal ToCardinal { get; set; } = default;
        public AssociationRelation(Block blockFrom, Block blockTo) : base(blockFrom, blockTo)
        {
        }

        public override void DrawRelation(Graphics g)
        {
            base.DrawRelation(g);
            DrawCardinals(g);
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
                Direction.Left => new Point(StartPoint.X - modificatorX - (int)fromTextSize.Width, StartPoint.Y + modificatorY ),
                Direction.Right => new Point(StartPoint.X + modificatorX, StartPoint.Y + modificatorY),
                Direction.Up => new Point(StartPoint.X + modificatorY, StartPoint.Y - modificatorX -(int)fromTextSize.Height),
                Direction.Down => new Point(StartPoint.X + modificatorY, StartPoint.Y + modificatorX),
            };

            var toPoint = _direction switch
            {
                Direction.Left => new Point(EndPoint.X + modificatorX , EndPoint.Y + modificatorY),
                Direction.Right => new Point(EndPoint.X - modificatorX - (int)toTextSize.Width, EndPoint.Y + modificatorY),
                Direction.Up => new Point(EndPoint.X + modificatorY, EndPoint.Y + modificatorX),
                Direction.Down => new Point(EndPoint.X + modificatorY, EndPoint.Y - modificatorX - (int)toTextSize.Height),
            };

            g.DrawString(this.FromCardinal.ToSymbol(), Palette.DefaultFont, brush, fromPoint);
            g.DrawString(this.ToCardinal.ToSymbol(), Palette.DefaultFont, brush, toPoint);
        }
    }

        
}
