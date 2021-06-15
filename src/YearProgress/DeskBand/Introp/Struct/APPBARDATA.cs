using System;
using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.Struct {
    [StructLayout(LayoutKind.Sequential)]
    internal struct APPBARDATA {
        public int cbSize;
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public uint uEdge;
        public RECT rc;
        public int lParam;
    }
}
