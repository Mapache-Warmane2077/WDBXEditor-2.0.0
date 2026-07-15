using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedDataGridView
{
    internal partial class FilterForm : Form
    {

        public List<DataGridViewRow> FilterRows { get; set; } = [];

        private enum FilterType
        {
            Unknown,
            String,
            Float,
            Integer
        }

        // IDE0044: Hacer de solo lectura
        private readonly FilterType _filterType = FilterType.Unknown;
        private string _filterString = null;
        // IDE0044 y IDE0090: Hacer de solo lectura y simplificar "new"
        private readonly Hashtable _textStrings = [];
        private bool _activated = false;

        private FilterForm()
        {
            InitializeComponent();
        }

        public FilterForm(Type dataType) : this()
        {
            _textStrings.Add("EQUALS", "EQUALS");
            _textStrings.Add("DOES_NOT_EQUAL", "DOESN'T EQUAL");
            _textStrings.Add("GREATER_THAN", "GREATER THAN");
            _textStrings.Add("GREATER_THAN_OR_EQUAL_TO", "GREATER THAN OR EQUAL");
            _textStrings.Add("LESS_THAN", "LESS THAN");
            _textStrings.Add("LESS_THAN_OR_EQUAL_TO", "LESS THAN OR EQUAL");
            _textStrings.Add("BEGINS_WITH", "STARTS WITH");
            _textStrings.Add("DOES_NOT_BEGIN_WITH", "DOESN'T START WITH");
            _textStrings.Add("ENDS_WITH", "ENDS WITH");
            _textStrings.Add("DOES_NOT_END_WITH", "DOESN'T END WITH");
            _textStrings.Add("CONTAINS", "CONTAINS");
            _textStrings.Add("DOES_NOT_CONTAIN", "DOESN'T CONTAIN");

            dgvFilter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            this.Text = "Filter";
            label_columnName.Text = "Show rows where value";

            if (dataType == typeof(Int32) || dataType == typeof(Int64) || dataType == typeof(Int16) ||
                    dataType == typeof(UInt32) || dataType == typeof(UInt64) || dataType == typeof(UInt16) ||
                    dataType == typeof(Byte) || dataType == typeof(SByte))
                _filterType = FilterType.Integer;
            else if (dataType == typeof(Single) || dataType == typeof(Double) || dataType == typeof(Decimal))
                _filterType = FilterType.Float;
            else if (dataType == typeof(String))
                _filterType = FilterType.String;
            else
                _filterType = FilterType.Unknown;

            switch (_filterType)
            {
                case FilterType.Integer:
                case FilterType.Float:
                    // IDE0300: Simplificar la inicialización de la recopilación
                    (dgvFilter.Columns["Filter"] as DataGridViewComboBoxColumn).Items.AddRange(
                    [
                        _textStrings["EQUALS"].ToString(),
                _textStrings["DOES_NOT_EQUAL"].ToString(),
                _textStrings["GREATER_THAN"].ToString(),
                _textStrings["GREATER_THAN_OR_EQUAL_TO"].ToString(),
                _textStrings["LESS_THAN"].ToString(),
                _textStrings["LESS_THAN_OR_EQUAL_TO"].ToString()
                    ]);
                    break;

                default:
                    // IDE0300: Simplificar la inicialización de la recopilación
                    (dgvFilter.Columns["Filter"] as DataGridViewComboBoxColumn).Items.AddRange(
                    [
                        _textStrings["EQUALS"].ToString(),
                _textStrings["DOES_NOT_EQUAL"].ToString(),
                _textStrings["BEGINS_WITH"].ToString(),
                _textStrings["DOES_NOT_BEGIN_WITH"].ToString(),
                _textStrings["ENDS_WITH"].ToString(),
                _textStrings["DOES_NOT_END_WITH"].ToString(),
                _textStrings["CONTAINS"].ToString(),
                _textStrings["DOES_NOT_CONTAIN"].ToString()
                    ]);
                    break;
            }
        }

        private void FormCustomFilter_Load(object sender, EventArgs e)
        {
            dgvFilter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        }

        private void FormCustomFilter_Activated(object sender, EventArgs e)
        {
            if (_activated) return;

            dgvFilter.AllowUserToAddRows = false;
            dgvFilter.Rows.Clear();

            for (int i = 0; i < (FilterRows?.Count ?? 0); i++)
            {
                if (FilterRows[i].Cells[0].Value == null)
                    continue;

                dgvFilter.Rows.Add(FilterRows[i].Cells[0].Value, FilterRows[i].Cells[1].Value, FilterRows[i].Cells[2].Value);
            }

            dgvFilter.AllowUserToAddRows = true;
            _activated = true;
        }

        private void FormCustomFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
                e.Cancel = true;
        }

        // IDE1006: Corrección de nomenclatura
        private void DgvFilter_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo info = dgvFilter.HitTest(e.X, e.Y);
            if (info.Type == DataGridViewHitTestType.Cell)
            {
                if ((dgvFilter.Rows[info.RowIndex].Cells[info.ColumnIndex] as DataGridViewComboBoxCell) != null)
                    dgvFilter.CurrentCell = dgvFilter.Rows[info.RowIndex].Cells[info.ColumnIndex];
            }
        }

        #region Filter Methods
        /// <summary>
        /// Get the Filter string
        /// </summary>
        public string FilterString
        {
            get
            {
                return _filterString;
            }
        }
        #endregion

        #region Filter Builder
        private string BuildFilter(FilterType filterType)
        {
            string column = "[{0}]";
            if (filterType == FilterType.Unknown)
                column = "Convert([{0}], 'System.String')";

            // IDE0090: Simplificación de "new"
            StringBuilder sb = new();
            foreach (DataGridViewRow row in dgvFilter.Rows)
            {
                string filter = row.Cells["Filter"].Value?.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(filter))
                    break;

                string op = (row.Cells["Operator"].Value ?? "").ToString();
                string value = row.Cells["Value"].Value.ToString();
                bool isnumber = (filterType == FilterType.Integer || filterType == FilterType.Float);

                switch (filterType)
                {
                    case FilterType.String:
                    case FilterType.Unknown:
                        value = FormatFilterString(value);
                        break;
                    case FilterType.Integer:
                        // IDE0018 y IDE0059: Declaración insertada y asignación innecesaria eliminada con 'out _'
                        if (!int.TryParse(value, out _))
                            continue;
                        break;
                    case FilterType.Float:
                        // IDE0018 y IDE0059: Declaración insertada y asignación innecesaria eliminada con 'out _'
                        if (!float.TryParse(value, out _))
                            continue;
                        break;
                }

                switch (filter)
                {
                    case "EQUALS":
                        sb.Append($" {column} {(isnumber ? "=" : "LIKE")} '{value}'");
                        break;
                    case "DOESN'T EQUAL":
                        sb.Append($" {column} {(isnumber ? "<>" : "NOT LIKE")} '{value}'");
                        break;
                    case "GREATER THAN":
                        sb.Append($" {column} > '{value}'");
                        break;
                    case "GREATER THAN OR EQUAL":
                        sb.Append($" {column} >= '{value}'");
                        break;
                    case "LESS THAN":
                        sb.Append($" {column} < '{value}'");
                        break;
                    case "LESS THAN OR EQUAL":
                        sb.Append($" {column} <= '{value}'");
                        break;
                    case "STARTS WITH":
                        sb.Append($" {column} LIKE '{value}%'");
                        break;
                    case "DOESN'T START WITH":
                        sb.Append($" {column} NOT LIKE '{value}%'");
                        break;
                    case "ENDS WITH":
                        sb.Append($" {column} LIKE '%{value}'");
                        break;
                    case "DOESN'T END WITH":
                        sb.Append($" {column} NOT LIKE '%{value}'");
                        break;
                    case "CONTAINS":
                        sb.Append($" {column} LIKE '%{value}%'");
                        break;
                    case "DOESN'T CONTAIN":
                        sb.Append($" {column} NOT LIKE '%{value}%'");
                        break;
                    default:
                        continue;
                }

                if (op != "AND" && op != "OR")
                    break;
                else
                    sb.Append($" {op}");
            }

            string result = sb.ToString();
            if (result.EndsWith(" AND") || result.EndsWith(" OR")) //Remove trailing AND or OR
                result = result[..^3]; // IDE0057: Substring se puede simplificar

            return result;
        }

        // CA1822: Marcar como static
        private static string FormatFilterString(string text)
        {
            string result = "";
            string s;
            // IDE0300: Simplificar la inicialización de la recopilación
            string[] replace = ["%", "[", "]", "*", "\"", "`", "\\"];

            for (int i = 0; i < text.Length; i++)
            {
                s = text[i].ToString();
                if (replace.Contains(s))
                    result += "[" + s + "]";
                else
                    result += s;
            }

            return result.Replace("'", "''");
        }
        #endregion

        #region Button Events

        // IDE1006: Corrección de nomenclatura
        private void Button_cancel_Click(object sender, EventArgs e)
        {
            _filterString = null;
            Close();
        }

        // IDE1006: Corrección de nomenclatura
        private void Button_ok_Click(object sender, EventArgs e)
        {
            // IDE0305: La inicialización de la recopilación se puede simplificar (collection expression)
            FilterRows = [.. dgvFilter.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[0] != null)];
            string filter = BuildFilter(_filterType);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                _filterString = filter;
                DialogResult = DialogResult.OK;
            }
            else
            {
                _filterString = null;
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        // IDE1006: Corrección de nomenclatura
        private void BtnReset_Click(object sender, EventArgs e)
        {
            FilterRows.Clear();
            dgvFilter.Rows.Clear();
        }
        #endregion

    }
}