﻿#pragma warning disable 1591
using System;
using System.Runtime.InteropServices;
using YearProgress.DeskBand.Introp.Struct;

namespace YearProgress.DeskBand.Introp.COM
{
    /// <summary>
    /// Gets information about a band object.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EB0FE172-1A3A-11D0-89B3-00A0C90A90AC")]
    public interface IDeskBand : IDockingWindow {

        #region IOleWindow Overrides

        /// <summary>
        /// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
        /// </summary>
        /// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
        /// <returns>
        /// This method returns S_OK on success.
        /// </returns>
        [PreserveSig]
        new int GetWindow(out IntPtr phwnd);

        /// <summary>
        /// Determines whether context-sensitive help mode should be entered during an in-place activation session.
        /// </summary>
        /// <param name="fEnterMode">TRUE if help mode should be entered; FALSE if it should be exited.</param>
        /// <returns>
        /// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in fEnterMode.
        /// </returns>
        [PreserveSig]
        new int ContextSensitiveHelp(bool fEnterMode);

        #endregion

        #region Overrides of IDockingWindow

        /// <summary>
        /// Instructs the docking window object to show or hide itself.
        /// </summary>
        /// <param name="bShow">TRUE if the docking window object should show its window.
        /// FALSE if the docking window object should hide its window and return its border space by calling SetBorderSpaceDW with zero values.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        [PreserveSig]
        new int ShowDW(bool bShow);

        /// <summary>
        /// Notifies the docking window object that it is about to be removed from the frame.
        /// The docking window object should save any persistent information at this time.
        /// </summary>
        /// <param name="dwReserved">Reserved. This parameter should always be zero.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        [PreserveSig]
        new int CloseDW(UInt32 dwReserved);

        /// <summary>
        /// Notifies the docking window object that the frame's border space has changed.
        /// In response to this method, the IDockingWindow implementation must call SetBorderSpaceDW, even if no border space is required or a change is not necessary.
        /// </summary>
        /// <param name="rcBorder">Pointer to a RECT structure that contains the frame's available border space.</param>
        /// <param name="punkToolbarSite">Pointer to the site's IUnknown interface. The docking window object should call the QueryInterface method for this interface, requesting IID_IDockingWindowSite.
        /// The docking window object then uses that interface to negotiate its border space. It is the docking window object's responsibility to release this interface when it is no longer needed.</param>
        /// <param name="fReserved">Reserved. This parameter should always be zero.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        [PreserveSig]
        new int ResizeBorderDW(RECT rcBorder, IntPtr punkToolbarSite, bool fReserved);

        #endregion

        /// <summary>
        /// Gets state information for a band object.
        /// </summary>
        /// <param name="dwBandID">The identifier of the band, assigned by the container. The band object can retain this value if it is required.</param>
        /// <param name="dwViewMode">The view mode of the band object. One of the following values: DBIF_VIEWMODE_NORMAL, DBIF_VIEWMODE_VERTICAL, DBIF_VIEWMODE_FLOATING, DBIF_VIEWMODE_TRANSPARENT.</param>
        /// <param name="pdbi">The pdbi.</param>
        /// <returns></returns>
        [PreserveSig]
        int GetBandInfo(UInt32 dwBandID, DESKBANDINFO.DBIF dwViewMode, ref DESKBANDINFO pdbi);
    }
}