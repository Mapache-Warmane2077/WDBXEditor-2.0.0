using WDBXEditor.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static WDBXEditor.Common.Constants;

namespace WDBXEditor
{
    public partial class LoadDefinition : Form
    {
        public IEnumerable<string> Files { get; set; }

        public LoadDefinition()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = DEFINITION_DIR;
        }

        private void LoadDefinition_Load(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            LoadBuilds();
        }

        public void UpdateFiles(IEnumerable<string> files)
        {
            Files = Files.Concat(files);
            LoadBuilds();
        }

        #region Button Events
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            int build = (int)lbDefinitions.SelectedValue;
            Database.BuildNumber = build;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnNewWindow_Click(object sender, EventArgs e)
        {
            if (InstanceManager.LoadNewInstance(Files))
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region Listbox
        private void LbDefinitions_SelectedValueChanged(object sender, EventArgs e)
        {
            btnLoad.Enabled = lbDefinitions.SelectedItems.Count > 0;
        }

        private void LbDefinitions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbDefinitions.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                int build = (int)lbDefinitions.SelectedValue;
                Database.BuildNumber = build;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        private void LoadBuilds(bool mostRecent = true)
        {
            if (Database.Definitions.Tables.Count == 0)
            {
                MessageBox.Show("No defintions found.");
                return;
            }

            if (Files?.Count() == 0)
            {
                SetFileText();
                lbDefinitions.DataSource = null;
                MessageBox.Show("No files to load.");
                return;
            }

            //Get compatible builds only

            // CA2249: Usar string.Contains en lugar de string.IndexOf >= 0
            bool db2 = Files.Any(x => Path.GetExtension(x).Contains("db2", IGNORECASE)) || Files.Any(x => Path.GetExtension(x).Contains("adb", IGNORECASE));

            var files = Files.Select(x => Path.GetFileNameWithoutExtension(x).ToLower());

            var datasource = Database.Definitions.Tables
                                                 .Where(x => files.Contains(x.Name.ToLower()))
                                                 .Select(x => new { Key = x.Build, Value = x.BuildText })
                                                 .Distinct()
                                                 // IDE0075: Expresión booleana simplificada en lugar del operador ternario
                                                 .Where(x => !db2 || x.Key > (int)ExpansionFinalBuild.WotLK); // filter out non DB2/ADB clients

            // filter to the latest build for each version
            if (mostRecent)
                datasource = datasource.GroupBy(x => x.Value.Split('(').First()).Select(x => x.Aggregate((a, b) => a.Key > b.Key ? a : b));

            // order
            datasource = datasource.OrderBy(x => x.Key);


            lbDefinitions.BeginUpdate();

            if (!datasource.Any())
            {
                lbDefinitions.DataSource = null;
            }
            else
            {
                lbDefinitions.DataSource = new BindingSource(datasource, null);
                lbDefinitions.DisplayMember = "Value";
                lbDefinitions.ValueMember = "Key";
            }

            SetFileText();
            lbDefinitions.EndUpdate();
        }

        private void SetFileText()
        {
            lblFiles.Text = Files.Count() == 1 ? "1 file" : Files.Count() + " files";
        }

        private void ChkBuildFilter_CheckedChanged(object sender, EventArgs e)
        {
            LoadBuilds(!chkBuildFilter.Checked);
        }
    }
}
