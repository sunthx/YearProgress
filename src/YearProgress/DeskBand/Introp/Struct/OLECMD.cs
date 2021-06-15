using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.Struct {
    [StructLayout(LayoutKind.Sequential)]
    internal struct OLECMD
    {
        public uint cmdID;
        public uint cmdf;
    }
}
