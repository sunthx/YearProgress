using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpShell.Attributes;
using SharpShell.SharpDeskBand;

namespace YearProgress
{
    [ComVisible(true)]
    [DisplayName("Year Progress")]
    public class YearProgressBand : SharpDeskBand
    {
        protected override UserControl CreateDeskBand()
        {
            return new YearProgressControl();
        }

        protected override BandOptions GetBandOptions()
        {
            return new BandOptions
            {
                HasVariableHeight = false,
                IsSunken = false,
                ShowTitle = true,
                Title = "Year Progress",
                UseBackgroundColour = false,
                AlwaysShowGripper = false,
                IsFixed = true,
                HasNoMargins = true
            };
        }
    }
}
