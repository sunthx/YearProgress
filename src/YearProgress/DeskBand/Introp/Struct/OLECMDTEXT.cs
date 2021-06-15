using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.Struct {
    [StructLayout(LayoutKind.Sequential)]
    internal struct OLECMDTEXT
    {
        public uint cmdtextf;
        public uint cwActual;
        public uint cwBuf;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string rgwz;
    }
}