using AdvancedDataGridView;
using WDBXEditor.Common;

namespace WDBXEditor
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            gbFiles = new System.Windows.Forms.GroupBox();
            gbFilter = new System.Windows.Forms.GroupBox();
            btnReset = new System.Windows.Forms.Button();
            cbBuild = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            txtFilter = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            lbFiles = new BufferedListBox();
            filecontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            gbSettings = new System.Windows.Forms.GroupBox();
            lblCurrentProcess = new System.Windows.Forms.Label();
            progressBar = new AutoProgressBar();
            txtStats = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtCurrentCell = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtCurDefinition = new System.Windows.Forms.TextBox();
            txtCurEntry = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFromMPQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFromCASCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toSQLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toMPQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fromSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            fromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            editDefinitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            wotLKItemFixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            wdb5ParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            playerLocationRecorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            colourPickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            EspañolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            PortuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FrançaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DeutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            PусскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ItalianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            한국어ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            label3 = new System.Windows.Forms.Label();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            gotoIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            viewInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            insertLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            advancedDataGridView = new AdvancedDataGridView.AdvancedDataGridView();
            cbColumnMode = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            columnFilter = new DropdownCheckList();
            darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            gbFiles.SuspendLayout();
            gbFilter.SuspendLayout();
            filecontextMenuStrip.SuspendLayout();
            gbSettings.SuspendLayout();
            menuStrip.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView).BeginInit();
            SuspendLayout();
            // 
            // gbFiles
            // 
            gbFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbFiles.Controls.Add(gbFilter);
            gbFiles.Controls.Add(lbFiles);
            gbFiles.Location = new System.Drawing.Point(14, 452);
            gbFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFiles.Name = "gbFiles";
            gbFiles.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFiles.Size = new System.Drawing.Size(821, 227);
            gbFiles.TabIndex = 1;
            gbFiles.TabStop = false;
            gbFiles.Text = "Files";
            // 
            // gbFilter
            // 
            gbFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            gbFilter.Controls.Add(btnReset);
            gbFilter.Controls.Add(cbBuild);
            gbFilter.Controls.Add(label6);
            gbFilter.Controls.Add(txtFilter);
            gbFilter.Controls.Add(label7);
            gbFilter.Location = new System.Drawing.Point(490, 22);
            gbFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFilter.Name = "gbFilter";
            gbFilter.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFilter.Size = new System.Drawing.Size(302, 198);
            gbFilter.TabIndex = 10;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter";
            // 
            // btnReset
            // 
            btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReset.Location = new System.Drawing.Point(157, 80);
            btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(137, 27);
            btnReset.TabIndex = 9;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnReset_Click;
            // 
            // cbBuild
            // 
            cbBuild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBuild.FormattingEnabled = true;
            cbBuild.Location = new System.Drawing.Point(98, 51);
            cbBuild.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbBuild.Name = "cbBuild";
            cbBuild.Size = new System.Drawing.Size(196, 23);
            cbBuild.TabIndex = 4;
            cbBuild.SelectedIndexChanged += CbBuild_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 55);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(34, 15);
            label6.TabIndex = 3;
            label6.Text = "Build";
            // 
            // txtFilter
            // 
            txtFilter.Location = new System.Drawing.Point(98, 22);
            txtFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new System.Drawing.Size(196, 23);
            txtFilter.TabIndex = 2;
            txtFilter.TextChanged += TxtFilter_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 25);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(33, 15);
            label7.TabIndex = 1;
            label7.Text = "Filter";
            // 
            // lbFiles
            // 
            lbFiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbFiles.FormattingEnabled = true;
            lbFiles.ItemHeight = 15;
            lbFiles.Location = new System.Drawing.Point(7, 22);
            lbFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new System.Drawing.Size(459, 199);
            lbFiles.Sorted = true;
            lbFiles.TabIndex = 1;
            lbFiles.MouseDoubleClick += LbFiles_MouseDoubleClick;
            lbFiles.MouseDown += LbFiles_MouseDown;
            // 
            // filecontextMenuStrip
            // 
            filecontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { editToolStripMenuItem1, closeToolStripMenuItem1 });
            filecontextMenuStrip.Name = "filecontextMenuStrip";
            filecontextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // editToolStripMenuItem1
            // 
            editToolStripMenuItem1.Image = Properties.Resources.sqlfile;
            editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            editToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            editToolStripMenuItem1.Text = "Edit";
            editToolStripMenuItem1.Click += EditToolStripMenuItem1_Click;
            // 
            // closeToolStripMenuItem1
            // 
            closeToolStripMenuItem1.Image = Properties.Resources.close;
            closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            closeToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            closeToolStripMenuItem1.Text = "Close";
            closeToolStripMenuItem1.Click += CloseToolStripMenuItem1_Click;
            // 
            // gbSettings
            // 
            gbSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            gbSettings.Controls.Add(lblCurrentProcess);
            gbSettings.Controls.Add(progressBar);
            gbSettings.Controls.Add(txtStats);
            gbSettings.Controls.Add(label5);
            gbSettings.Controls.Add(txtCurrentCell);
            gbSettings.Controls.Add(label4);
            gbSettings.Controls.Add(txtCurDefinition);
            gbSettings.Controls.Add(txtCurEntry);
            gbSettings.Controls.Add(label2);
            gbSettings.Controls.Add(label1);
            gbSettings.Location = new System.Drawing.Point(828, 452);
            gbSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSettings.Name = "gbSettings";
            gbSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSettings.Size = new System.Drawing.Size(298, 227);
            gbSettings.TabIndex = 2;
            gbSettings.TabStop = false;
            gbSettings.Text = "Statistics";
            // 
            // lblCurrentProcess
            // 
            lblCurrentProcess.AutoSize = true;
            lblCurrentProcess.Location = new System.Drawing.Point(7, 179);
            lblCurrentProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCurrentProcess.Name = "lblCurrentProcess";
            lblCurrentProcess.Size = new System.Drawing.Size(38, 15);
            lblCurrentProcess.TabIndex = 11;
            lblCurrentProcess.Text = "label9";
            lblCurrentProcess.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(10, 197);
            progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(251, 23);
            progressBar.TabIndex = 10;
            // 
            // txtStats
            // 
            txtStats.Location = new System.Drawing.Point(110, 112);
            txtStats.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtStats.Name = "txtStats";
            txtStats.ReadOnly = true;
            txtStats.Size = new System.Drawing.Size(172, 23);
            txtStats.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 115);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(35, 15);
            label5.TabIndex = 6;
            label5.Text = "Stats:";
            // 
            // txtCurrentCell
            // 
            txtCurrentCell.Location = new System.Drawing.Point(110, 83);
            txtCurrentCell.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCurrentCell.Name = "txtCurrentCell";
            txtCurrentCell.ReadOnly = true;
            txtCurrentCell.Size = new System.Drawing.Size(172, 23);
            txtCurrentCell.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 85);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 15);
            label4.TabIndex = 4;
            label4.Text = "Current Cell:";
            // 
            // txtCurDefinition
            // 
            txtCurDefinition.Location = new System.Drawing.Point(110, 51);
            txtCurDefinition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCurDefinition.Name = "txtCurDefinition";
            txtCurDefinition.ReadOnly = true;
            txtCurDefinition.Size = new System.Drawing.Size(172, 23);
            txtCurDefinition.TabIndex = 3;
            // 
            // txtCurEntry
            // 
            txtCurEntry.Location = new System.Drawing.Point(110, 22);
            txtCurEntry.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtCurEntry.Name = "txtCurEntry";
            txtCurEntry.ReadOnly = true;
            txtCurEntry.Size = new System.Drawing.Size(172, 23);
            txtCurEntry.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 55);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "Definition:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 25);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Current File:";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, exportToolStripMenuItem, importToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip.Size = new System.Drawing.Size(1140, 24);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { loadFilesToolStripMenuItem, openFromMPQToolStripMenuItem, openFromCASCToolStripMenuItem, recentToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, saveAllToolStripMenuItem, reloadToolStripMenuItem, closeToolStripMenuItem, closeAllToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadFilesToolStripMenuItem
            // 
            loadFilesToolStripMenuItem.Image = Properties.Resources.open;
            loadFilesToolStripMenuItem.Name = "loadFilesToolStripMenuItem";
            loadFilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            loadFilesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            loadFilesToolStripMenuItem.Text = "Open File(s)";
            loadFilesToolStripMenuItem.Click += LoadFilesToolStripMenuItem_Click;
            // 
            // openFromMPQToolStripMenuItem
            // 
            openFromMPQToolStripMenuItem.Image = Properties.Resources.open;
            openFromMPQToolStripMenuItem.Name = "openFromMPQToolStripMenuItem";
            openFromMPQToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            openFromMPQToolStripMenuItem.Text = "Open from MPQ";
            openFromMPQToolStripMenuItem.Click += OpenFromMPQToolStripMenuItem_Click;
            // 
            // openFromCASCToolStripMenuItem
            // 
            openFromCASCToolStripMenuItem.Image = Properties.Resources.open;
            openFromCASCToolStripMenuItem.Name = "openFromCASCToolStripMenuItem";
            openFromCASCToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            openFromCASCToolStripMenuItem.Text = "Open from CASC";
            openFromCASCToolStripMenuItem.Click += OpenFromCASCToolStripMenuItem_Click;
            // 
            // recentToolStripMenuItem
            // 
            recentToolStripMenuItem.Image = Properties.Resources.open;
            recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            recentToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            recentToolStripMenuItem.Text = "Recent Files";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = Properties.Resources.save_file;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Image = Properties.Resources.save_file;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // saveAllToolStripMenuItem
            // 
            saveAllToolStripMenuItem.Image = Properties.Resources.save_file;
            saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            saveAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.S;
            saveAllToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            saveAllToolStripMenuItem.Text = "Save All";
            saveAllToolStripMenuItem.Click += SaveAllToolStripMenuItem_Click;
            // 
            // reloadToolStripMenuItem
            // 
            reloadToolStripMenuItem.Image = Properties.Resources.reload;
            reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            reloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            reloadToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            reloadToolStripMenuItem.Text = "Reload";
            reloadToolStripMenuItem.Click += ReloadToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Image = Properties.Resources.close;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W;
            closeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Image = Properties.Resources.close;
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.W;
            closeAllToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            closeAllToolStripMenuItem.Text = "Close All";
            closeAllToolStripMenuItem.Click += CloseAllToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newLineToolStripMenuItem, toolStripSeparator4, undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, goToToolStripMenuItem, toolStripSeparator2, findToolStripMenuItem, replaceToolStripMenuItem, insertToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // newLineToolStripMenuItem
            // 
            newLineToolStripMenuItem.Name = "newLineToolStripMenuItem";
            newLineToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            newLineToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            newLineToolStripMenuItem.Text = "New Line";
            newLineToolStripMenuItem.Click += NewLineToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(209, 6);
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z;
            undoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Z;
            redoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += RedoToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // goToToolStripMenuItem
            // 
            goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            goToToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G;
            goToToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            goToToolStripMenuItem.Text = "&Go To...";
            goToToolStripMenuItem.Click += GotoIdToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // findToolStripMenuItem
            // 
            findToolStripMenuItem.Name = "findToolStripMenuItem";
            findToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F;
            findToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            findToolStripMenuItem.Text = "&Find...";
            findToolStripMenuItem.Click += FindToolStripMenuItem_Click;
            // 
            // replaceToolStripMenuItem
            // 
            replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            replaceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H;
            replaceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            replaceToolStripMenuItem.Text = "&Replace...";
            replaceToolStripMenuItem.Click += ReplaceToolStripMenuItem_Click;
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I;
            insertToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            insertToolStripMenuItem.Text = "Insert Line";
            insertToolStripMenuItem.Click += InsertToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toSQLToolStripMenuItem, toSQLFileToolStripMenuItem, toCSVToolStripMenuItem, toMPQToolStripMenuItem, toJSONToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            exportToolStripMenuItem.Text = "Export";
            // 
            // toSQLToolStripMenuItem
            // 
            toSQLToolStripMenuItem.Image = Properties.Resources.sql;
            toSQLToolStripMenuItem.Name = "toSQLToolStripMenuItem";
            toSQLToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            toSQLToolStripMenuItem.Text = "To SQL";
            toSQLToolStripMenuItem.Click += ToSQLToolStripMenuItem_Click;
            // 
            // toSQLFileToolStripMenuItem
            // 
            toSQLFileToolStripMenuItem.Image = Properties.Resources.sqlfile;
            toSQLFileToolStripMenuItem.Name = "toSQLFileToolStripMenuItem";
            toSQLFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            toSQLFileToolStripMenuItem.Text = "To SQL File";
            toSQLFileToolStripMenuItem.Click += ToSQLFileToolStripMenuItem_Click;
            // 
            // toCSVToolStripMenuItem
            // 
            toCSVToolStripMenuItem.Image = Properties.Resources.csv;
            toCSVToolStripMenuItem.Name = "toCSVToolStripMenuItem";
            toCSVToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            toCSVToolStripMenuItem.Text = "To CSV";
            toCSVToolStripMenuItem.Click += ToCSVToolStripMenuItem_Click;
            // 
            // toMPQToolStripMenuItem
            // 
            toMPQToolStripMenuItem.Image = Properties.Resources.sqlfile;
            toMPQToolStripMenuItem.Name = "toMPQToolStripMenuItem";
            toMPQToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            toMPQToolStripMenuItem.Text = "To MPQ";
            toMPQToolStripMenuItem.Click += ToMPQToolStripMenuItem_Click;
            // 
            // toJSONToolStripMenuItem
            // 
            toJSONToolStripMenuItem.Image = Properties.Resources.sqlfile;
            toJSONToolStripMenuItem.Name = "toJSONToolStripMenuItem";
            toJSONToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            toJSONToolStripMenuItem.Text = "To JSON";
            toJSONToolStripMenuItem.Click += ToJSONToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { fromSQLToolStripMenuItem, fromCSVToolStripMenuItem });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            importToolStripMenuItem.Text = "Import";
            // 
            // fromSQLToolStripMenuItem
            // 
            fromSQLToolStripMenuItem.Image = Properties.Resources.sql;
            fromSQLToolStripMenuItem.Name = "fromSQLToolStripMenuItem";
            fromSQLToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            fromSQLToolStripMenuItem.Text = "From SQL";
            fromSQLToolStripMenuItem.Click += FromSQLToolStripMenuItem_Click;
            // 
            // fromCSVToolStripMenuItem
            // 
            fromCSVToolStripMenuItem.Image = Properties.Resources.csv;
            fromCSVToolStripMenuItem.Name = "fromCSVToolStripMenuItem";
            fromCSVToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            fromCSVToolStripMenuItem.Text = "From CSV";
            fromCSVToolStripMenuItem.Click += FromCSVToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { editDefinitionsToolStripMenuItem, wotLKItemFixToolStripMenuItem, wdb5ParserToolStripMenuItem, playerLocationRecorderToolStripMenuItem, colourPickerToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            optionsToolStripMenuItem.Text = "Tools";
            // 
            // editDefinitionsToolStripMenuItem
            // 
            editDefinitionsToolStripMenuItem.Image = Properties.Resources.load_definition;
            editDefinitionsToolStripMenuItem.Name = "editDefinitionsToolStripMenuItem";
            editDefinitionsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            editDefinitionsToolStripMenuItem.Text = "Definition Editor";
            editDefinitionsToolStripMenuItem.Click += EditDefinitionsToolStripMenuItem_Click;
            // 
            // wotLKItemFixToolStripMenuItem
            // 
            wotLKItemFixToolStripMenuItem.Enabled = false;
            wotLKItemFixToolStripMenuItem.Image = Properties.Resources.sql;
            wotLKItemFixToolStripMenuItem.Name = "wotLKItemFixToolStripMenuItem";
            wotLKItemFixToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            wotLKItemFixToolStripMenuItem.Text = "WotLK Item Import";
            wotLKItemFixToolStripMenuItem.Click += WotLKItemFixToolStripMenuItem_Click;
            // 
            // wdb5ParserToolStripMenuItem
            // 
            wdb5ParserToolStripMenuItem.Image = Properties.Resources.table;
            wdb5ParserToolStripMenuItem.Name = "wdb5ParserToolStripMenuItem";
            wdb5ParserToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            wdb5ParserToolStripMenuItem.Text = "Legion Parser";
            wdb5ParserToolStripMenuItem.Visible = false;
            wdb5ParserToolStripMenuItem.Click += LegionToolStripMenuItem_Click;
            // 
            // playerLocationRecorderToolStripMenuItem
            // 
            playerLocationRecorderToolStripMenuItem.Image = Properties.Resources.target;
            playerLocationRecorderToolStripMenuItem.Name = "playerLocationRecorderToolStripMenuItem";
            playerLocationRecorderToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            playerLocationRecorderToolStripMenuItem.Text = "Player Location Recorder";
            playerLocationRecorderToolStripMenuItem.Click += PlayerLocationRecorderToolStripMenuItem_Click;
            // 
            // colourPickerToolStripMenuItem
            // 
            colourPickerToolStripMenuItem.Enabled = false;
            colourPickerToolStripMenuItem.Image = Properties.Resources.paintbrush;
            colourPickerToolStripMenuItem.Name = "colourPickerToolStripMenuItem";
            colourPickerToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            colourPickerToolStripMenuItem.Text = "Colour Picker";
            colourPickerToolStripMenuItem.Click += ColourPickerToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { helpToolStripMenuItem1, aboutToolStripMenuItem, idiomaToolStripMenuItem, darkModeToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            helpToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            helpToolStripMenuItem1.Text = "Help";
            helpToolStripMenuItem1.Click += HelpToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // idiomaToolStripMenuItem
            // 
            idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { EspañolToolStripMenuItem, EnglishToolStripMenuItem, PortuguêsToolStripMenuItem, FrançaisToolStripMenuItem, DeutschToolStripMenuItem, PусскийToolStripMenuItem, ItalianoToolStripMenuItem, 中文ToolStripMenuItem, 한국어ToolStripMenuItem });
            idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            idiomaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            idiomaToolStripMenuItem.Text = "Language";
            // 
            // EspañolToolStripMenuItem
            // 
            EspañolToolStripMenuItem.Name = "EspañolToolStripMenuItem";
            EspañolToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            EspañolToolStripMenuItem.Text = "Español";
            EspañolToolStripMenuItem.Click += EspañolToolStripMenuItem_Click;
            // 
            // EnglishToolStripMenuItem
            // 
            EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            EnglishToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            EnglishToolStripMenuItem.Text = "English";
            EnglishToolStripMenuItem.Click += EnglishToolStripMenuItem_Click;
            // 
            // PortuguêsToolStripMenuItem
            // 
            PortuguêsToolStripMenuItem.Name = "PortuguêsToolStripMenuItem";
            PortuguêsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            PortuguêsToolStripMenuItem.Text = "Português";
            PortuguêsToolStripMenuItem.Click += PortuguêsToolStripMenuItem_Click;
            // 
            // FrançaisToolStripMenuItem
            // 
            FrançaisToolStripMenuItem.Name = "FrançaisToolStripMenuItem";
            FrançaisToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            FrançaisToolStripMenuItem.Text = "Français";
            FrançaisToolStripMenuItem.Click += FrançaisToolStripMenuItem_Click;
            // 
            // DeutschToolStripMenuItem
            // 
            DeutschToolStripMenuItem.Name = "DeutschToolStripMenuItem";
            DeutschToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            DeutschToolStripMenuItem.Text = "Deutsch";
            DeutschToolStripMenuItem.Click += DeutschToolStripMenuItem_Click;
            // 
            // PусскийToolStripMenuItem
            // 
            PусскийToolStripMenuItem.Name = "PусскийToolStripMenuItem";
            PусскийToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            PусскийToolStripMenuItem.Text = "Pусский";
            PусскийToolStripMenuItem.Click += PусскийToolStripMenuItem_Click;
            // 
            // ItalianoToolStripMenuItem
            // 
            ItalianoToolStripMenuItem.Name = "ItalianoToolStripMenuItem";
            ItalianoToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            ItalianoToolStripMenuItem.Text = "Italiano";
            ItalianoToolStripMenuItem.Click += ItalianoToolStripMenuItem_Click;
            // 
            // 中文ToolStripMenuItem
            // 
            中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            中文ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            中文ToolStripMenuItem.Text = "中文";
            中文ToolStripMenuItem.Click += 中文ToolStripMenuItem_Click;
            // 
            // 한국어ToolStripMenuItem
            // 
            한국어ToolStripMenuItem.Name = "한국어ToolStripMenuItem";
            한국어ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            한국어ToolStripMenuItem.Text = "한국어";
            한국어ToolStripMenuItem.Click += 한국어ToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "DBC Files|*.dbc|DB2 Files|*.db2|All Files (*.db*)|*.db*";
            openFileDialog.Multiselect = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(760, 4);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(58, 15);
            label3.TabIndex = 9;
            label3.Text = "Columns:";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { gotoIdToolStripMenuItem, toolStripSeparator1, viewInEditorToolStripMenuItem, toolStripSeparator5, copyToolStripMenuItem, pasteToolStripMenuItem, insertLineToolStripMenuItem, clearLineToolStripMenuItem, deleteLineToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(171, 170);
            // 
            // gotoIdToolStripMenuItem
            // 
            gotoIdToolStripMenuItem.Name = "gotoIdToolStripMenuItem";
            gotoIdToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G;
            gotoIdToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            gotoIdToolStripMenuItem.Text = "&Go To...";
            gotoIdToolStripMenuItem.Click += GotoIdToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // viewInEditorToolStripMenuItem
            // 
            viewInEditorToolStripMenuItem.Name = "viewInEditorToolStripMenuItem";
            viewInEditorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            viewInEditorToolStripMenuItem.Text = "View in Text Editor";
            viewInEditorToolStripMenuItem.Click += ViewInEditorToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(167, 6);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            copyToolStripMenuItem.Text = "&Copy Line";
            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            pasteToolStripMenuItem.Text = "&Paste Line";
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            // 
            // insertLineToolStripMenuItem
            // 
            insertLineToolStripMenuItem.Name = "insertLineToolStripMenuItem";
            insertLineToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I;
            insertLineToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            insertLineToolStripMenuItem.Text = "Insert Line";
            insertLineToolStripMenuItem.Click += InsertLineToolStripMenuItem_Click;
            // 
            // clearLineToolStripMenuItem
            // 
            clearLineToolStripMenuItem.Name = "clearLineToolStripMenuItem";
            clearLineToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            clearLineToolStripMenuItem.Text = "Clear Line";
            clearLineToolStripMenuItem.Click += ClearLineToolStripMenuItem_Click;
            // 
            // deleteLineToolStripMenuItem
            // 
            deleteLineToolStripMenuItem.Name = "deleteLineToolStripMenuItem";
            deleteLineToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            deleteLineToolStripMenuItem.Text = "Delete Line";
            deleteLineToolStripMenuItem.Click += DeleteLineToolStripMenuItem_Click;
            // 
            // advancedDataGridView
            // 
            advancedDataGridView.AllowDrop = true;
            advancedDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            advancedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            advancedDataGridView.EnableHeadersVisualStyles = false;
            advancedDataGridView.FilterAndSortEnabled = true;
            advancedDataGridView.HeaderContext = null;
            advancedDataGridView.Location = new System.Drawing.Point(14, 31);
            advancedDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            advancedDataGridView.Name = "advancedDataGridView";
            advancedDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            advancedDataGridView.RowTemplate.Height = 18;
            advancedDataGridView.Size = new System.Drawing.Size(1112, 414);
            advancedDataGridView.TabIndex = 0;
            advancedDataGridView.SortStringChanged += AdvancedDataGridView_SortStringChanged;
            advancedDataGridView.FilterStringChanged += AdvancedDataGridView_FilterStringChanged;
            advancedDataGridView.UndoRedoChanged += AdvancedDataGridView_UndoRedoChanged;
            advancedDataGridView.CellValueChanged += AdvancedDataGridView_CellValueChanged;
            advancedDataGridView.CurrentCellChanged += AdvancedDataGridView_CurrentCellChanged;
            advancedDataGridView.DataBindingComplete += AdvancedDataGridView_DataBindingComplete;
            advancedDataGridView.RowsAdded += AdvancedDataGridView_RowsAdded;
            advancedDataGridView.RowsRemoved += AdvancedDataGridView_RowsRemoved;
            advancedDataGridView.DragDrop += AdvancedDataGridView_DragDrop;
            advancedDataGridView.DragEnter += AdvancedDataGridView_DragEnter;
            advancedDataGridView.MouseDown += AdvancedDataGridView_MouseDown;
            // 
            // cbColumnMode
            // 
            cbColumnMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbColumnMode.FormattingEnabled = true;
            cbColumnMode.Location = new System.Drawing.Point(540, 2);
            cbColumnMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbColumnMode.Name = "cbColumnMode";
            cbColumnMode.Size = new System.Drawing.Size(192, 23);
            cbColumnMode.TabIndex = 10;
            cbColumnMode.SelectedIndexChanged += CbColumnMode_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(425, 4);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(92, 15);
            label8.TabIndex = 11;
            label8.Text = "Columns Mode:";
            // 
            // columnFilter
            // 
            columnFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            columnFilter.ListHeight = 200;
            columnFilter.Location = new System.Drawing.Point(835, 2);
            columnFilter.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            columnFilter.Name = "columnFilter";
            columnFilter.Size = new System.Drawing.Size(291, 24);
            columnFilter.TabIndex = 8;
            columnFilter.TabStop = false;
            columnFilter.ItemCheckChanged += ColumnFilter_ItemCheckChanged;
            columnFilter.HideEmptyPressed += ColumnFilter_HideEmptyPressed;
            // 
            // darkModeToolStripMenuItem
            // 
            darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            darkModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            darkModeToolStripMenuItem.Text = "Dark Mode";
            darkModeToolStripMenuItem.Click += DarkModeToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1140, 693);
            Controls.Add(label8);
            Controls.Add(cbColumnMode);
            Controls.Add(label3);
            Controls.Add(columnFilter);
            Controls.Add(gbSettings);
            Controls.Add(gbFiles);
            Controls.Add(advancedDataGridView);
            Controls.Add(menuStrip);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1117, 732);
            Name = "Main";
            Tag = "";
            Text = "WDBX Editor";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            gbFiles.ResumeLayout(false);
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            filecontextMenuStrip.ResumeLayout(false);
            gbSettings.ResumeLayout(false);
            gbSettings.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private AdvancedDataGridView.AdvancedDataGridView advancedDataGridView;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFilesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private BufferedListBox lbFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurDefinition;
        private System.Windows.Forms.TextBox txtCurEntry;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private DropdownCheckList columnFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem toSQLFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDefinitionsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCurrentCell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStats;
        private System.Windows.Forms.ToolStripMenuItem openFromMPQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toMPQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFromCASCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wotLKItemFixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wdb5ParserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private AutoProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip filecontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbBuild;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem deleteLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerLocationRecorderToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbColumnMode;
        private System.Windows.Forms.ToolStripMenuItem colourPickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label lblCurrentProcess;
		private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EspañolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PortuguêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrançaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PусскийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItalianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 한국어ToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
    }
}

