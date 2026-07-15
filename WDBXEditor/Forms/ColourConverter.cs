using System;
using System.Drawing;
using System.Windows.Forms;
using WDBXEditor.Common;
using AdvancedDataGridView;

namespace WDBXEditor.Forms
{
    public partial class ColourConverter : Form
    {
        // CAMBIO: Especificamos explícitamente [EspacioDeNombres].[Clase]
        private AdvancedDataGridView.AdvancedDataGridView _data;
        private bool _closing = false;

        private readonly Func<Color, uint> ColourToInt = c => BitConverter.ToUInt32([c.B, c.G, c.R, 0], 0);
        private readonly Func<uint, Color> UIntToColor = i =>
        {
            var bytes = BitConverter.GetBytes(i);
            return Color.FromArgb(0, bytes[2], bytes[1], bytes[0]); //Alpha always 0
        };

        #region Colour Events
        public ColourConverter()
        {
            InitializeComponent();
            ColourWheelChanged(colourWheel, null);
        }

        private void ColourConverter_Load(object sender, EventArgs e)
        {
            // CAMBIO: También actualizamos el casting de la clase aquí
            _data = (AdvancedDataGridView.AdvancedDataGridView)((Main)Owner).Controls.Find("advancedDataGridView", true)[0];
        }

        private void ColourWheelChanged(object sender, EventArgs e)
        {
            txtRed.Text = colourWheel.CurrentColour.R.ToString();
            txtGreen.Text = colourWheel.CurrentColour.G.ToString();
            txtBlue.Text = colourWheel.CurrentColour.B.ToString();
            picColour.BackColor = colourWheel.CurrentColour;
            txtWoWVal.Text = ColourToInt(colourWheel.CurrentColour).ToString();
        }

        private void TxtWoWVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxtWoWVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ulong.TryParse(txtWoWVal.Text, out ulong dmp))
                txtWoWVal.Text = "0";
            else if (dmp > uint.MaxValue)
                txtWoWVal.Text = uint.MaxValue.ToString();

            colourWheel.CurrentColour = UIntToColor(Convert.ToUInt32(txtWoWVal.Text));
            txtRed.Text = colourWheel.CurrentColour.R.ToString();
            txtGreen.Text = colourWheel.CurrentColour.G.ToString();
            txtBlue.Text = colourWheel.CurrentColour.B.ToString();
            picColour.BackColor = colourWheel.CurrentColour;
        }

        private void TxtColourKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxtColourKeyUp(object sender, KeyEventArgs e)
        {
            if (!ulong.TryParse(txtBlue.Text, out ulong dmp)) //Check blue
                txtBlue.Text = "0";
            else if (dmp > 255)
                txtBlue.Text = "255";

            if (!ulong.TryParse(txtRed.Text, out dmp)) //Check red
                txtRed.Text = "0";
            else if (dmp > 255)
                txtRed.Text = "255";

            if (!ulong.TryParse(txtGreen.Text, out dmp)) //Check green
                txtGreen.Text = "0";
            else if (dmp > 255)
                txtGreen.Text = "255";

            colourWheel.CurrentColour = Color.FromArgb(0, Convert.ToInt32(txtRed.Text), Convert.ToInt32(txtGreen.Text), Convert.ToInt32(txtBlue.Text));
            picColour.BackColor = colourWheel.CurrentColour;
            txtWoWVal.Text = ColourToInt(colourWheel.CurrentColour).ToString();
        }
        #endregion

        #region Button Events
        private void BtnGet_Click(object sender, EventArgs e)
        {
            // CA1806: Usamos el resultado de TryParse en un "if". 
            // También agregué el "?" en Value?.ToString() para proteger de celdas nulas.
            if (ulong.TryParse(_data.CurrentCell.Value?.ToString(), out ulong dmp))
            {
                if (dmp > uint.MaxValue)
                    dmp = uint.MaxValue;

                colourWheel.CurrentColour = UIntToColor((uint)dmp);
                ColourWheelChanged(colourWheel, null);
            }
        }

        private void BetSet_Click(object sender, EventArgs e)
        {
            uint value = ColourToInt(colourWheel.CurrentColour);

            _data.BeginEdit(true);
            _data.CurrentCell.Value = value;
            _data.EndEdit();
        }
        #endregion

        #region Form Events
        private void ColourConverter_Activated(object sender, EventArgs e)
        {
            if (_closing) return;
            this.Opacity = 1;
        }

        private void ColourConverter_Deactivate(object sender, EventArgs e)
        {
            if (_closing) return;
            this.Opacity = 0.75f;
        }

        private void ColourConverter_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
        }
        #endregion

    }
}