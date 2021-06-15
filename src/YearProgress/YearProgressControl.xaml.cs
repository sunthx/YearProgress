using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using YearProgress.DeskBand;
using YearProgress.DeskBand.BandParts;

namespace YearProgress
{
    [ComVisible(true)]
    [Guid("eabd5a5b-4273-4fb8-a851-aa0d4b803534")]
    [BandRegistration(Name = "YearProgress", ShowDeskBand = true)]
    public partial class YearProgressControl 
    {
        private Timer _globalTimer;
        public YearProgressControl()
        {
            // Options.MinHorizontalSize.Width = 140;
            // Options.MaxVerticalWidth = 30;
            //
            InitializeComponent();
            DataContext = this;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _globalTimer = new Timer(RefreshProgressValue, null, 0, 1000 * 60);
        }

        private void RefreshProgressValue(object args)
        {
            Dispatcher.Invoke(() =>
            {
                var now = DateTime.Now;
                YearProgressBar.Percent = GetYearProgressValue(now);
                MonthProgressBar.Percent = GetMonthProgressValue(now);
                DayProgressBar.Percent = GetDayProgressValue(now);
            });
        }

        private double GetYearProgressValue(DateTime now)
        {
            var totalDaysInYear = DateTime.IsLeapYear(now.Year) ? 366 : 365;
            var dayOfYear = DateTime.Now.DayOfYear;
            return Math.Round((dayOfYear * 1.0 / totalDaysInYear * 100),1);
        }

        private double GetMonthProgressValue(DateTime now)
        {
            var year = now.Year;
            var month = now.Month;

            var days = DateTime.DaysInMonth(year, month);
            return Math.Round((now.Day * 1.0 / days * 100),1);
        }

        private double GetDayProgressValue(DateTime now)
        {
            return Math.Round((now.Ticks * 1.0 / now.Date.AddDays(1).AddSeconds(-1).Ticks * 100), 1);
        }
    }
}
