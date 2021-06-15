#pragma warning disable 1591
using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.Struct {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINT
    {
        public int X;
        public int Y;
    }
}