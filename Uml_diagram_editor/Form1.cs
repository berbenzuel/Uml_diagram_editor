using System;
using System.Drawing;
using Uml_diagram_editor.Common;
using Uml_diagram_editor.DataContent;
using Uml_diagram_editor.DataContent.BlockContent;
using Uml_diagram_editor.DataContent.BlockContent.Method;
using Uml_diagram_editor.DataContent.BlockContent.Methods;
using Uml_diagram_editor.Managers;
using Uml_diagram_editor.Model;

namespace Uml_diagram_editor
{
    public partial class Form1 : Form
    {


        private BlockManager blockManager { get; set; }

        private int? _selectedBlockIndex { get; set; }

        private Point _picBoxMousePosition { get; set; }
        private Point _pictureBoxAbsolutePoint = new Point(0, 0);

        private Grid? grid = null;
        private const int gridSize = 10;


        public Form1()
        {
            InitializeComponent();




            blockManager = new BlockManager();
            blockManager.Blocks.Add(new("MyClass", new Point(0, 0))
            {
                Stereotype = null,
                Properties = new() { new()
                {
                    AccessType = AccessType.Public,
                    Name = "Foo",
                    Type = "string"
                } },
                Methods = new()
                {
                    new MethodItem()
                    {
                        AccessType = AccessType.Public,
                        Name = "Bar",
                        Type = "void",
                        Attributes = new() {
                            new MethodAttribute() {
                            Name ="foo",
                            Type = "bar",
                            AttributeType = MethodAttributeType.In}
                        }
                    }
                }
            });
        }

        private void InvalidateWithOffset(Rectangle bounds)
        {
            var rect = new Rectangle(bounds.Location, bounds.Size);
            rect.X += _pictureBoxAbsolutePoint.X;
            rect.Y += _pictureBoxAbsolutePoint.Y;

            pictureBox1.Invalidate(rect, true);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //quite unoptimized, use bitmap maybe into picture box?
            var g = e.Graphics;

            var zoom = (float)zoomTrackBar.Value / 100;
            g.ScaleTransform(zoom, zoom);
            //posunuti boud na zaklade zvetseni podle pozici mysi
            g.TranslateTransform(_pictureBoxAbsolutePoint.X, _pictureBoxAbsolutePoint.Y);

            
            
            if (grid is not null)
            {
                grid.Draw(g, pictureBox1.ClientRectangle, _pictureBoxAbsolutePoint, zoom);
            }
            foreach (var block in blockManager.Blocks)
            {
                block.Draw(g, gridSize);
            }


        }

        private Point GetRelative(Point point)
        {

            return new Point((int)(point.X - _pictureBoxAbsolutePoint.X ), (int)(point.Y - _pictureBoxAbsolutePoint.Y));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var detected = false;
                for (var block_index = blockManager.Blocks.Count - 1; block_index >= 0; block_index--)
                {
                    var zoom = (float)zoomTrackBar.Value / 100;
                    var block = blockManager.Blocks[block_index];
                    if (!detected && block.Detect(GetRelative(e.Location)))
                    {
                        _selectedBlockIndex = block_index;
                        block.IsSelected = true;
                        detected = true;
                        InvalidateWithOffset(block.Bounds);
                    }
                    else
                    {
                        if (block.IsSelected)
                        {
                            block.IsSelected = false;
                            InvalidateWithOffset(block.Bounds);
                        }

                    }
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                var screenPoint = pictureBox1.PointToScreen(e.Location);
                contextMenuStrip1.Show(screenPoint);
            }
            if (e.Button == MouseButtons.Middle)
            {

            }
            _picBoxMousePosition = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left &&
                _selectedBlockIndex is int index &&
                blockManager.Blocks.ElementAtOrDefault(Index.FromStart(index)) is Block block &&
                block.IsSelected &&
                block.Detect(GetRelative(e.Location)))
            {
                var oldBounds = block.Bounds;
                oldBounds.Inflate(5, 5);
                block.Location = new Point((int)(e.X - _pictureBoxAbsolutePoint.X - block.Width /2), (int)(e.Y - _pictureBoxAbsolutePoint.Y - block.Height/2));
                InvalidateWithOffset(oldBounds);
                InvalidateWithOffset(block.Bounds);
            }
            if (e.Button == MouseButtons.Middle)
            {


                var _deltaX = (e.Location.X - _picBoxMousePosition.X);
                var _deltaY = (e.Location.Y - _picBoxMousePosition.Y);
                var point = new Point(_pictureBoxAbsolutePoint.X + (int)_deltaX, _pictureBoxAbsolutePoint.Y + (int)_deltaY);
                _pictureBoxAbsolutePoint = point;
                _picBoxMousePosition = e.Location;
                Invalidate(Region, true);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var grid = this.checkBox1.Checked ? new Grid(gridSize) : null;
            this.grid = grid;
            pictureBox1.Invalidate(true);
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (grid is not null &&
                _selectedBlockIndex is int index &&
                blockManager.Blocks.ElementAtOrDefault(Index.FromStart(index)) is Block block)
            {
                block.Location = grid.Snap(block.Location);
                Invalidate(true);
            }
        }

        private void AddBlock(object sender, EventArgs e)
        {
            var point = _picBoxMousePosition;
            point.Offset(-_pictureBoxAbsolutePoint.X, -_pictureBoxAbsolutePoint.Y);
            var block = blockManager.AddBlock(point);
            if (block is not null)
            {
                InvalidateWithOffset(block.Bounds);
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var detected = false;
            for (var block_index = blockManager.Blocks.Count - 1; block_index >= 0; block_index--)
            {
                var block = blockManager.Blocks[block_index];
                if (!detected && block.Detect(GetRelative(e.Location)))
                {
                    block.IsSelected = true;
                    _selectedBlockIndex = block_index;
                    if (blockManager.EditBlock(block))
                    {
                        Invalidate(true);
                    }
                    detected = true;
                }
                else
                {
                    block.IsSelected = false;
                }
            }
            Invalidate();
        }



        private void deleteBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedBlockIndex is int index)
            {
                blockManager.Blocks.RemoveAt(index);
                _selectedBlockIndex = null;
                pictureBox1.Invalidate(true);
            }
        }

        private void editBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedBlockIndex is int index)
            {
                var block = blockManager.EditBlockAt(index);
                if (block is not null)
                {
                    Invalidate(true); //implement func for offcet
                }

            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate(true);
        }
    }
}
