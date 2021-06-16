using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace YearProgress
{
    public class CircleProgress : Control
    {
        private const int StrokeThickness = 5;
        private readonly Pen _trailPen;
        private readonly Pen _strokePen;
        private readonly float _startAngle = -90;

        // Dark
        // private Brush _trailColor = Brushes.LightGray;
        // private Brush _strokeColor = Brushes.White;

        private Brush _trailColor = Brushes.LightGray;
        private Brush _strokeColor = Brushes.Orange;

        private double _minimum = 0;
        private double _maximum = 100;
        private double _value = 0;
        private string _content;

        public CircleProgress()
        {
            _trailPen = new Pen(TrailColor, StrokeThickness);
            _strokePen = new Pen(StrokeColor, StrokeThickness)
            {
                StartCap = LineCap.Round, 
                EndCap = LineCap.Round
            };

            SizeChanged += (sender, args) =>
            {
                Invalidate();
            };
        }

        public Brush TrailColor
        {
            get => _trailColor;
            set
            {
                _trailColor = value;
                _trailPen.Brush = _trailColor;

                Invalidate();
            }
        }

        public Brush StrokeColor
        {
            get => _strokeColor;
            set
            {
                _strokeColor = value;
                _strokePen.Brush = _strokeColor;
                Invalidate();
            }
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

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
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
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            var size = Math.Min(Width, Height);
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

            g.DrawString(
                _content, 
                new Font(new FontFamily("Microsoft YaHei"),6,FontStyle.Bold),
                _strokeColor, 
                rectangle.X + StrokeThickness * 5 / 4,
                rectangle.Y + StrokeThickness);
        }
    }
}
