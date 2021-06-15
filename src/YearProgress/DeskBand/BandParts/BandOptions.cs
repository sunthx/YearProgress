﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using YearProgress.DeskBand.BandParts.Menu;
using YearProgress.Properties;

namespace YearProgress.DeskBand.BandParts {
    public sealed class BandOptions : INotifyPropertyChanged {
        /// <summary>
        /// Height for a default horizontal taskbar
        /// </summary>
        public static readonly int TaskbarHorizontalHeightLarge = 40;

        /// <summary>
        /// Height for a default horizontal taskbar with small icons
        /// </summary>
        public static readonly int TaskbarHorizontalHeightSmall = 30;

        /// <summary>
        /// Width for a default vertical taskbar. There is no small vertical taskbar
        /// </summary>
        public static readonly int TaskbarVerticalWidth = 62;

        /// <summary>
        /// Value that represents no limit for deskband size
        /// </summary>
        /// <seealso cref="MaxHorizontalHeight"/>
        /// <seealso cref="MaxVerticalWidth"/>
        public static readonly int NoLimit = -1;

        private BandSize _horizontalSize;
        private int _maxHorizontalHeight;
        private BandSize _minHorizontalSize;
        private BandSize _verticalSize;
        private int _maxVerticalWidth;
        private BandSize _minVerticalSize;
        private string _title = "";
        private bool _showTitle = false;
        private bool _isFixed = false;
        private int _heightIncrement = 1;
        private bool _heightCanChange = true;
        private List<DeskBandMenuItem> _contextMenuItems = new List<DeskBandMenuItem>();

