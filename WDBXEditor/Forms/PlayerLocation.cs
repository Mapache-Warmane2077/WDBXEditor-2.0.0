using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using static WDBXEditor.Common.Constants;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using WDBXEditor.Reader;

namespace WDBXEditor.Forms
{
    public partial class PlayerLocation : Form
    {
        private Process proc = null;
        private MemoryReader reader = null;
        private readonly HashSet<OffsetMap> offsetmaps = [];
        private OffsetMap curmap;
        private readonly BindingSource _binding = [];
        private bool _closing = false;

        private uint FirstObject = 0;
        private ulong LocalGuid = 0;

        public PlayerLocation()
        {
            InitializeComponent();
        }

        private void PlayerLocation_Load(object sender, EventArgs e)
        {
            if (!InstanceManager.IsRunningAsAdmin())
            {
                panel1.Enabled = false;
                lblErr.Visible = true;
            }

            SetBindings();
            if (!LoadBuilds()) return;
            LoadProcesses();

            cbBuildSelector.SelectedIndex = 0;
        }

        #region Load/Save
        private bool LoadBuilds()
        {
            offsetmaps.Clear();
            cbBuildSelector.Items.Clear();

            if (File.Exists(OFFSET_MAP_PATH))
            {
                try
                {
                    string json = File.ReadAllText(OFFSET_MAP_PATH);
                    var offsets = JsonConvert.DeserializeObject<List<OffsetMap>>(json);
                    offsetmaps.UnionWith(offsets);
                }
                catch
                {
                    MessageBox.Show("Unable to read Offset file.");
                    return false;
                }
            }

            cbBuildSelector.DisplayMember = "Key";
            cbBuildSelector.ValueMember = "Value";

            cbBuildSelector.Items.Add(new KeyValuePair<string, OffsetMap>("Custom", new OffsetMap()));
            foreach (var map in offsetmaps.OrderBy(x => x.Name))
                cbBuildSelector.Items.Add(new KeyValuePair<string, OffsetMap>(map.Name, map));

            return true;
        }

        private void LoadProcesses()
        {
            cbProcessSelector.Items.Clear();
            cbProcessSelector.ValueMember = "Value";
            cbProcessSelector.DisplayMember = "Key";

            // CA2249: Simplificado usando Contains, el cual ahora soporta el parámetro de comparación
            var procs = Process.GetProcesses().Where(x => x.ProcessName.Contains("wow", IGNORECASE));
            foreach (var proc in procs)
                cbProcessSelector.Items.Add(new KeyValuePair<string, Process>($"{proc.ProcessName} ({proc.Id})", proc));

            cbProcessSelector.Items.Insert(0, new KeyValuePair<string, Process>("", null));
        }

        private void SetBindings()
        {
            _binding.DataSource = new OffsetMap();
            txtClientConnection.DataBindings.Add("Text", _binding, "ClientConnection", true);
            chkUseBase.DataBindings.Add("Checked", _binding, "UseBase");
            txtFirstObject.DataBindings.Add("Text", _binding, "FirstObjectOffset", true);
            txtGUID.DataBindings.Add("Text", _binding, "Guid", true);
            txtLocalGUID.DataBindings.Add("Text", _binding, "LocalGuidOffset", true);
            txtMapId.DataBindings.Add("Text", _binding, "MapID", true);
            txtNextObject.DataBindings.Add("Text", _binding, "NextObjectOffset", true);
            txtObjectManager.DataBindings.Add("Text", _binding, "ObjectManager", true);
            txtPosX.DataBindings.Add("Text", _binding, "Pos_X", true);
        }

        private void SaveBuilds()
        {
            string json = JsonConvert.SerializeObject(offsetmaps);
            using (var fs = File.CreateText(OFFSET_MAP_PATH))
                fs.Write(json);

            LoadBuilds();
            CbProcessSelector_SelectedIndexChanged(cbProcessSelector, null);
        }
        #endregion

        #region Dropdowns
        private void CbProcessSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            proc = ((KeyValuePair<string, Process>)cbProcessSelector.SelectedItem).Value;
            if (proc == null || proc.HasExited) //Process is unavailable
            {
                btnTarget.Enabled = false;
                cbBuildSelector.SelectedIndex = 0;
                LoadProcesses();
                return;
            }

