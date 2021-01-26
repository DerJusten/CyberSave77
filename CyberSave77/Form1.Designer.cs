
namespace CyberSave77
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bgwCheckProcess = new System.ComponentModel.BackgroundWorker();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelCredit = new System.Windows.Forms.Panel();
            this.panelRightSide = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.modernButtonDebug = new CyberSave77.ModernButton();
            this.label9 = new System.Windows.Forms.Label();
            this.modernButtonStart = new CyberSave77.ModernButton();
            this.modernButtonStop = new CyberSave77.ModernButton();
            this.modernButtonExit = new CyberSave77.ModernButton();
            this.panelSettings = new CyberSave77.DrawPanel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelState = new System.Windows.Forms.Label();
            this.panelSettingsRunDisable = new System.Windows.Forms.Panel();
            this.pictureBoxSvgMgr = new System.Windows.Forms.PictureBox();
            this.checkBoxEnableAutosave = new System.Windows.Forms.CheckBox();
            this.groupBoxAutosave = new System.Windows.Forms.GroupBox();
            this.numericUpDownTryAutoQuickSave = new System.Windows.Forms.NumericUpDown();
            this.labelAutosve = new System.Windows.Forms.Label();
            this.pictureBoxAddSettings = new System.Windows.Forms.PictureBox();
            this.checkBoxEnableSaveGameHistory = new System.Windows.Forms.CheckBox();
            this.groupBoxExtraSavegames = new System.Windows.Forms.GroupBox();
            this.numericUpDownMinSaveGames = new System.Windows.Forms.NumericUpDown();
            this.labelSaveGameTimeDif = new System.Windows.Forms.Label();
            this.checkBoxEnableAppsOnStart = new System.Windows.Forms.CheckBox();
            this.groupBoxAddApplication = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxAdd = new System.Windows.Forms.PictureBox();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.pictureBoxDelete = new System.Windows.Forms.PictureBox();
            this.listBoxProcess = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBoxCloseToTray = new System.Windows.Forms.CheckBox();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.checkBoxHideStatusLog = new System.Windows.Forms.CheckBox();
            this.checkBoxMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.cmsNotifyIcon.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelCredit.SuspendLayout();
            this.panelRightSide.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.panelSettingsRunDisable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSvgMgr)).BeginInit();
            this.groupBoxAutosave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTryAutoQuickSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddSettings)).BeginInit();
            this.groupBoxExtraSavegames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinSaveGames)).BeginInit();
            this.groupBoxAddApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwCheckProcess
            // 
            this.bgwCheckProcess.WorkerReportsProgress = true;
            this.bgwCheckProcess.WorkerSupportsCancellation = true;
            this.bgwCheckProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckProcess_DoWork);
            this.bgwCheckProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckProcess_ProgressChanged);
            this.bgwCheckProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCheckProcess_RunWorkerCompleted);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLog.Location = new System.Drawing.Point(7, 9);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(360, 494);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsNotifyIcon;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsNotifyIcon
            // 
            this.cmsNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.startToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cmsNotifyIcon.Name = "cmsNotifyIcon";
            this.cmsNotifyIcon.Size = new System.Drawing.Size(104, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(71, 1);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(105, 13);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "creators of CyberCAT";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-1, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Buttons by the";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(239, 1);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Kiranshastry";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "| UI Icons by ";
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelCredit);
            this.panelAll.Controls.Add(this.panelRightSide);
            this.panelAll.Controls.Add(this.textBoxLog);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(756, 526);
            this.panelAll.TabIndex = 6;
            // 
            // panelCredit
            // 
            this.panelCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelCredit.Controls.Add(this.label8);
            this.panelCredit.Controls.Add(this.linkLabel2);
            this.panelCredit.Controls.Add(this.linkLabel1);
            this.panelCredit.Controls.Add(this.label7);
            this.panelCredit.Location = new System.Drawing.Point(6, 509);
            this.panelCredit.Name = "panelCredit";
            this.panelCredit.Size = new System.Drawing.Size(305, 15);
            this.panelCredit.TabIndex = 7;
            // 
            // panelRightSide
            // 
            this.panelRightSide.Controls.Add(this.panelButton);
            this.panelRightSide.Controls.Add(this.panelSettings);
            this.panelRightSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightSide.Location = new System.Drawing.Point(376, 0);
            this.panelRightSide.Name = "panelRightSide";
            this.panelRightSide.Size = new System.Drawing.Size(380, 526);
            this.panelRightSide.TabIndex = 14;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.modernButtonDebug);
            this.panelButton.Controls.Add(this.label9);
            this.panelButton.Controls.Add(this.modernButtonStart);
            this.panelButton.Controls.Add(this.modernButtonStop);
            this.panelButton.Controls.Add(this.modernButtonExit);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 454);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(380, 72);
            this.panelButton.TabIndex = 13;
            // 
            // modernButtonDebug
            // 
            this.modernButtonDebug.BackColor = System.Drawing.Color.White;
            this.modernButtonDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonDebug.ClickEffectEnabled = true;
            this.modernButtonDebug.DefaultColor = System.Drawing.Color.White;
            this.modernButtonDebug.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonDebug.Location = new System.Drawing.Point(205, 3);
            this.modernButtonDebug.Name = "modernButtonDebug";
            this.modernButtonDebug.Size = new System.Drawing.Size(67, 46);
            this.modernButtonDebug.TabIndex = 15;
            this.modernButtonDebug.Text = "Debug";
            this.modernButtonDebug.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonDebug.TextFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonDebug.Visible = false;
            this.modernButtonDebug.Click += new System.EventHandler(this.modernButtonDebug_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(316, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "DJ [200121]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // modernButtonStart
            // 
            this.modernButtonStart.BackColor = System.Drawing.Color.White;
            this.modernButtonStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonStart.ClickEffectEnabled = true;
            this.modernButtonStart.DefaultColor = System.Drawing.Color.White;
            this.modernButtonStart.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonStart.Location = new System.Drawing.Point(7, 3);
            this.modernButtonStart.Name = "modernButtonStart";
            this.modernButtonStart.Size = new System.Drawing.Size(95, 46);
            this.modernButtonStart.TabIndex = 8;
            this.modernButtonStart.Text = "Start";
            this.modernButtonStart.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonStart.TextFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // modernButtonStop
            // 
            this.modernButtonStop.BackColor = System.Drawing.Color.White;
            this.modernButtonStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonStop.ClickEffectEnabled = true;
            this.modernButtonStop.DefaultColor = System.Drawing.Color.White;
            this.modernButtonStop.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonStop.Location = new System.Drawing.Point(118, 3);
            this.modernButtonStop.Name = "modernButtonStop";
            this.modernButtonStop.Size = new System.Drawing.Size(81, 46);
            this.modernButtonStop.TabIndex = 9;
            this.modernButtonStop.Text = "Stop";
            this.modernButtonStop.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonStop.TextFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonStop.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // modernButtonExit
            // 
            this.modernButtonExit.BackColor = System.Drawing.Color.White;
            this.modernButtonExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonExit.ClickEffectEnabled = true;
            this.modernButtonExit.DefaultColor = System.Drawing.Color.White;
            this.modernButtonExit.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonExit.Location = new System.Drawing.Point(276, 3);
            this.modernButtonExit.Name = "modernButtonExit";
            this.modernButtonExit.Size = new System.Drawing.Size(87, 46);
            this.modernButtonExit.TabIndex = 10;
            this.modernButtonExit.Text = "Exit";
            this.modernButtonExit.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonExit.TextFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSettings.AutoScroll = true;
            this.panelSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSettings.Controls.Add(this.groupBoxSettings);
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(380, 448);
            this.panelSettings.TabIndex = 5;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelState);
            this.groupBoxSettings.Controls.Add(this.panelSettingsRunDisable);
            this.groupBoxSettings.Controls.Add(this.groupBox7);
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(360, 438);
            this.groupBoxSettings.TabIndex = 2;
            this.groupBoxSettings.TabStop = false;
            // 
            // labelState
            // 
            this.labelState.AutoEllipsis = true;
            this.labelState.BackColor = System.Drawing.Color.Transparent;
            this.labelState.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.ForeColor = System.Drawing.Color.Red;
            this.labelState.Location = new System.Drawing.Point(12, 24);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(266, 28);
            this.labelState.TabIndex = 17;
            this.labelState.Text = "CyberSave77 is not started";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelSettingsRunDisable
            // 
            this.panelSettingsRunDisable.AutoScroll = true;
            this.panelSettingsRunDisable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSettingsRunDisable.Controls.Add(this.pictureBoxSvgMgr);
            this.panelSettingsRunDisable.Controls.Add(this.checkBoxEnableAutosave);
            this.panelSettingsRunDisable.Controls.Add(this.groupBoxAutosave);
            this.panelSettingsRunDisable.Controls.Add(this.pictureBoxAddSettings);
            this.panelSettingsRunDisable.Controls.Add(this.checkBoxEnableSaveGameHistory);
            this.panelSettingsRunDisable.Controls.Add(this.groupBoxExtraSavegames);
            this.panelSettingsRunDisable.Controls.Add(this.checkBoxEnableAppsOnStart);
            this.panelSettingsRunDisable.Controls.Add(this.groupBoxAddApplication);
            this.panelSettingsRunDisable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettingsRunDisable.Location = new System.Drawing.Point(3, 21);
            this.panelSettingsRunDisable.Name = "panelSettingsRunDisable";
            this.panelSettingsRunDisable.Size = new System.Drawing.Size(354, 328);
            this.panelSettingsRunDisable.TabIndex = 18;
            // 
            // pictureBoxSvgMgr
            // 
            this.pictureBoxSvgMgr.Image = global::CyberSave77.Properties.Resources.diskette;
            this.pictureBoxSvgMgr.Location = new System.Drawing.Point(281, 3);
            this.pictureBoxSvgMgr.Name = "pictureBoxSvgMgr";
            this.pictureBoxSvgMgr.Size = new System.Drawing.Size(35, 26);
            this.pictureBoxSvgMgr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSvgMgr.TabIndex = 16;
            this.pictureBoxSvgMgr.TabStop = false;
            this.pictureBoxSvgMgr.Click += new System.EventHandler(this.pictureBoxSvgMgr_Click);
            this.pictureBoxSvgMgr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxSvgMgr.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBoxSvgMgr.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBoxSvgMgr.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // checkBoxEnableAutosave
            // 
            this.checkBoxEnableAutosave.AutoSize = true;
            this.checkBoxEnableAutosave.Location = new System.Drawing.Point(14, 104);
            this.checkBoxEnableAutosave.Name = "checkBoxEnableAutosave";
            this.checkBoxEnableAutosave.Size = new System.Drawing.Size(165, 23);
            this.checkBoxEnableAutosave.TabIndex = 16;
            this.checkBoxEnableAutosave.Text = "Enable AutoQuickSave";
            this.checkBoxEnableAutosave.UseVisualStyleBackColor = true;
            this.checkBoxEnableAutosave.CheckedChanged += new System.EventHandler(this.checkBoxDisableAutosave_CheckedChanged);
            // 
            // groupBoxAutosave
            // 
            this.groupBoxAutosave.Controls.Add(this.numericUpDownTryAutoQuickSave);
            this.groupBoxAutosave.Controls.Add(this.labelAutosve);
            this.groupBoxAutosave.Enabled = false;
            this.groupBoxAutosave.Location = new System.Drawing.Point(5, 105);
            this.groupBoxAutosave.Name = "groupBoxAutosave";
            this.groupBoxAutosave.Size = new System.Drawing.Size(345, 68);
            this.groupBoxAutosave.TabIndex = 15;
            this.groupBoxAutosave.TabStop = false;
            // 
            // numericUpDownTryAutoQuickSave
            // 
            this.numericUpDownTryAutoQuickSave.Location = new System.Drawing.Point(265, 32);
            this.numericUpDownTryAutoQuickSave.Name = "numericUpDownTryAutoQuickSave";
            this.numericUpDownTryAutoQuickSave.Size = new System.Drawing.Size(74, 25);
            this.numericUpDownTryAutoQuickSave.TabIndex = 5;
            this.numericUpDownTryAutoQuickSave.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTryAutoQuickSave.ValueChanged += new System.EventHandler(this.numericUpDownTryAutosave_ValueChanged);
            // 
            // labelAutosve
            // 
            this.labelAutosve.AutoSize = true;
            this.labelAutosve.Location = new System.Drawing.Point(8, 34);
            this.labelAutosve.Name = "labelAutosve";
            this.labelAutosve.Size = new System.Drawing.Size(198, 19);
            this.labelAutosve.TabIndex = 4;
            this.labelAutosve.Text = "Create a Quicksave every (min)";
            this.labelAutosve.MouseHover += new System.EventHandler(this.labelAutosve_MouseHover);
            // 
            // pictureBoxAddSettings
            // 
            this.pictureBoxAddSettings.Image = global::CyberSave77.Properties.Resources._021_settings;
            this.pictureBoxAddSettings.Location = new System.Drawing.Point(317, 3);
            this.pictureBoxAddSettings.Name = "pictureBoxAddSettings";
            this.pictureBoxAddSettings.Size = new System.Drawing.Size(35, 26);
            this.pictureBoxAddSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAddSettings.TabIndex = 13;
            this.pictureBoxAddSettings.TabStop = false;
            this.pictureBoxAddSettings.Click += new System.EventHandler(this.pictureBoxAddSettings_Click);
            this.pictureBoxAddSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxAddSettings.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBoxAddSettings.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBoxAddSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // checkBoxEnableSaveGameHistory
            // 
            this.checkBoxEnableSaveGameHistory.AutoSize = true;
            this.checkBoxEnableSaveGameHistory.Location = new System.Drawing.Point(14, 34);
            this.checkBoxEnableSaveGameHistory.Name = "checkBoxEnableSaveGameHistory";
            this.checkBoxEnableSaveGameHistory.Size = new System.Drawing.Size(179, 23);
            this.checkBoxEnableSaveGameHistory.TabIndex = 14;
            this.checkBoxEnableSaveGameHistory.Text = "Enable savegame history";
            this.checkBoxEnableSaveGameHistory.UseVisualStyleBackColor = true;
            this.checkBoxEnableSaveGameHistory.CheckedChanged += new System.EventHandler(this.checkBoxDisableExtraSaveGames_CheckedChanged);
            // 
            // groupBoxExtraSavegames
            // 
            this.groupBoxExtraSavegames.Controls.Add(this.numericUpDownMinSaveGames);
            this.groupBoxExtraSavegames.Controls.Add(this.labelSaveGameTimeDif);
            this.groupBoxExtraSavegames.Enabled = false;
            this.groupBoxExtraSavegames.Location = new System.Drawing.Point(5, 34);
            this.groupBoxExtraSavegames.Name = "groupBoxExtraSavegames";
            this.groupBoxExtraSavegames.Size = new System.Drawing.Size(345, 64);
            this.groupBoxExtraSavegames.TabIndex = 13;
            this.groupBoxExtraSavegames.TabStop = false;
            // 
            // numericUpDownMinSaveGames
            // 
            this.numericUpDownMinSaveGames.Location = new System.Drawing.Point(265, 24);
            this.numericUpDownMinSaveGames.Name = "numericUpDownMinSaveGames";
            this.numericUpDownMinSaveGames.Size = new System.Drawing.Size(74, 25);
            this.numericUpDownMinSaveGames.TabIndex = 3;
            this.numericUpDownMinSaveGames.ValueChanged += new System.EventHandler(this.numericUpDownMinSaveGames_ValueChanged);
            // 
            // labelSaveGameTimeDif
            // 
            this.labelSaveGameTimeDif.AutoSize = true;
            this.labelSaveGameTimeDif.Location = new System.Drawing.Point(8, 30);
            this.labelSaveGameTimeDif.Name = "labelSaveGameTimeDif";
            this.labelSaveGameTimeDif.Size = new System.Drawing.Size(209, 19);
            this.labelSaveGameTimeDif.TabIndex = 2;
            this.labelSaveGameTimeDif.Text = "Minutes between last save game";
            this.labelSaveGameTimeDif.MouseHover += new System.EventHandler(this.labelSaveGameTimeDif_MouseHover);
            // 
            // checkBoxEnableAppsOnStart
            // 
            this.checkBoxEnableAppsOnStart.AutoSize = true;
            this.checkBoxEnableAppsOnStart.Location = new System.Drawing.Point(14, 179);
            this.checkBoxEnableAppsOnStart.Name = "checkBoxEnableAppsOnStart";
            this.checkBoxEnableAppsOnStart.Size = new System.Drawing.Size(248, 23);
            this.checkBoxEnableAppsOnStart.TabIndex = 12;
            this.checkBoxEnableAppsOnStart.Text = "Enable external applications on start";
            this.checkBoxEnableAppsOnStart.UseVisualStyleBackColor = true;
            this.checkBoxEnableAppsOnStart.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreAddApps_CheckedChanged);
            this.checkBoxEnableAppsOnStart.MouseHover += new System.EventHandler(this.checkBoxIgnoreAddApps_MouseHover);
            // 
            // groupBoxAddApplication
            // 
            this.groupBoxAddApplication.Controls.Add(this.label3);
            this.groupBoxAddApplication.Controls.Add(this.pictureBoxAdd);
            this.groupBoxAddApplication.Controls.Add(this.pictureBoxEdit);
            this.groupBoxAddApplication.Controls.Add(this.pictureBoxDelete);
            this.groupBoxAddApplication.Controls.Add(this.listBoxProcess);
            this.groupBoxAddApplication.Enabled = false;
            this.groupBoxAddApplication.Location = new System.Drawing.Point(5, 180);
            this.groupBoxAddApplication.Name = "groupBoxAddApplication";
            this.groupBoxAddApplication.Size = new System.Drawing.Size(345, 146);
            this.groupBoxAddApplication.TabIndex = 12;
            this.groupBoxAddApplication.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Applications";
            // 
            // pictureBoxAdd
            // 
            this.pictureBoxAdd.Image = global::CyberSave77.Properties.Resources._132_add;
            this.pictureBoxAdd.Location = new System.Drawing.Point(304, 46);
            this.pictureBoxAdd.Name = "pictureBoxAdd";
            this.pictureBoxAdd.Size = new System.Drawing.Size(37, 26);
            this.pictureBoxAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAdd.TabIndex = 11;
            this.pictureBoxAdd.TabStop = false;
            this.pictureBoxAdd.Click += new System.EventHandler(this.pictureBoxAdd_Click);
            this.pictureBoxAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxAdd.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBoxAdd.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBoxAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Image = global::CyberSave77.Properties.Resources._092_edit;
            this.pictureBoxEdit.Location = new System.Drawing.Point(304, 78);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(37, 26);
            this.pictureBoxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEdit.TabIndex = 10;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            this.pictureBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxEdit.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBoxEdit.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBoxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // pictureBoxDelete
            // 
            this.pictureBoxDelete.Image = global::CyberSave77.Properties.Resources._097_delete_3;
            this.pictureBoxDelete.Location = new System.Drawing.Point(304, 111);
            this.pictureBoxDelete.Name = "pictureBoxDelete";
            this.pictureBoxDelete.Size = new System.Drawing.Size(37, 26);
            this.pictureBoxDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDelete.TabIndex = 9;
            this.pictureBoxDelete.TabStop = false;
            this.pictureBoxDelete.Click += new System.EventHandler(this.pictureBoxDelete_Click);
            this.pictureBoxDelete.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBoxDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxDelete.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBoxDelete.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBoxDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // listBoxProcess
            // 
            this.listBoxProcess.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxProcess.FormattingEnabled = true;
            this.listBoxProcess.ItemHeight = 17;
            this.listBoxProcess.Location = new System.Drawing.Point(10, 46);
            this.listBoxProcess.Name = "listBoxProcess";
            this.listBoxProcess.Size = new System.Drawing.Size(294, 89);
            this.listBoxProcess.TabIndex = 6;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBoxCloseToTray);
            this.groupBox7.Controls.Add(this.checkBoxAutostart);
            this.groupBox7.Controls.Add(this.checkBoxHideStatusLog);
            this.groupBox7.Controls.Add(this.checkBoxMinimizeToTray);
            this.groupBox7.Location = new System.Drawing.Point(4, 350);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(353, 82);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Other";
            // 
            // checkBoxCloseToTray
            // 
            this.checkBoxCloseToTray.AutoSize = true;
            this.checkBoxCloseToTray.Location = new System.Drawing.Point(195, 51);
            this.checkBoxCloseToTray.Name = "checkBoxCloseToTray";
            this.checkBoxCloseToTray.Size = new System.Drawing.Size(106, 23);
            this.checkBoxCloseToTray.TabIndex = 3;
            this.checkBoxCloseToTray.Text = "Close to tray";
            this.checkBoxCloseToTray.UseVisualStyleBackColor = true;
            this.checkBoxCloseToTray.CheckedChanged += new System.EventHandler(this.checkBoxCloseToTray_CheckedChanged);
            this.checkBoxCloseToTray.MouseHover += new System.EventHandler(this.checkBoxCloseToTray_MouseHover);
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Location = new System.Drawing.Point(10, 24);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(128, 23);
            this.checkBoxAutostart.TabIndex = 2;
            this.checkBoxAutostart.Text = "Enable autostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            this.checkBoxAutostart.CheckedChanged += new System.EventHandler(this.checkBoxAutostart_CheckedChanged);
            this.checkBoxAutostart.MouseHover += new System.EventHandler(this.checkBoxAutostart_MouseHover);
            // 
            // checkBoxHideStatusLog
            // 
            this.checkBoxHideStatusLog.AutoSize = true;
            this.checkBoxHideStatusLog.Location = new System.Drawing.Point(10, 51);
            this.checkBoxHideStatusLog.Name = "checkBoxHideStatusLog";
            this.checkBoxHideStatusLog.Size = new System.Drawing.Size(116, 23);
            this.checkBoxHideStatusLog.TabIndex = 1;
            this.checkBoxHideStatusLog.Text = "Hide statuslog";
            this.checkBoxHideStatusLog.UseVisualStyleBackColor = true;
            this.checkBoxHideStatusLog.CheckedChanged += new System.EventHandler(this.checkBoxHideStatusLog_CheckedChanged);
            this.checkBoxHideStatusLog.MouseHover += new System.EventHandler(this.checkBoxHideStatusLog_MouseHover);
            // 
            // checkBoxMinimizeToTray
            // 
            this.checkBoxMinimizeToTray.AutoSize = true;
            this.checkBoxMinimizeToTray.Location = new System.Drawing.Point(195, 24);
            this.checkBoxMinimizeToTray.Name = "checkBoxMinimizeToTray";
            this.checkBoxMinimizeToTray.Size = new System.Drawing.Size(128, 23);
            this.checkBoxMinimizeToTray.TabIndex = 0;
            this.checkBoxMinimizeToTray.Text = "Minimize to tray";
            this.checkBoxMinimizeToTray.UseVisualStyleBackColor = true;
            this.checkBoxMinimizeToTray.CheckedChanged += new System.EventHandler(this.checkBoxMinimizeToTray_CheckedChanged);
            this.checkBoxMinimizeToTray.MouseHover += new System.EventHandler(this.checkBoxMinimizeToTray_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 526);
            this.Controls.Add(this.panelAll);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(772, 565);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CyberSave77 (v0.2)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown_1);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cmsNotifyIcon.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            this.panelCredit.ResumeLayout(false);
            this.panelCredit.PerformLayout();
            this.panelRightSide.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.panelSettingsRunDisable.ResumeLayout(false);
            this.panelSettingsRunDisable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSvgMgr)).EndInit();
            this.groupBoxAutosave.ResumeLayout(false);
            this.groupBoxAutosave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTryAutoQuickSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddSettings)).EndInit();
            this.groupBoxExtraSavegames.ResumeLayout(false);
            this.groupBoxExtraSavegames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinSaveGames)).EndInit();
            this.groupBoxAddApplication.ResumeLayout(false);
            this.groupBoxAddApplication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwCheckProcess;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.ListBox listBoxProcess;
        private System.Windows.Forms.PictureBox pictureBoxDelete;
        private System.Windows.Forms.PictureBox pictureBoxAdd;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.GroupBox groupBoxAddApplication;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxEnableAppsOnStart;
        private System.Windows.Forms.CheckBox checkBoxEnableSaveGameHistory;
        private System.Windows.Forms.GroupBox groupBoxExtraSavegames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBoxCloseToTray;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.CheckBox checkBoxHideStatusLog;
        private System.Windows.Forms.CheckBox checkBoxMinimizeToTray;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DrawPanel panelSettings;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelSettingsRunDisable;
        private ModernButton modernButtonStart;
        private ModernButton modernButtonStop;
        private ModernButton modernButtonExit;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBoxAddSettings;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelRightSide;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelCredit;
        private System.Windows.Forms.CheckBox checkBoxEnableAutosave;
        private System.Windows.Forms.GroupBox groupBoxAutosave;
        private System.Windows.Forms.NumericUpDown numericUpDownTryAutoQuickSave;
        private System.Windows.Forms.Label labelAutosve;
        private System.Windows.Forms.NumericUpDown numericUpDownMinSaveGames;
        private System.Windows.Forms.Label labelSaveGameTimeDif;
        private System.Windows.Forms.Label labelState;
        private ModernButton modernButtonDebug;
        private System.Windows.Forms.PictureBox pictureBoxSvgMgr;
    }
}