        /// <summary>
        /// Determines if the height of the horizontal deskband is allowed to change. For a deskband in the vertical orientation, it will be the width.
        /// Works alongside with the property <see cref="HeightIncrement"/>.
        /// </summary>
        /// <value>
        /// True if the height / width of the deskband can be changed. False to prevent changes.
        /// The default value is true.
        /// </value>
        public bool HeightCanChange {
            get => _heightCanChange;
            set {
                if (value == _heightCanChange) return;
                _heightCanChange = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Height step size of a horizontal deskband when it is being resized. For a deskband in the vertical orientation, it will be the step size of the width.
        /// The deskband will only be resized to multiples of this value.
        /// </summary>
        /// <example>
        /// If increment is 50, then the height of the deskband can only be resized to 50, 100 ...
        /// </example>
        /// <value>
        /// The step size for resizing. This value is only used if <see cref="HeightCanChange"/> is true. If the value is less than 0, the height / width can be any size.
        /// The default value is 1.
        /// </value>
        public int HeightIncrement {
            get => _heightIncrement;
            set {
                if (value == _heightIncrement) return;
                _heightIncrement = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Determines if the deskband has a fixed position and size, and if the gripper is shown.
        /// </summary>
        /// <value>
        /// True if the deskband is fixed. False if the deskband can be adjusted.
        /// The default value is false.
        /// </value>
        public bool IsFixed {
            get => _isFixed;
            set {
                if (value == _isFixed) return;
                _isFixed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Determines whether <see cref="Title"/> is shown next to the deskband
        /// </summary>
        /// <value>
        /// True if the title should be shown. False if the title is hidden.
        /// The default value is false.
        /// </value>
        public bool ShowTitle {
            get => _showTitle;
            set {
                if (value == _showTitle) return;
                _showTitle = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The title of the deskband. This will be shown if <see cref="ShowTitle"/> is true
        /// </summary>
        /// <value>
        /// The title to display. If the title is null, it will be converted to an empty string.
        /// The default value is an empty string.
        /// </value>
        public string Title {
            get => _title;
            set {
                if (value == _title) return;
                _title = value ?? "";
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Minimum <see cref="BandSize"/> of the deskband in the vertical orientation.
        /// </summary>
        /// <seealso cref="TaskbarOrientation"/>
        /// <value>
        /// The default value is <see cref="NoLimit"/> for the width and height.
        /// </value>
        public BandSize MinVerticalSize {
            get => _minVerticalSize;
            set {
                if (value.Equals(_minVerticalSize)) return;
                _minVerticalSize = value;
                _minVerticalSize.PropertyChanged += (sender, args) => OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Maximum width of the deskband in the vertical orientation
        /// </summary>
        /// <remarks>
        /// The maximum height will have to be addressed in your code as there is no limit to the height of the deskband when vertical.
        /// </remarks>
        /// <seealso cref="TaskbarOrientation"/>
        /// <value>
        /// The default value is <see cref="NoLimit"/>.
        /// </value>
        public int MaxVerticalWidth {
            get => _maxVerticalWidth;
            set {
                if (value.Equals(_maxVerticalWidth)) return;
                _maxVerticalWidth = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ideal <see cref="BandSize"/> of the deskband in the vertical orientation. There is no guarantee that the deskband will be this size.
        /// </summary>
        /// <seealso cref="TaskbarOrientation"/>
        /// <value>
        /// The default value is <see cref="TaskbarVerticalWidth"/> for the width and 200 for the height.
        /// </value>
        public BandSize VerticalSize {
            get => _verticalSize;
            set {
                if (value.Equals(_verticalSize)) return;
                _verticalSize = value;
                _verticalSize.PropertyChanged += (sender, args) => OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Minimum <see cref="BandSize"/> of the deskband in the horizontal orientation.
        /// </summary>
        /// <seealso cref="TaskbarOrientation"/>
        /// <value>
        /// The default value is <see cref="NoLimit"/>.
        /// </value>
        public BandSize MinHorizontalSize {
            get => _minHorizontalSize;
            set {
                if (value.Equals(_minHorizontalSize)) return;
                _minHorizontalSize = value;
                _minHorizontalSize.PropertyChanged += (sender, args) => OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Maximum height of the deskband in the horizontal orientation.
        /// </summary>
        /// <remarks>
        /// The maximum width will have to be addressed in your code as there is no limit to the width of the deskband when horizontal.
        /// </remarks>
        /// <seealso cref="TaskbarOrientation"/>
        /// <value>
        /// The default value is <see cref="NoLimit"/>.
        /// </value>
        public int MaxHorizontalHeight {
            get => _maxHorizontalHeight;
            set {
                if (value.Equals(_maxHorizontalHeight)) return;
                _maxHorizontalHeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ideal <see cref="BandSize"/> of the deskband in the horizontal orientation. There is no guarantee that the deskband will be this size.
        /// </summary>
        /// <seealso cref="TaskbarOrientation"/>
        /// <value>
        /// The default value is 200 for the width and <see cref="TaskbarHorizontalHeightLarge"/> for the height.
        /// </value>
        public BandSize HorizontalSize {
            get => _horizontalSize;
            set {
                if (value.Equals(_horizontalSize)) return;
                _horizontalSize = value;
                _horizontalSize.PropertyChanged += (sender, args) => OnPropertyChanged();
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// The list of <see cref="DeskBandMenuItem"/> the comprise the deskbands context menu.
        /// </summary>
        /// <value>
        /// A list of <see cref="DeskBandMenuItem"/> for the context menu. An empty list indicates no context menu.
        /// </value>
        /// <remarks>
        /// These context menu items are in addition of the default ones that windows provides.
        /// </remarks>
        public List<DeskBandMenuItem> ContextMenuItems {
            get => _contextMenuItems;
            set {
                if (Equals(value, _contextMenuItems)) return;
                _contextMenuItems = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CSDeskBandOptions"/>.
        /// </summary>
        public BandOptions() {
            //initialize in constructor to hook up property change events
            HorizontalSize = new BandSize(200, TaskbarHorizontalHeightLarge);
            MaxHorizontalHeight = NoLimit;
            MinHorizontalSize = new BandSize(NoLimit, NoLimit);

            VerticalSize = new BandSize(TaskbarVerticalWidth, 200);
            MaxVerticalWidth = NoLimit;
            MinVerticalSize = new BandSize(NoLimit, NoLimit);
        }

        /// <summary>
        /// Occurs when a property has change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
