using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using YearProgress.Annotations;

namespace YearProgress
{
    /// <summary>
    /// Interaction logic for YearProgressControl.xaml
    /// </summary>
    public partial class YearProgressControl : UserControl,INotifyPropertyChanged
    {
        private Timer _globalTimer;
        public YearProgressControl()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _globalTimer = new Timer(RefreshProgressValue, null, 0, 1000 * 60);
        }

        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private void RefreshProgressValue(object args)
        {
            Value = GetYearProgressValue();
        }

        private int GetYearProgressValue()
        {
            var now = DateTime.Now;
            var totalDaysInYear = DateTime.IsLeapYear(now.Year) ? 366 : 365;
            var dayOfYear = DateTime.Now.DayOfYear;
            return (int)(dayOfYear * 1.0 / totalDaysInYear * 100);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
