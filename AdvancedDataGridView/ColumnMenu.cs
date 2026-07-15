using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedDataGridView
{

    [System.ComponentModel.DesignerCategory("")]
    internal partial class ColumnMenu : ContextMenuStrip
    {
        public enum FilterType : byte
        {
            None = 0,
            Custom = 1,
            CheckList = 2,
            Loaded = 3
        }
        public enum SortType : byte
        {
            None = 0,
            ASC = 1,
            DESC = 2
        }

        public event EventHandler SortChanged;
        public event EventHandler FilterChanged;
        public event EventHandler HexChanged;
        public event EventHandler HideChanged;

        public SortType ActiveSortType
        {
            get
            {
                return _activeSortType;
            }
        }
        public FilterType ActiveFilterType
        {
            get
            {
                return _activeFilterType;
            }
        }
        public Type DataType { get; private set; }
        public bool IsSortEnabled { get; set; }
        public bool IsFilterEnabled { get; set; }

        // IDE0044 y IDE0090: Hacer de solo lectura y simplificar new
        private readonly Hashtable _textStrings = [];
        // IDE0028: Simplificar la inicialización de la recopilación
        private List<DataGridViewRow> _filterRows = [];
        private FilterType _activeFilterType = FilterType.None;
        private SortType _activeSortType = SortType.None;
        private string _sortString = null;
        private string _filterString = null;
        // IDE0044 y IDE0090: Hacer de solo lectura y simplificar new
        private static readonly Point _resizeStartPoint = new(1, 1);
        // IDE0090: Simplificar new
        private Point _resizeEndPoint = new(-1, -1);
        private bool _activated = false;

        #region Constructor/Events
        public ColumnMenu(Type dataType) : base()
        {
            _textStrings.Add("SORTDATETIMEASC", "Sort Oldest to Newest");
            _textStrings.Add("SORTDATETIMEDESC", "Sort Newest to Oldest");
            _textStrings.Add("SORTBOOLASC", "Sort by False/True");
            _textStrings.Add("SORTBOOLDESC", "Sort by True/False");
            _textStrings.Add("SORTNUMASC", "Sort Smallest to Largest");
            _textStrings.Add("SORTNUMDESC", "Sort Largest to Smallest");
            _textStrings.Add("SORTTEXTASC", "Sort А to Z");
            _textStrings.Add("SORTTEXTDESC", "Sort Z to A");
            _textStrings.Add("ADDCUSTOMFILTER", "Add a Filter");
            _textStrings.Add("CUSTOMFILTER", "Filter");
            _textStrings.Add("CLEARFILTER", "Clear Filter");
            _textStrings.Add("CLEARSORT", "Clear Sort");
            _textStrings.Add("BUTTONOK", "Filter");
            _textStrings.Add("BUTTONCANCEL", "Cancel");
            _textStrings.Add("NODESELECTALL", "(Select All)");
            _textStrings.Add("NODESELECTEMPTY", "(Blanks)");
            _textStrings.Add("HIDECOLUMN", "Hide");

            InitializeComponent();

            DataType = dataType;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            Activate();
            base.OnVisibleChanged(e);
        }

        private void Activate()
        {
            if (_activated) return;

            //Load this only when required, massive performance increase

            sortASCMenuItem.Image = Properties.Resources.MenuStrip_OrderASCtxt;
            sortDESCMenuItem.Image = Properties.Resources.MenuStrip_OrderDESCtxt;
            customFilterLastFiltersListMenuItem.Image = Properties.Resources.ColumnHeader_Filtered;
            customFilterLastFiltersListMenuItem.Text = _textStrings["CUSTOMFILTER"].ToString();

            // IDE0300: Simplificar la inicialización de la recopilación
            Type[] numberTypes = [typeof(int), typeof(long), typeof(short), typeof(uint), typeof(ulong), typeof(ushort),
                                         typeof(byte), typeof(sbyte), typeof(decimal), typeof(float), typeof(double)];

            Type[] nonhexTypes = [typeof(decimal), typeof(float), typeof(double)];

            if (numberTypes.Contains(DataType))
            {
                sortASCMenuItem.Text = _textStrings["SORTNUMASC"].ToString();
                sortDESCMenuItem.Text = _textStrings["SORTNUMDESC"].ToString();
                hexDisplayMenuItem.Visible = !nonhexTypes.Contains(DataType);
                toolStripSeparator2MenuItem.Visible = hexDisplayMenuItem.Visible;
            }
            else
            {
                sortASCMenuItem.Text = _textStrings["SORTTEXTASC"].ToString();
                sortDESCMenuItem.Text = _textStrings["SORTTEXTDESC"].ToString();
                hexDisplayMenuItem.Visible = false;
                toolStripSeparator2MenuItem.Visible = false;
            }

            customFilterLastFiltersListMenuItem.Enabled = DataType != typeof(bool);
            customFilterLastFiltersListMenuItem.Checked = ActiveFilterType == FilterType.Custom;
            customFilterLastFiltersListMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sortDESCMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sortASCMenuItem.ImageScaling = ToolStripItemImageScaling.None;

            // IDE0090: Simplificar new
            MinimumSize = new(PreferredSize.Width, PreferredSize.Height);
            ResizeBox(MinimumSize.Width, MinimumSize.Height);

            _activated = true;
        }

        private void MenuStrip_Closed(Object sender, EventArgs e)
        {
            ResizeClean();
        }

        private void MenuStrip_LostFocus(Object sender, EventArgs e)
        {
            if (!ContainsFocus)
                Close();
        }

        // CA1822: Marcar como static
        private static ImageList GetCheckListStateImages()
        {
            // IDE0090: Simplificar new
            ImageList images = new();
            _ = new Bitmap(16, 16);
            _ = new Bitmap(16, 16);
            _ = new Bitmap(16, 16);

            // IDE0063 y IDE0090: Using y new simplificados
            using Bitmap img = new(16, 16);
            using Graphics g = Graphics.FromImage(img);

            CheckBoxRenderer.DrawCheckBox(g, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            Bitmap unCheckImg = (Bitmap)img.Clone();
            CheckBoxRenderer.DrawCheckBox(g, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
            Bitmap checkImg = (Bitmap)img.Clone();
            CheckBoxRenderer.DrawCheckBox(g, new Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
            Bitmap mixedImg = (Bitmap)img.Clone();

            images.Images.Add("uncheck", unCheckImg);
            images.Images.Add("check", checkImg);
            images.Images.Add("mixed", mixedImg);
            return images;
        }

        #endregion

        #region Enablers

        public void SetSortEnabled(bool enabled)
        {
            if (!IsSortEnabled)
                enabled = false;

            this.cancelSortMenuItem.Enabled = enabled;

            this.sortASCMenuItem.Enabled = enabled;
            this.sortDESCMenuItem.Enabled = enabled;
        }

        public void SetFilterEnabled(bool enabled)
        {
            if (!IsFilterEnabled)
                enabled = false;

            this.cancelFilterMenuItem.Enabled = enabled;
            if (enabled)
                customFilterLastFiltersListMenuItem.Enabled = DataType != typeof(bool);
            else
                customFilterLastFiltersListMenuItem.Enabled = false;
        }

        #endregion

        public void SetLoadedMode(bool enabled)
        {
            cancelFilterMenuItem.Enabled = enabled;
            if (enabled)
            {
                _activeFilterType = FilterType.Loaded;
                _sortString = null;
                _filterString = null;
                customFilterLastFiltersListMenuItem.Checked = false;
                SetSortEnabled(false);
                SetFilterEnabled(false);
            }
            else
            {
                _activeFilterType = FilterType.None;

                SetSortEnabled(true);
                SetFilterEnabled(true);
            }
        }

        // IDE0060: Parámetros "vals" y "_restoreFilter" retirados
        // Al quitar los parámetros sin usar, los dos métodos "Show" quedan idénticos, por lo que se unifican en este solo
        public new void Show(Control control, int x, int y)
        {
            base.Show(control, x, y);
        }

        public static IEnumerable<DataGridViewCell> GetValuesForFilter(DataGridView grid, string columnName)
        {
            return from DataGridViewRow nulls in grid.Rows select nulls.Cells[columnName];
        }

        #region Sort Methods
        public void SortASC()
        {
            SortASCMenuItem_Click(this, null);
        }

        public void SortDESC()
        {
            SortDESCMenuItem_Click(this, null);
        }

        public string SortString
        {
            // IDE0029: Simplificar comprobación null
            get => _sortString ?? "";
            private set
            {
                cancelSortMenuItem.Enabled = (value != null && value.Length > 0);
                _sortString = value;
            }
        }

        public void CleanSort()
        {
            // IDE0059: Se eliminó la asignación innecesaria de "oldsort"
            sortASCMenuItem.Checked = false;
            sortDESCMenuItem.Checked = false;
            _activeSortType = SortType.None;
            SortString = null;
        }

        #endregion

        #region Filter Methods
        public string FilterString
        {
            // IDE0029: Simplificar comprobación null
            get => _filterString ?? "";
            private set
            {
                cancelFilterMenuItem.Enabled = (value != null && value.Length > 0);
                _filterString = value;
            }
        }

        public void CleanFilter()
        {
            _activeFilterType = FilterType.None;
            // IDE0059: Se eliminó la asignación innecesaria de "oldsort"
            FilterString = null;
            customFilterLastFiltersListMenuItem.Checked = false;
            _filterRows.Clear();
        }
        #endregion

        #region Filter Events

        // IDE1006: Corrección de nomenclatura
        private void CancelFilterMenuItem_Click(object sender, EventArgs e)
        {
            string oldfilter = FilterString;

            //clean Filter
            CleanFilter();

            //fire Filter changed
            if (oldfilter != FilterString && FilterChanged != null)
                FilterChanged(this, EventArgs.Empty); // IDE0090 simplificado
        }

        // IDE1006: Corrección de nomenclatura
        private void CancelFilterMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        // IDE1006: Corrección de nomenclatura
        private void CustomFilterMenuItem_Click(object sender, EventArgs e)
        {
            // IDE0017 y IDE0090: Inicialización simplificada
            FilterForm flt = new(DataType)
            {
                FilterRows = _filterRows
            };

            if (flt.ShowDialog() == DialogResult.OK)
            {
                //add the new Filter presets
                _filterRows = flt.FilterRows;
                string filterString = flt.FilterString ?? "";

                _activeFilterType = (string.IsNullOrWhiteSpace(filterString) ? FilterType.None : FilterType.Custom);

                //get Filter string
                string oldfilter = FilterString;
                FilterString = filterString;

                //fire Filter changed
                if (oldfilter != FilterString && FilterChanged != null)
                    FilterChanged(this, EventArgs.Empty); // IDE0090 simplificado
            }
        }

        // IDE1006: Corrección de nomenclatura
        private void CustomFilterLastFilter1MenuItem_VisibleChanged(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).VisibleChanged -= CustomFilterLastFilter1MenuItem_VisibleChanged;
        }

        // IDE1006: Corrección de nomenclatura
        private void CustomFilterLastFilterMenuItem_TextChanged(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Available = true;
            (sender as ToolStripMenuItem).TextChanged -= CustomFilterLastFilterMenuItem_TextChanged;
        }

        #endregion

        #region Click Events

        // IDE1006: Corrección de nomenclatura
        private void HexDisplayMenuItem_Click(object sender, EventArgs e)
        {
            hexDisplayMenuItem.Checked = !hexDisplayMenuItem.Checked;
            HexChanged?.Invoke(this, EventArgs.Empty);
        }

        // IDE1006: Corrección de nomenclatura
        private void HideMenuItem_Click(object sender, EventArgs e)
        {
            HideChanged?.Invoke(this, EventArgs.Empty);
        }

        // IDE1006: Corrección de nomenclatura
        private void SortASCMenuItem_Click(object sender, EventArgs e)
        {
            sortASCMenuItem.Checked = true;
            sortDESCMenuItem.Checked = false;
            _activeSortType = SortType.ASC;

            //get Sort String
            string oldsort = SortString;
            SortString = "[{0}] ASC";

            //fire Sort Changed
            if (oldsort != SortString && SortChanged != null)
                SortChanged(this, EventArgs.Empty);
        }

        // IDE1006: Corrección de nomenclatura
        private void SortASCMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        // IDE1006: Corrección de nomenclatura
        private void SortDESCMenuItem_Click(object sender, EventArgs e)
        {
            sortASCMenuItem.Checked = false;
            sortDESCMenuItem.Checked = true;
            _activeSortType = SortType.DESC;

            //get Sort String
            string oldsort = SortString;
            SortString = "[{0}] DESC";

            //fire Sort Changed
            if (oldsort != SortString && SortChanged != null)
                SortChanged(this, EventArgs.Empty);
        }

        // IDE1006: Corrección de nomenclatura
        private void SortDESCMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        // IDE1006: Corrección de nomenclatura
        private void CancelSortMenuItem_Click(object sender, EventArgs e)
        {
            string oldsort = SortString;
            //clean Sort
            CleanSort();
            //fire Sort changed
            if (oldsort != SortString && SortChanged != null)
                SortChanged(this, EventArgs.Empty);
        }

        // IDE1006: Corrección de nomenclatura
        private void CancelSortMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Enabled)
                (sender as ToolStripMenuItem).Select();
        }

        #endregion

        #region Resize
        private void ResizeBox(int w, int h)
        {
            sortASCMenuItem.Width = w - 1;
            sortDESCMenuItem.Width = w - 1;
            cancelSortMenuItem.Width = w - 1;
            cancelFilterMenuItem.Width = w - 1;
            customFilterLastFiltersListMenuItem.Width = w - 1;

            Size = new Size(w, h);
        }

        /// <summary>
        /// Clean box for Resize
        /// </summary>
        private void ResizeClean()
        {
            if (_resizeEndPoint.X != -1)
            {
                Point startPoint = PointToScreen(ColumnMenu._resizeStartPoint);

                // IDE0017 y IDE0090: Inicialización simplificada
                Rectangle rc = new(startPoint.X, startPoint.Y, _resizeEndPoint.X, _resizeEndPoint.Y)
                {
                    X = Math.Min(startPoint.X, _resizeEndPoint.X),
                    Width = Math.Abs(startPoint.X - _resizeEndPoint.X),
                    Y = Math.Min(startPoint.Y, _resizeEndPoint.Y),
                    Height = Math.Abs(startPoint.Y - _resizeEndPoint.Y)
                };

                ControlPaint.DrawReversibleFrame(rc, Color.Black, FrameStyle.Dashed);

                _resizeEndPoint.X = -1;
            }
        }

        #endregion
    }
}