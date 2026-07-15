using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedDataGridView
{
    [System.ComponentModel.DesignerCategory("")]
    public partial class AdvancedDataGridView : DataGridView
    {
        public event EventHandler SortStringChanged;
        public event EventHandler FilterStringChanged;

        public ContextMenuStrip HeaderContext { get; set; }
        public bool FilterAndSortEnabled { get; set; }
        public string FilterString
        {
            get
            {
                return filterString;
            }
            private set
            {
                string old = value;
                if (old != filterString)
                {
                    filterString = value;
                    FilterStringChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        public string SortString
        {
            get
            {
                return sortString;
            }
            private set
            {
                string old = value;
                if (old != sortString)
                {
                    sortString = value;
                    SortStringChanged(this, new EventArgs());
                }
            }
        }


        private readonly List<string> sortorderList = [];
        private readonly List<string> filterorderList = [];
        private readonly List<string> filteredColumns = [];
        private string sortString = string.Empty;
        private string filterString = string.Empty;
        private object[] _copydata;
        private static readonly string[] SeparadoresLinea = ["\r\n", "\n", "\r"];
        private bool isCutOperation = false;

        // Se cambió el nombre para que inicie con mayúscula.
        // Al llamarse originalmente "InternalPrimaryKey" y devolver "PrimaryKey",
        // si solo cambiábamos la letra iba a chocar consigo mismo, así que lo renombramos:
        private DataColumn InternalPrimaryKey => PrimaryKey;

        private Dictionary<int, MinMax> BitCounts;

        public AdvancedDataGridView()
        {
            DoubleBuffered = true;
        }


        #region Cell Methods
        private IEnumerable<ColumnHeader> FilterableCells
        {
            get
            {
                return from DataGridViewColumn c in Columns
                       where c.HeaderCell != null && c.HeaderCell is ColumnHeader
                       select (c.HeaderCell as ColumnHeader);
            }
        }

        #endregion


        #region Column Events

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;
            // IDE0090: La expresión "new" se puede simplificar
            ColumnHeader cell = new(e.Column.HeaderCell, FilterAndSortEnabled);
            SetEvents(cell);
            e.Column.MinimumWidth = cell.MinimumSize.Width;
            if (ColumnHeadersHeight < cell.MinimumSize.Height)
                ColumnHeadersHeight = cell.MinimumSize.Height;
            e.Column.HeaderCell = cell;

            base.OnColumnAdded(e);
        }

        public void SetEvents(DataGridViewColumnHeaderCell header)
        {
            if (header is ColumnHeader cell)
            {
                cell.SortChanged += Cell_SortChanged;
                cell.FilterChanged += Cell_FilterChanged;
                cell.FilterPopup += Cell_FilterPopup;
                cell.HideChanged += Cell_HideChanged;
                cell.HexChanged += Cell_HexChanged;
            }
        }

        protected override void OnColumnRemoved(DataGridViewColumnEventArgs e)
        {
            filteredColumns.Remove(e.Column.Name);
            filterorderList.Remove(e.Column.Name);
            sortorderList.Remove(e.Column.Name);

            if (e.Column.HeaderCell is ColumnHeader cell)
            {
                cell.SortChanged -= Cell_SortChanged;
                cell.FilterChanged -= Cell_FilterChanged;
                cell.FilterPopup -= Cell_FilterPopup;
                cell.HideChanged -= Cell_HideChanged;
                cell.HexChanged -= Cell_HexChanged;
            }

            base.OnColumnRemoved(e);
        }

        #endregion


        #region Row Events

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            filteredColumns.Clear();
            base.OnRowsAdded(e);
        }

        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            filteredColumns.Clear();
            base.OnRowsRemoved(e);
        }

        public void SelectRow(int index)
        {
            ClearSelection();
            Rows[index].Selected = true;
            CurrentCell = Rows[index].Cells[0];
        }

        #endregion


        #region Cell Events
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            if (Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value && Columns[e.ColumnIndex].ValueType == typeof(string))
                Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;

            filteredColumns.Remove(Columns[e.ColumnIndex].Name);
            base.OnCellValueChanged(e);
        }

        public bool ValidValue(int index, object value)
        {
            if (BitCounts.TryGetValue(index, out var bitcount))
            {
                if (bitcount.IsSingle && float.TryParse(value.ToString(), out float fVal))
                {
                    return fVal >= (float)bitcount.MinVal && fVal <= (float)bitcount.MaxVal;
                }
                if (bitcount.Signed && long.TryParse(value.ToString(), out long val))
                {
                    return val >= (long)bitcount.MinVal && val <= (long)bitcount.MaxVal;
                }
                else if (ulong.TryParse(value.ToString(), out ulong val2))
                {
                    return val2 <= (ulong)bitcount.MaxVal;
                }
            }

            return true;
        }

        #endregion


        #region Filter Methods

        private string BuildFilterString()
        {
            StringBuilder sb = new("");
            string appx = "";

            foreach (string filterOrder in filterorderList)
            {
                DataGridViewColumn Column = Columns[filterOrder];

                if (Column != null)
                {
                    if (Column.HeaderCell is ColumnHeader cell)
                    {
                        if (cell.FilterAndSortEnabled && cell.ActiveFilterType != ColumnMenu.FilterType.None)
                        {
                            sb.AppendFormat(appx + "(" + cell.FilterString.Trim() + ")", Column.DataPropertyName);
                            appx = " AND ";
                        }
                    }
                }
            }
            return sb.ToString();
        }

        private void Cell_FilterPopup(object sender, ColumnHeaderCellEventArgs e)
        {
            if (Columns.Contains(e.Column))
            {
                ColumnMenu filterMenu = e.FilterMenu;
                DataGridViewColumn column = e.Column;

                System.Drawing.Rectangle rect = GetCellDisplayRectangle(column.Index, -1, true);

                if (filteredColumns.Contains(column.Name))
                    // Se eliminó el "false"
                    filterMenu.Show(this, rect.Left, rect.Bottom);
                else
                {
                    filteredColumns.Add(column.Name);

                    if (filterorderList.Count > 0 && filterorderList.Last() == column.Name)
                        // Se eliminó el "true"
                        filterMenu.Show(this, rect.Left, rect.Bottom);
                    else
                        // Se eliminó el "ColumnMenu.GetValuesForFilter(...)"
                        filterMenu.Show(this, rect.Left, rect.Bottom);
                }
            }
        }

        private void Cell_FilterChanged(object sender, ColumnHeaderCellEventArgs e)
        {
            if (Columns.Contains(e.Column))
            {
                ColumnMenu filterMenu = e.FilterMenu;
                DataGridViewColumn column = e.Column;

                filterorderList.Remove(column.Name);
                if (filterMenu.ActiveFilterType != ColumnMenu.FilterType.None)
                    filterorderList.Add(column.Name);

                FilterString = BuildFilterString();
            }
        }

        #endregion


        #region Sort Methods

        private string BuildSortString()
        {
            StringBuilder sb = new("");
            string appx = "";

            foreach (string sortOrder in sortorderList)
            {
                DataGridViewColumn column = Columns[sortOrder];

                if (column != null)
                {
                    if (column.HeaderCell is ColumnHeader cell)
                    {
                        if (cell.FilterAndSortEnabled && cell.ActiveSortType != ColumnMenu.SortType.None)
                        {
                            sb.AppendFormat(appx + cell.SortString, column.DataPropertyName);
                            appx = ", ";
                        }
                    }
                }
            }

            return sb.ToString();
        }

        // IDE1006: Corrección de nomenclatura
        private void Cell_SortChanged(object sender, ColumnHeaderCellEventArgs e)
        {
            if (Columns.Contains(e.Column))
            {
                ColumnMenu filterMenu = e.FilterMenu;
                DataGridViewColumn column = e.Column;

                sortorderList.Remove(column.Name);
                if (filterMenu.ActiveSortType != ColumnMenu.SortType.None)
                    sortorderList.Add(column.Name);
                SortString = BuildSortString();
            }
        }

        // IDE1006: Corrección de nomenclatura
        private void Cell_HideChanged(object sender, ColumnHeaderCellEventArgs e)
        {
            if (Columns.Contains(e.Column))
            {
                if (e.Column.Name == InternalPrimaryKey.ColumnName)
                    return;

                e.Column.Visible = false;
            }
        }

        // IDE1006: Corrección de nomenclatura
        private void Cell_HexChanged(object sender, ColumnHeaderCellEventArgs e)
        {
            if (e.Column.DefaultCellStyle.Tag?.ToString().StartsWith('X') == true) // CA1858 aplicado aquí también por coherencia
                e.Column.DefaultCellStyle.Tag = "";
            else
                e.Column.DefaultCellStyle.Tag = $"X";

            this.Refresh();
        }

        #endregion


        #region Hex
        protected override void OnCellParsing(DataGridViewCellParsingEventArgs e)
        {
            if (e != null && e.Value != null)
            {
                // CA1866: Cambiado "X" (string) por 'X' (char) usando comillas simples
                if (this.Columns[e.ColumnIndex].DefaultCellStyle.Tag?.ToString().StartsWith('X') == true)
                {
                    string value = e.Value.ToString();
                    if (value.StartsWith("0x")) // Nota: Aquí "0x" se queda igual porque son DOS caracteres
                        value = value[2..]; // IDE0057: Substring se puede simplificar

                    // IDE0018 y IDE0059: Variables en línea y asignaciones innecesarias eliminadas
                    if (long.TryParse(value, NumberStyles.HexNumber, null, out long l))
                    {
                        e.Value = Convert.ChangeType(l, e.DesiredType);
                        e.ParsingApplied = true;
                    }
                    else if (ulong.TryParse(value, NumberStyles.HexNumber, null, out ulong u))
                    {
                        e.Value = Convert.ChangeType(u, e.DesiredType);
                        e.ParsingApplied = true;
                    }
                }
            }
            else
            {
                base.OnCellParsing(e);
            }
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            string tag = this.Columns[e.ColumnIndex].DefaultCellStyle.Tag?.ToString() ?? "";

            // CA1858: Use "StartsWith" en lugar de comparar el resultado de "IndexOf" con 0
            if (e != null && tag.StartsWith('X'))
            {
                if (e.Value != null)
                {
                    // IDE0018 y IDE0059: Variables en línea y asignación innecesaria eliminada
                    if (long.TryParse(e.Value.ToString(), out long value))
                    {
                        e.Value = "0x" + value.ToString(tag);
                        e.FormattingApplied = true;
                    }
                }
            }
            else
                base.OnCellFormatting(e);
        }
        #endregion


        #region Copy Data
        public void SetCopyData()
        {
            if (SelectedRows.Count > 0)
                _copydata = ((DataRowView)CurrentRow.DataBoundItem).Row.ItemArray;
            else if (SelectedCells.Count > 0)
                _copydata = ((DataRowView)CurrentCell.OwningRow.DataBoundItem).Row.ItemArray;
        }

        public void PasteCopyData(DataRow row)
        {
            if (_copydata.Length == 0) return;

            var pk = ((DataTable)((BindingSource)DataSource).DataSource).PrimaryKey[0];
            _copydata[pk.Ordinal] = row.ItemArray[pk.Ordinal];
            row.ItemArray = _copydata;
        }

        public void ClearCopyData()
        {
            Array.Resize(ref _copydata, 0);
        }
        #endregion

        public void SetVisible(int index, bool value)
        {
            if (InternalPrimaryKey == null) return;
            if (index == InternalPrimaryKey.Ordinal) return;
            Columns[index].Visible = value;
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            Task.Run(() => Init());
            base.OnDataBindingComplete(e);

            if ((DataSource as BindingSource)?.DataSource as DataTable != null)
                BuildMinMaxArray();

        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            displayErrorDialogIfNoHandler = false;
            base.OnDataError(displayErrorDialogIfNoHandler, e);
        }



        private void BuildMinMaxArray()
        {
            // IDE0028: La inicialización de la recopilación se puede simplificar
            BitCounts = [];

            var source = ((DataTable)((BindingSource)DataSource).DataSource);
            foreach (DataColumn col in source.Columns)
            {
                if (col.ExtendedProperties.ContainsKey("MaxValue"))
                {
                    // IDE0090: La expresión "new" se puede simplificar
                    MinMax minmax = new()
                    {
                        Signed = col.ExtendedProperties.ContainsKey("MinValue"),
                        MaxVal = col.ExtendedProperties["MaxValue"],
                        MinVal = col.ExtendedProperties.Contains("MinValue") ? col.ExtendedProperties["MinValue"] : 0,
                        IsSingle = col.DataType == typeof(float)
                    };

                    BitCounts.Add(source.Columns.IndexOf(col), minmax);
                }
            }
        }
        #region Características Estilo Excel (Ctrl+X, Ctrl+D, Ctrl+V)

        // Interceptamos las teclas antes de que el DataGridView las procese de forma nativa
        // Interceptamos las teclas antes de que el DataGridView las procese de forma nativa
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Ctrl + C: Copiar normal (Reseteamos la bandera de corte)
            if (keyData == (Keys.Control | Keys.C))
            {
                isCutOperation = false;
                return base.ProcessCmdKey(ref msg, keyData);
            }
            // Ctrl + X: Cortar
            else if (keyData == (Keys.Control | Keys.X))
            {
                CortarCeldas();
                return true;
            }
            // Ctrl + D: Duplicar fila entera
            else if (keyData == (Keys.Control | Keys.D))
            {
                DuplicarFila();
                return true;
            }
            // Ctrl + V: Pegado inteligente
            else if (keyData == (Keys.Control | Keys.V))
            {
                if (this.IsCurrentCellInEditMode)
                    return base.ProcessCmdKey(ref msg, keyData);

                PegarEstiloExcel();
                return true;
            }
            // NUEVO - Suprimir: Borrar el contenido de las celdas seleccionadas
            else if (keyData == Keys.Delete)
            {
                // Si el usuario está editando el texto por dentro de la celda, dejamos que el Suprimir funcione normal
                if (this.IsCurrentCellInEditMode)
                    return base.ProcessCmdKey(ref msg, keyData);

                BorrarCeldasSeleccionadas();
                return true; // Indicamos que ya procesamos la tecla
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CortarCeldas()
        {
            if (this.SelectedCells.Count == 0) return;

            // 1. Copiar los datos seleccionados al portapapeles
            DataObject dataObj = this.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
                isCutOperation = true; // <-- ACTIVAMOS LA BANDERA AQUÍ
            }

            // 2. Borrar el contenido inyectando el valor por defecto correcto de WoW
            foreach (DataGridViewCell cell in this.SelectedCells)
            {
                if (!cell.ReadOnly && !cell.OwningColumn.ReadOnly)
                {
                    Type type = cell.ValueType;

                    if (type == typeof(string))
                    {
                        cell.Value = string.Empty;
                    }
                    else if (type == typeof(bool))
                    {
                        cell.Value = false;
                    }
                    else if (type != null && type.IsValueType)
                    {
                        cell.Value = Activator.CreateInstance(type);
                    }
                    else
                    {
                        cell.Value = DBNull.Value;
                    }
                }
            }
        }

        private void BorrarCeldasSeleccionadas()
        {
            if (this.SelectedCells.Count == 0) return;

            // Recorremos todas las celdas sombreadas
            foreach (DataGridViewCell cell in this.SelectedCells)
            {
                // Evitamos intentar borrar la llave primaria (ID) si está protegida o es de solo lectura
                if (!cell.ReadOnly && !cell.OwningColumn.ReadOnly)
                {
                    Type type = cell.ValueType;

                    // Asignamos el valor por defecto compatible con WoW
                    if (type == typeof(string))
                    {
                        cell.Value = string.Empty; // Textos quedan vacíos ""
                    }
                    else if (type == typeof(bool))
                    {
                        cell.Value = false; // Booleanos quedan en false
                    }
                    else if (type != null && type.IsValueType)
                    {
                        // Los números (int, float, uint) quedarán en 0 según su tipo exacto
                        cell.Value = Activator.CreateInstance(type);
                    }
                    else
                    {
                        cell.Value = DBNull.Value; // Solo como precaución final
                    }
                }
            }
        }

        private void DuplicarFila()
        {
            if (this.CurrentRow == null || this.CurrentRow.IsNewRow) return;

            // Obtenemos el acceso al origen de datos real de WDBXEditor
            if (this.DataSource is BindingSource bs && bs.DataSource is DataTable dt)
            {
                this.EndEdit();
                bs.EndEdit();

                // Obtener datos de la fila original
                DataRowView currentRowView = this.CurrentRow.DataBoundItem as DataRowView;
                if (currentRowView != null) return;
                DataRow currentRow = currentRowView.Row;

                DataRow newRow = dt.NewRow();
                DataColumn pk = dt.PrimaryKey.Length > 0 ? dt.PrimaryKey[0] : null;

                // 1. Auto-calcular el próximo ID para la llave primaria (PK)
                if (pk != null && (pk.DataType == typeof(int) || pk.DataType == typeof(uint) ||
                                   pk.DataType == typeof(long) || pk.DataType == typeof(ulong)))
                {
                    long maxId = -1;
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r.RowState != DataRowState.Deleted)
                        {
                            long currentId = Convert.ToInt64(r[pk]);
                            if (currentId > maxId) maxId = currentId;
                        }
                    }
                    // Le asignamos el ID más alto + 1
                    newRow[pk] = Convert.ChangeType(maxId + 1, pk.DataType);
                }

                // 2. Copiar el resto de datos de las columnas
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (pk != null && dt.Columns[i] == pk) continue; // Evitamos pisar el nuevo ID
                    newRow[i] = currentRow[i];
                }

                // 3. Agregar la fila clonada al final de la base de datos
                dt.Rows.Add(newRow);

                // 4. Seleccionar la nueva fila para enfocar la vista hacia abajo
                this.ClearSelection();
                int newIndex = this.Rows.Count - 1;

                // Las grillas de Windows Forms a veces tienen una fila fantasma al final para inserciones
                if (this.Rows[newIndex].IsNewRow && newIndex > 0)
                    newIndex--;

                this.FirstDisplayedScrollingRowIndex = newIndex;
                this.Rows[newIndex].Selected = true;
                this.CurrentCell = this.Rows[newIndex].Cells[0];
            }
        }

        private void PegarEstiloExcel()
        {
            if (this.CurrentCell == null) return;

            string textoPortapapeles = Clipboard.GetText();
            if (string.IsNullOrEmpty(textoPortapapeles)) return;

            // AQUÍ es donde aplicamos la optimización de los separadores:
            string[] filas = textoPortapapeles.Split(SeparadoresLinea, StringSplitOptions.None);

            int filaInicial = this.CurrentCell.RowIndex;
            int colInicial = this.CurrentCell.ColumnIndex;

            // Recorrer filas del portapapeles
            for (int i = 0; i < filas.Length; i++)
            {
                // Omitir la última fila si está vacía (Excel suele añadir un salto de línea extra)
                if (i == filas.Length - 1 && string.IsNullOrEmpty(filas[i])) continue;

                int filaActual = filaInicial + i;
                if (filaActual >= this.Rows.Count) break; // Límite inferior de la tabla

                // Dividir celdas por tabulación
                string[] celdasTexto = filas[i].Split('\t');
                int colActual = colInicial;

                // Recorrer celdas del portapapeles
                for (int j = 0; j < celdasTexto.Length; j++)
                {
                    // Saltar columnas ocultas en la tabla de destino
                    while (colActual < this.Columns.Count && !this.Columns[colActual].Visible)
                    {
                        colActual++;
                    }

                    if (colActual >= this.Columns.Count) break; // Límite derecho de la tabla

                    DataGridViewCell celdaDestino = this.Rows[filaActual].Cells[colActual];

                    if (!celdaDestino.ReadOnly && !celdaDestino.OwningColumn.ReadOnly)
                    {
                        try
                        {
                            // Lógica compatible con tus columnas Hexadecimales ("0x")
                            string tag = celdaDestino.OwningColumn.DefaultCellStyle.Tag?.ToString() ?? "";
                            if (tag.StartsWith('X') && celdasTexto[j].StartsWith("0x"))
                            {
                                // IDE0057: Simplificado usando el operador de rango [inicio..fin]
                                string hexVal = celdasTexto[j][2..];
                                if (long.TryParse(hexVal, NumberStyles.HexNumber, null, out long l))
                                    celdaDestino.Value = Convert.ChangeType(l, celdaDestino.ValueType);
                            }
                            else
                            {
                                // Conversión normal dependiendo del tipo de dato de la columna (int, float, string)
                                celdaDestino.Value = Convert.ChangeType(celdasTexto[j], celdaDestino.ValueType);
                            }
                        }
                        catch
                        {
                            // Si el texto no se puede convertir al tipo numérico/dato de la celda, se ignora esa celda
                        }
                    }
                    colActual++; // Avanzar a la siguiente columna
                }
            }
            if (isCutOperation)
            {
                Clipboard.Clear();
                isCutOperation = false;
            }
        }

        #endregion

        internal class MinMax
        {
            public object MinVal;
            public object MaxVal;
            public bool Signed;
            public bool IsSingle;
        }
    }
}