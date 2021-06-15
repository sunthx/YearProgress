﻿#pragma warning disable 1591
using System;
using System.Runtime.InteropServices;

namespace YearProgress.DeskBand.Introp.COM
{
    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms693765(v=vs.85).aspx
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FC4801A3-2BA9-11CF-A229-00AA003D7352")]
    public interface IObjectWithSite
    {
        /// <summary>
        /// Enables a container to pass an object a pointer to the interface for its site.
        /// </summary>
        /// <param name="pUnkSite">A pointer to the IUnknown interface pointer of the site managing this object. If NULL, the object should call Release on any existing site at which point the object no longer knows its site.</param>
        /// <returns>This method returns S_OK on success.</returns>
        [PreserveSig]
        int SetSite([MarshalAs(UnmanagedType.IUnknown)] object pUnkSite);


        /// <summary>
        /// Retrieves the latest site passed using SetSite.
        /// </summary>
        /// <param name="riid">The IID of the interface pointer that should be returned in ppvSite.</param>
        /// <param name="ppvSite">Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvSite contains the requested interface pointer to the site last seen in SetSite. The specific interface returned depends on the riid argument梚n essence, the two arguments act identically to those in QueryInterface. If the appropriate interface pointer is available, the object must call AddRef on that pointer before returning successfully. If no site is available, or the requested interface is not supported, this method must *ppvSite to NULL and return a failure code.</param>
        /// <returns>This method returns S_OK on success.</returns>
        [PreserveSig]
        int GetSite(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out IntPtr ppvSite);
    }
}