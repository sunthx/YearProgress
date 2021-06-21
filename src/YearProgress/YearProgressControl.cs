using System;
using System.Drawing;
using System.IO;
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
        private DateTime _startRunningTime;

        private readonly ToolTip _toolTip;                                         
        private readonly Brush _trailDarkColor = Brushes.LightGray;
        private readonly Brush _trailLightColor = Brushes.LightGray;

        private readonly string[] _strokeColors =
        {
            "#2f54eb",
            "#722ed1",
            "#1890ff",
            "#fa541c",
            "#f5222d",
            "#a0d911",
            "#13c2c2",
            "#eb2f96"
        };

        public YearProgressControl()
        {
            InitializeComponent();

            _toolTip = new ToolTip {InitialDelay = 0};
            _currentUiSettings = new UISettings();
            _startRunningTime = DateTime.Now;

            Load += Loaded;
            _currentUiSettings.ColorValuesChanged += UiSettingsOnColorValuesChanged;
        }

        private void UiSettingsOnColorValuesChanged(UISettings sender, object args)
        {
            ChangeStrokeColor();
        }

        private void SetCircleProgressColor(
            Brush trailColor, 
            Brush strokeColor)
        {
            yearCirCleProgress.TrailColor = trailColor;
            yearCirCleProgress.StrokeColor = strokeColor;

            dayCirCleProgress.TrailColor = trailColor;
            dayCirCleProgress.StrokeColor = strokeColor;
        }

        private Brush GetStrokeBrush()
        {
           var colorString = _strokeColors[new Random().Next(0, _strokeColors.Length - 1)];
           return new SolidBrush(ColorTranslator.FromHtml(colorString));
        }

        private void Loaded(object sender, EventArgs args)
        {
            ChangeStrokeColor();
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
            _timer.Interval = 1000 * 60;
            _timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            UpdateProgressControl(now);
        }

        private void UpdateProgressControl(DateTime now)
        {
            if ((now - _startRunningTime).TotalHours >= 1)
            {
                _startRunningTime = now;
                ChangeStrokeColor();
            }

            _yearProgress = GetYearProgressValue(now);
            _dayProgress = GetDayProgressValue(now);

            SetProgressValue(yearCirCleProgress,_yearProgress);
            SetProgressValue(dayCirCleProgress,_dayProgress);
        }

        private void ChangeStrokeColor()
        {
            var color = _currentUiSettings.GetColorValue(UIColorType.Background);
            var stroke = GetStrokeBrush();
            SetCircleProgressColor(color != Windows.UI.Colors.White ? _trailDarkColor : _trailLightColor, stroke);
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
