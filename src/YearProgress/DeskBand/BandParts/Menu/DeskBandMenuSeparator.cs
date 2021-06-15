﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using YearProgress.DeskBand.Introp.Struct;

namespace YearProgress.DeskBand.BandParts.Menu
{
    /// <summary>
    /// A context menu seperator.
    /// </summary>
    public sealed class DeskBandMenuSeparator : DeskBandMenuItem
    {
        private MENUITEMINFO _menuiteminfo;

        internal override void AddToMenu(IntPtr menu, uint itemPosition, ref uint itemId, Dictionary<uint, DeskBandMenuAction> callbacks)
        {
            _menuiteminfo = new MENUITEMINFO()
            {
                cbSize = Marshal.SizeOf<MENUITEMINFO>(),
                fMask = MENUITEMINFO.MIIM.MIIM_TYPE,
                fType = MENUITEMINFO.MFT.MFT_SEPARATOR,
            };

            User32.InsertMenuItem(menu, itemPosition, true, ref _menuiteminfo);
        }
    }
}
