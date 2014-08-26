using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AutoCapture
{
    public class Speedometer : Control
    {
        private const double cMaxSpeed = 100;
        private const int cThickness = 20;
        private double mSpeed;

        public Speedometer()
        {
            DoubleBuffered = true;
        }

        [DefaultValue(0.0)]
        public double Speed
        {
            get { return mSpeed; }
            set { mSpeed = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int size = Math.Min(this.ClientSize.Width, this.ClientSize.Height) - cThickness;
            if (size <= cThickness) return;
            float angle = (float)(270 * mSpeed / cMaxSpeed);
            angle = Math.Max(0, Math.Min(270, angle));
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(Color.White, cThickness))
            {
                e.Graphics.DrawArc(p, cThickness / 2, cThickness / 2, size, size, 135, 270);
            }
            using (Pen p = new Pen(Color.Red, cThickness))
            {
                p.Alignment = PenAlignment.Inset;
                e.Graphics.DrawArc(p, cThickness / 2, cThickness / 2, size, size, 135, angle);
            }
            base.OnPaint(e);
        }
    }
}
