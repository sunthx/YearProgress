using System;
using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.COM {
    [ComImport, Guid("6D67E846-5B9C-4db8-9CBC-DDE12F4254F1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITrayDeskband {
        [PreserveSig]
        int ShowDeskBand([In, MarshalAs(UnmanagedType.Struct)] ref Guid clsid);
        [PreserveSig]
        int HideDeskBand([In, MarshalAs(UnmanagedType.Struct)] ref Guid clsid);
        [PreserveSig]
        int IsDeskBandShown([In, MarshalAs(UnmanagedType.Struct)] ref Guid clsid);
        [PreserveSig]
        int DeskBandRegistrationChanged();
    }
}
