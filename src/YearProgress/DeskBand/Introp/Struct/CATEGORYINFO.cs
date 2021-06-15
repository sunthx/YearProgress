using System;
using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.Struct {
    [StructLayout(LayoutKind.Sequential)]
    internal class CATEGORYINFO
    {
        public Guid catid;
        public uint lcidl;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string szDescription;
    }
}
