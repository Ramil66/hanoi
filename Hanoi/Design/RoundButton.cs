using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Курсовая.Design
{
    public class RoundButton : Button
    {
        private StringFormat SF = new StringFormat();
        private bool mousePressed = false;
        public Color colorPen;
        [Description("Цвет краев:")]
        public Color ColorPen
        {
            get => colorPen;
            set
            {
                colorPen = value;
                Refresh();
            }
        }

        public bool roundingEnable = false;
        [DisplayName("Закругление кнопки")]
        [Description("Закругление кнопки")]
        public bool RoundingEnable
        {
            get => roundingEnable;
            set
            {
                roundingEnable = value;
                Refresh();
            }
        }

        private int rounding = 100;
        [DisplayName("Процент закругления:")]
        [DefaultValue(100)]
        [Description("Радиус закругления:")]
        public int Rounding
        {
            get => rounding;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    rounding = value;
                    Refresh();
                }
            }

        }
        public RoundButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(Width, Height);
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            //Закругление
            float roundingValue = 0.1F;
            if (RoundingEnable && rounding > 0)
            {
                roundingValue = Height / 100F * rounding;
            }
            GraphicsPath rectPath = Drawer.RoundedRectangle(rect, roundingValue);
            graph.DrawPath(new Pen(colorPen), rectPath);
            graph.FillPath(new SolidBrush(BackColor), rectPath);
            graph.SetClip(rectPath);

            graph.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
            if (mousePressed)
            {
                graph.DrawRectangle(new Pen(Color.FromArgb(30, Color.Black)), rect);
                graph.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mousePressed = true;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mousePressed = false;
            Invalidate();
        }
    }
}
