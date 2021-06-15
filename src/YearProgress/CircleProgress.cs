using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YearProgress
{
    public class CircleProgress : Control
    {
        private const int StrokeThickness = 5;
        private readonly Pen _trailPen;
        private readonly Pen _strokePen;
        private readonly Brush _trailColor = Brushes.LightGray;
        private readonly Brush _strokeColor = Brushes.Orange;
        private readonly float _startAngle = -90;

        private double _minimum = 0;
        private double _maximum = 100;
        private double _value = 0;

        public CircleProgress()
        {
            _trailPen = new Pen(_trailColor, StrokeThickness);
            _strokePen = new Pen(_strokeColor, StrokeThickness)
            {
                StartCap = LineCap.Round, 
                EndCap = LineCap.Round
            };

            SizeChanged += (sender, args) =>
            {
                Invalidate();
            };
        }

        public double Minimum
        {
            get => _minimum;
            set
            {
                if (value < _value)
                {
                    return;
                }

                _minimum = value;
                Invalidate();
            }
        }
        public double Maximum
        {
            get => _maximum;
            set
            {
                if (value < _value)
                {
                    return;
                }

                _maximum = value;
                Invalidate();
            }
        }
        public double Value
        {
            get => _value;
            set
            {
                if (value > _maximum)
                {
                    return;
                }
                _value = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawShape(e.Graphics);
        }

        private void DrawShape(Graphics g)
        {
            if(Width == 0 || Height == 0)
                return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int size = Math.Min(Width, Height);
            var leftStartPoint = new Point
            {
                Y = StrokeThickness / 2, 
                X = StrokeThickness / 2
            };

            var len = size - StrokeThickness;
            var rectSize = new Size(len, len);
            var rectangle = new Rectangle(leftStartPoint,rectSize);
            var angle = (float) (_value / _maximum * 359.99);

            g.DrawArc(_trailPen, rectangle, 0, 360);
            g.DrawArc(_strokePen, rectangle, _startAngle, angle);
        }
    }
}