            var version = proc.MainModule.FileVersionInfo.FilePrivatePart + (!Is64Bit(proc) ? " x86" : " x64");

            //Check if it exists
            cbBuildSelector.SelectedIndex = 0;
            for (int i = 0; i < cbBuildSelector.Items.Count; i++)
            {
                if (((KeyValuePair<string, OffsetMap>)cbBuildSelector.Items[i]).Key.Contains(version))
                {
                    cbBuildSelector.SelectedIndex = i;
                    break;
                }
            }

            //Add a new temporary item if not
            if (cbBuildSelector.SelectedIndex == 0)
            {
                var newmap = new KeyValuePair<string, OffsetMap>(version, new OffsetMap() { Name = version });
                cbBuildSelector.Items.Add(newmap);
                cbBuildSelector.SelectedItem = newmap;
            }

            btnTarget.Enabled = true;
        }

        private void CbBuildSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _binding.DataSource = ((KeyValuePair<string, OffsetMap>)cbBuildSelector.SelectedItem).Value;
            curmap = (OffsetMap)_binding.DataSource;
        }

        #endregion

        #region Button Events

        private void BtnTarget_Click(object sender, EventArgs e)
        {
            reader = new MemoryReader(proc);
            switch (LoadAddresses())
            {
                case ErrorReason.Gamestate:
                    MessageBox.Show("Could not read memory. Player must be in game.");
                    break;
                case ErrorReason.Invalid:
                    MessageBox.Show("Could not read memory. Invalid offsets or player not in game.");
                    break;
                case ErrorReason.None:
                    btnTarget.Enabled = false;
                    btnUntarget.Enabled = true;
                    break;
            }
        }

        private void BtnUntarget_Click(object sender, EventArgs e)
        {
            tmrLoop.Enabled = false;
            btnUntarget.Enabled = false;
            btnTarget.Enabled = true;
        }

        private void ChkAuto_CheckedChanged(object sender, EventArgs e)
        {
            tmrLoop.Enabled = chkAuto.Checked;
        }

        private void BtnGetPos_Click(object sender, EventArgs e)
        {
            if (!GetLocation())
                BtnUntarget_Click(btnUntarget, null); // Actualizado para coincidir con la nueva nomenclatura
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            curmap.UseBase = chkUseBase.Checked;
            curmap.ClientConnection = ParseOffset(txtClientConnection.Text);
            curmap.FirstObjectOffset = ParseOffset(txtFirstObject.Text);
            curmap.Guid = ParseOffset(txtGUID.Text);
            curmap.LocalGuidOffset = ParseOffset(txtLocalGUID.Text);
            curmap.MapID = ParseOffset(txtMapId.Text);
            curmap.NextObjectOffset = ParseOffset(txtNextObject.Text);
            curmap.ObjectManager = ParseOffset(txtObjectManager.Text);
            curmap.Pos_X = ParseOffset(txtPosX.Text);
            curmap.Pos_Y = curmap.Pos_X > 0 ? curmap.Pos_X + 4 : 0;
            curmap.Pos_Z = curmap.Pos_X > 0 ? curmap.Pos_X + 8 : 0;

            offsetmaps.RemoveWhere(x => x.Name == curmap.Name); //Remove old
            offsetmaps.Add(curmap); //Add new

            SaveBuilds();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(curmap.Name))
                return;

            if (MessageBox.Show($"Are you sure you wish to delete the offsets for {curmap.Name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                offsetmaps.RemoveWhere(x => x.Name == curmap.Name);
                SaveBuilds();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            cbProcessSelector.SelectedIndex = 0;
            LoadProcesses();
        }

        #endregion

        #region Memory Reading

        private ErrorReason LoadAddresses()
        {
            try
            {
                ulong clientcon = curmap.ClientConnection + (chkUseBase.Checked ? reader.BaseAddress : 0);
                var ClientConnection = reader.Read<uint>((IntPtr)(clientcon));
                var ObjectManager = ClientConnection;
                if (curmap.ObjectManager > 0)
                    ObjectManager = reader.Read<uint>((IntPtr)(ClientConnection + curmap.ObjectManager));

                FirstObject = reader.Read<uint>((IntPtr)(ObjectManager + curmap.FirstObjectOffset));
                LocalGuid = reader.Read<ulong>((IntPtr)(ObjectManager + curmap.LocalGuidOffset));
                return (LocalGuid != 0 ? ErrorReason.None : ErrorReason.Gamestate);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return ErrorReason.Invalid;
            }
        }

        private uint GetBaseByGuid(ulong Guid)
        {
            uint baseaddress = FirstObject;
            while (baseaddress != 0 && !proc.HasExited)
            {
                ulong guid = reader.Read<ulong>((IntPtr)(baseaddress + curmap.Guid));
                if (guid == Guid)
                    return baseaddress;

                baseaddress = reader.Read<uint>((IntPtr)(baseaddress + curmap.NextObjectOffset));
            }

            return 0;
        }

        private bool GetLocation()
        {
            var BaseAddress = GetBaseByGuid(LocalGuid);
            if (BaseAddress == 0 || proc.HasExited)
                return false;

            try
            {
                txtCurXPos.Text = reader.Read<float>((IntPtr)(BaseAddress + curmap.Pos_X)).ToString();
                txtCurYPos.Text = reader.Read<float>((IntPtr)(BaseAddress + curmap.Pos_X + 4)).ToString();
                txtCurZPos.Text = reader.Read<float>((IntPtr)(BaseAddress + curmap.Pos_X + 8)).ToString();
                txtCurMap.Text = reader.Read<uint>((IntPtr)curmap.MapID).ToString();
                return true;
            }
            catch { return false; }
        }

        private void TmrLoop_Tick(object sender, EventArgs e)
        {
            if (!GetLocation())
                BtnUntarget_Click(btnUntarget, null); // Actualizado para coincidir con la nueva nomenclatura
        }
        #endregion

        #region Form Events
        private void PlayerLocation_Activated(object sender, EventArgs e)
        {
            if (_closing) return;
            this.Opacity = 1;
        }

        private void PlayerLocation_Deactivate(object sender, EventArgs e)
        {
            if (_closing) return;
            this.Opacity = 0.75f;
        }

        private void PlayerLocation_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
        }
        #endregion


        private void Offset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = ((TextBox)sender).Text.ToUpper();
            ulong dmp;
            if (text.StartsWith("0X"))
            {
                try
                {
                    dmp = (ulong)new System.ComponentModel.UInt64Converter().ConvertFromString(text);
                }
                catch
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                if (!ulong.TryParse(text, out dmp))
                {
                    e.Cancel = true;
                    return;
                }
            }

            ((TextBox)sender).Text = dmp.ToString();
        }

        private static ulong ParseOffset(string text)
        {

            if (string.IsNullOrWhiteSpace(text)) //Empty string
                return 0;

            if (ulong.TryParse(text, out ulong dmp)) //Normal number
                return dmp;

            if (text.StartsWith("0x") && text.Length > 2) text = text[2..]; //Remove hex prefix
            if (ulong.TryParse(text, NumberStyles.HexNumber, null, out dmp)) //Hex formatted number
                return dmp;

            return 0;
        }

        public static bool Is64Bit(Process process)
        {
            if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "x86")
                return false;

            byte[] data = new byte[4096];

            // CA1859: Declarado explícitamente como FileStream en lugar de la clase base genérica
            using (FileStream s = new(process.MainModule.FileName, FileMode.Open, FileAccess.Read))
                s.Read(data, 0, 4096);

            int PE_HEADER_ADDR = BitConverter.ToInt32(data, 0x3C);
            return BitConverter.ToUInt16(data, PE_HEADER_ADDR + 0x4) != 0x014c; //32bit check
        }

        internal class OffsetMap
        {
            public string Name { get; set; }
            public bool UseBase { get; set; }
            public ulong ClientConnection { get; set; }
            public ulong ObjectManager { get; set; }
            public ulong FirstObjectOffset { get; set; }
            public ulong LocalGuidOffset { get; set; }
            public ulong NextObjectOffset { get; set; }
            public ulong MapID { get; set; }
            public ulong Pos_X { get; set; }
            public ulong Pos_Y { get; set; }
            public ulong Pos_Z { get; set; }
            public ulong Guid { get; set; }
        }

        internal enum ErrorReason
        {
            Invalid,
            Gamestate,
            None
        }

    }
}
