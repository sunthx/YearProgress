using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YearProgress
{
    /// <summary>
    /// Interaction logic for CircleProgressBar.xaml
    /// </summary>
    public partial class CircleProgressBar : UserControl
    {
        private const int _minValue = 0;
        private const int _maxValue = 100;
        private const double _maxAngle = 359.999;

        private readonly int _viewWidth = 35;
        private readonly int _viewHeight = 35;
        private const int _strokeWidth = 5;

        private readonly int _radial = 0;

        private readonly double _centerPositionX = 0;
        private readonly double _centerPositionY = 0;

        private readonly double _startPositionX = 0;
        private readonly double _startPositionY = 0;
        public CircleProgressBar()
        {
            InitializeComponent();

            _radial = _viewWidth / 2 - _strokeWidth / 2;

            _startPositionX = _viewWidth / 2;
            _startPositionY = _strokeWidth / 2;

            _centerPositionX = _viewWidth / 2;
            _centerPositionY = _viewHeight / 2;

            Width = _viewWidth;
            Height = _viewHeight;
        }

        #region ProgressValue

        public static readonly DependencyProperty PercentProperty = DependencyProperty.Register(
            "Percent", typeof(double), typeof(CircleProgressBar), new PropertyMetadata(default(double), PercentPropertyChange));

        public double Percent
        {
            get { return (double) GetValue(PercentProperty); }
            set { SetValue(PercentProperty, value); }
        }

        private static void PercentPropertyChange(DependencyObject dp,DependencyPropertyChangedEventArgs args)
        {
           ((CircleProgressBar)dp).UpdateProgress(double.Parse(args.NewValue.ToString()));
        }

        #endregion

        public void UpdateProgress(double percent)
        {
            EpTrail.StrokeThickness = _strokeWidth;
            PathStroke.StrokeThickness = _strokeWidth;

            var arc = GetArcByPercent(percent);

            var pathGeometry = PathStroke.Data as PathGeometry;
            var pathFigure = pathGeometry.Figures[0];
            var arcSegment = pathFigure.Segments[0] as ArcSegment;

            pathFigure.StartPoint = arc.StartPoint;
            arcSegment.Size = arc.Size;
            arcSegment.IsLargeArc = arc.IsLarge;
            arcSegment.Point = arc.EndPoint;
        }

        private Arc GetArcByPercent(double percent)
        {
            var angle = GetAngleByCurrentPercent(percent);

            var arc = new Arc();
            arc.Size = new Size(_radial, _radial);
            arc.StartPoint = new Point(_startPositionX, _startPositionY);
            arc.IsLarge = angle >= 180;

            arc.EndPoint = GetPointForAngle(angle);

            return arc;
        }

        protected Point GetPointForAngle(double angle)
        {
            double angleInRadians = angle * Math.PI / 180;

            double px = _viewWidth / 2 + (Math.Sin(angleInRadians) * _radial);
            double py = _viewHeight / 2 + (-Math.Cos(angleInRadians) * _radial);

            return new Point(px, py);
        }

        private double GetAngleByCurrentPercent(double percent)
        {
            return _maxAngle * (percent / (_maxValue - _minValue));
        }
    }

    public class Arc
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Size Size { set; get; }
        public bool IsLarge { set; get; }
    }
}
