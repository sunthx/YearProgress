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
        private double _viewWidth = 30;
        private double _viewHeight = 30;

        private double _radial = 0;
        private double _startPositionX = 0;
        private double _startPositionY = 0;

        private readonly int _minValue = 0;
        private readonly int _maxValue = 100;
        private readonly double _maxAngle = 359.999;

        private readonly int _strokeWidth = 8;

        private readonly Brush _defaultTrailColor = Brushes.Cornsilk;
        private readonly Brush _defaultStrokeColor = Brushes.BlueViolet;

        public CircleProgressBar()
        {
            InitializeComponent();

            Width = _viewWidth;
            Height = _viewHeight;

            Trail.StrokeThickness = _strokeWidth;
            Trail.Stroke = _defaultTrailColor;

            Stroke.StrokeThickness = _strokeWidth;
            Stroke.Stroke = _defaultStrokeColor;

            _radial = _viewWidth / 2 - _strokeWidth / 2;

            _startPositionX = _viewWidth / 2;
            _startPositionY = _strokeWidth / 2;
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
           ((CircleProgressBar)dp).UpdateViewByPercent(double.Parse(args.NewValue.ToString()));
        }
        
        #endregion

        public void UpdateViewByPercent(double percent)
        {
            var arc = GetArcByPercent(percent);

            var pathGeometry = Stroke.Data as PathGeometry;
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
            double py = _viewWidth / 2 + (-Math.Cos(angleInRadians) * _radial);

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
