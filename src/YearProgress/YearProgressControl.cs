using System;
using System.Windows.Forms;

namespace YearProgress
{
    public partial class YearProgressControl : UserControl
    {
        private double _yearProgress = 0;
        private double _dayProgress = 0;

        private readonly Timer _timer;

        public YearProgressControl()
        {
            InitializeComponent();

            _timer = new Timer();
            _timer.Tick += TimerOnTick;
            _timer.Interval = 1000;

            Load += (sender, args) =>
            {
                _timer.Start();
            };
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

            SetProgressValue(circleProgress1,_yearProgress);
            SetProgressValue(circleProgress2,_dayProgress);
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
