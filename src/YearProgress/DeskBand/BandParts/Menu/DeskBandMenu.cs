﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using YearProgress.DeskBand.Introp.Struct;

namespace YearProgress.DeskBand.BandParts.Menu
{
    /// <summary>
    /// A sub menu item that can contain other <see cref="DeskBandMenuItem"/>.
    /// </summary>
    public sealed class DeskBandMenu : DeskBandMenuItem
    {
        /// <summary>
        /// List of <see cref="DeskBandMenuItem"/> that this contains.
        /// </summary>
        public List<DeskBandMenuItem> Items { get; } = new List<DeskBandMenuItem>();

        /// <summary>
        /// Determines if the menu item is enabled.
        /// </summary>
        /// <value>
        /// True if the menu item can be interacted with. False to disable interactions.
        /// The default value is true;
        /// </value>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The text shown in the menu item.
        /// </summary>
        /// <value>
        /// The text that will be displayed for this menu item.
        /// </value>
        public string Text { get; set; }

        private IntPtr _menu;
        private MENUITEMINFO _menuiteminfo;

        /// <summary>
        /// Initializes a new instance of <see cref="DeskBandMenu"/> with a display text.
        /// </summary>
        /// <param name="text">The text displayed for this item in a menu.</param>
        public DeskBandMenu(string text) : this(text, null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="DeskBandMenu"/> with a display text and a list of submenu items.
        /// </summary>
        /// <param name="text">The text displayed for this item in a menu.</param>
        /// <param name="items">A <see cref="List{T}"/> of <see cref="DeskBandMenuItem"/> that will appear in this submenu.</param>
        public DeskBandMenu(string text, IEnumerable<DeskBandMenuItem> items)
        {
            Text = text;
            if (items != null)
            {
                Items.AddRange(items);
            }
        }

        /// <summary>
        /// Frees up resoruces associated with the menu
        /// </summary>
        ~DeskBandMenu()
        {
            ClearMenu();
        }

        internal override void AddToMenu(IntPtr menu, uint itemPosition, ref uint itemId, Dictionary<uint, DeskBandMenuAction> callbacks)
        {
            ClearMenu();

            _menu = User32.CreatePopupMenu();
            uint index = 0;
            foreach (var item in Items)
            {
                item.AddToMenu(_menu, index++, ref itemId, callbacks);
            }

            _menuiteminfo = new MENUITEMINFO()
            {
                cbSize = Marshal.SizeOf<MENUITEMINFO>(),
                fMask = MENUITEMINFO.MIIM.MIIM_SUBMENU | MENUITEMINFO.MIIM.MIIM_STRING | MENUITEMINFO.MIIM.MIIM_STATE,
                fType = MENUITEMINFO.MFT.MFT_MENUBREAK | MENUITEMINFO.MFT.MFT_STRING,
                fState = Enabled ? MENUITEMINFO.MFS.MFS_ENABLED : MENUITEMINFO.MFS.MFS_DISABLED,
                dwTypeData = Text,
                cch = (uint)Text.Length,
                hSubMenu = _menu,
            };

            User32.InsertMenuItem(menu, itemPosition, true, ref _menuiteminfo);
        }

        private void ClearMenu()
        {
            if (_menu != IntPtr.Zero)
            {
                User32.DestroyMenu(_menu);
            }
        }
    }
}
