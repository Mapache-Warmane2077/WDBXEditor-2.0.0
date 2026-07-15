using WDBXEditor.Storage;
using System;
using System.Windows.Forms;
using static WDBXEditor.Common.Constants;
using System.Threading.Tasks;

namespace WDBXEditor
{
    public partial class LoadCSV : Form
    {
        public DBEntry Entry { get; set; }
        public string ErrorMessage = string.Empty;

        private string filePath;

        public LoadCSV()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnLoad.Enabled = true;
                filePath = openFileDialog.FileName;
                txtFilePath.Text = filePath;
                // Eliminamos openFileDialog.Dispose() para evitar bloqueos si el usuario busca 2 veces
            }
        }

        private async void BtnLoad_Click(object sender, EventArgs e)
        {
            // Casteo seguro de la ventana principal
            if (this.Owner is Main mainWindow)
                mainWindow.ProgressBarHandle(true, "Importing CSV...");

            this.Enabled = false;

            bool header = chkHeader.Checked;

            ImportFlags flags = ImportFlags.None;
            if (rdoFixIds.Checked) flags |= ImportFlags.FixIds;
            if (rdoNewest.Checked) flags |= ImportFlags.TakeNewest;

            UpdateMode mode = UpdateMode.Insert;
            if (radUpdate.Checked) mode = UpdateMode.Update;
            else if (radOverride.Checked) mode = UpdateMode.Replace;

            try
            {
                // Usamos async/await para el trabajo pesado en segundo plano
                DialogResult result = await Task.Run(() =>
                {
                    if (!Entry.ImportCSV(filePath, header, mode, out ErrorMessage, flags))
                        return DialogResult.Abort;

                    return DialogResult.OK;
                });

                this.DialogResult = result;
                this.Close();
            }
            finally
            {
                // El bloque finally asegura que la UI siempre se desbloquee, incluso si algo falla catastróficamente
                this.Enabled = true;
                if (this.Owner is Main mainWin)
                    mainWin.ProgressBarHandle(false);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChkFixIds_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFixIds.Checked)
                rdoNewest.Checked = false;
        }

        private void ChkNewest_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewest.Checked)
                rdoFixIds.Checked = false;
        }
    }
}