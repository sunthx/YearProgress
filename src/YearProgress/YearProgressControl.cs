using System;
using System.Drawing;
using System.Windows.Forms;
using Windows.UI.ViewManagement;

namespace YearProgress
{
    public partial class YearProgressControl : UserControl
    {
        private readonly UISettings _currentUiSettings;

        private double _yearProgress = 0;
        private double _dayProgress = 0;
        private Timer _timer;
        private readonly ToolTip _toolTip;

        private readonly Brush _trailDarkColor = Brushes.LightGray;
        private readonly Brush _trailLightColor = Brushes.LightGray;

        private readonly string[] _strokeColors = { "#2f54eb", "#722ed1","#1890ff", "#fa541c", "#f5222d"};

        public YearProgressControl()
        {
            InitializeComponent();

            _toolTip = new ToolTip {InitialDelay = 0};

            Load += Loaded;

            _currentUiSettings = new UISettings();
            _currentUiSettings.ColorValuesChanged += UiSettingsOnColorValuesChanged;
        }

        private void UiSettingsOnColorValuesChanged(UISettings sender, object args)
        {
            ChangeColor();
        }

        private void SetCircleProgressColor(
            CircleProgress circleProgress,
            Brush trailColor, 
            Brush strokeColor)
        {
            circleProgress.TrailColor = trailColor;
            circleProgress.StrokeColor = strokeColor;
        }

        private void ChangeColor()
        {
            var color = _currentUiSettings.GetColorValue(UIColorType.Background);
            if (color != Windows.UI.Colors.White)
            {
                SetCircleProgressColor(yearCirCleProgress, _trailDarkColor, GetStrokeBrush());
                SetCircleProgressColor(dayCirCleProgress, _trailDarkColor, GetStrokeBrush());
            }
            else
            {
                SetCircleProgressColor(yearCirCleProgress, _trailLightColor, GetStrokeBrush());
                SetCircleProgressColor(dayCirCleProgress, _trailLightColor, GetStrokeBrush());
            }
        }

        private Brush GetStrokeBrush()
        {
           var colorString = _strokeColors[new Random().Next(0, _strokeColors.Length - 1)];
           return new SolidBrush(ColorTranslator.FromHtml(colorString));
        }

        private void Loaded(object sender, EventArgs args)
        {
            ChangeColor();
            StartTimer();

            yearCirCleProgress.Tag = "Year:";
            dayCirCleProgress.Tag = "Today:";

            yearCirCleProgress.MouseEnter += ProgressControlOnMouseEnter;
            dayCirCleProgress.MouseEnter += ProgressControlOnMouseEnter;
        }

        private void ProgressControlOnMouseEnter(object sender, EventArgs e)
        {
            var control = sender as CircleProgress;
            if(control == null)
                return;

            var text = $"{control.Tag}{control.Value}%";
            _toolTip.Show(string.Empty, control);
            _toolTip.Show(text, control, 0);
        }

        private void StartTimer()
        {
            _timer = new Timer();
            _timer.Tick += TimerOnTick;
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            UpdateProgress(now);
        }

        private void UpdateProgress(DateTime now)
        {
            _yearProgress = GetYearProgressValue(now);
            _dayProgress = GetDayProgressValue(now);

            SetProgressValue(yearCirCleProgress,_yearProgress);
            SetProgressValue(dayCirCleProgress,_dayProgress);
        }

        private void SetProgressValue(CircleProgress cp,double value)
        {
            if (cp.Value != value)
            {
                cp.Value = value;
            }
        }

        private double GetYearProgressValue(DateTime now)
        {
            var totalDaysInYear = DateTime.IsLeapYear(now.Year) ? 366 : 365;
            var dayOfYear = DateTime.Now.DayOfYear;
            return Math.Round((dayOfYear * 1.0 / totalDaysInYear * 100), 2, MidpointRounding.AwayFromZero);
        }

        private double GetDayProgressValue(DateTime now)
        {
            return Math.Round(now.Hour * 100 / 24f,2);
        }
    }
}
