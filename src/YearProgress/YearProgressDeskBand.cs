using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using CSDeskBand;
using CSDeskBand.ContextMenu;

namespace YearProgress
{
    [ComVisible(true)]
    [Guid("9FB8FF68-7902-4739-A27D-0356F2F88CF7")]
    [CSDeskBandRegistration(Name = "YearProgress")]
    public class YearProgressDeskBand : CSDeskBandWpf
    {
        public YearProgressDeskBand()
        {
            Options.ContextMenuItems = ContextMenuItems;
        }

        protected override UIElement UIElement
        {
            get
            {
                var control = new YearProgressControl();
                return control;
            }
        }

        private List<DeskBandMenuItem> ContextMenuItems
        {
            get
            {
                var action = new DeskBandMenuAction("Action");
                return new List<DeskBandMenuItem>() { action };
            }
        }
    }
}
