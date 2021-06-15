using System;
using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.Struct {
    internal class Shell32
    {
        [DllImport("shell32.dll")]
        public static extern IntPtr SHAppBarMessage(APPBARMESSAGE dwMessage, [In] ref APPBARDATA pData);
    }
}
