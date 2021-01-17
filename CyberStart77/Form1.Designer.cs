
namespace CyberStart77
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
            this.panelRightSide = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panelCredit = new System.Windows.Forms.Panel();
            this.modernButtonStart = new CyberStart77.ModernButton();
            this.modernButtonStop = new CyberStart77.ModernButton();
            this.modernButtonExit = new CyberStart77.ModernButton();
            this.panelSettings = new CyberStart77.DrawPanel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.panelSettingsRunDisable = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBoxAddSettings = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxProcess = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownSaveGame = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownProcess = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDisableExtraSaveGames = new System.Windows.Forms.CheckBox();
            this.groupBoxExtraSavegames = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomName = new System.Windows.Forms.RadioButton();
            this.radioButtonSavegameContentSchema = new System.Windows.Forms.RadioButton();
            this.radioButtonDirNameSchema = new System.Windows.Forms.RadioButton();
            this.buttonSearchExtraSavegames = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPathExtraSavegames = new System.Windows.Forms.TextBox();
            this.buttonSearchSaveGamePath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPathSavegame = new System.Windows.Forms.TextBox();
            this.checkBoxIgnoreAddApps = new System.Windows.Forms.CheckBox();
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
            this.panelRightSide.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelCredit.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.panelSettingsRunDisable.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddSettings)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaveGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcess)).BeginInit();
            this.groupBoxExtraSavegames.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.textBoxLog.Size = new System.Drawing.Size(360, 787);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.TabStop = false;
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
            this.linkLabel2.Location = new System.Drawing.Point(52, -1);
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
            this.label8.Location = new System.Drawing.Point(-1, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Buttons by";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(221, -1);
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
            this.label7.Location = new System.Drawing.Point(158, -1);
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
            this.panelAll.Size = new System.Drawing.Size(756, 813);
            this.panelAll.TabIndex = 6;
            // 
            // panelRightSide
            // 
            this.panelRightSide.Controls.Add(this.panelButton);
            this.panelRightSide.Controls.Add(this.panelSettings);
            this.panelRightSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightSide.Location = new System.Drawing.Point(376, 0);
            this.panelRightSide.Name = "panelRightSide";
            this.panelRightSide.Size = new System.Drawing.Size(380, 813);
            this.panelRightSide.TabIndex = 14;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.label9);
            this.panelButton.Controls.Add(this.modernButtonStart);
            this.panelButton.Controls.Add(this.modernButtonStop);
            this.panelButton.Controls.Add(this.modernButtonExit);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 738);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(380, 75);
            this.panelButton.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(316, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "JW [170121]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelCredit
            // 
            this.panelCredit.Controls.Add(this.label8);
            this.panelCredit.Controls.Add(this.linkLabel2);
            this.panelCredit.Controls.Add(this.linkLabel1);
            this.panelCredit.Controls.Add(this.label7);
            this.panelCredit.Location = new System.Drawing.Point(6, 800);
            this.panelCredit.Name = "panelCredit";
            this.panelCredit.Size = new System.Drawing.Size(291, 13);
            this.panelCredit.TabIndex = 7;
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
            this.modernButtonStart.Size = new System.Drawing.Size(91, 46);
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
            this.modernButtonStop.Location = new System.Drawing.Point(116, 3);
            this.modernButtonStop.Name = "modernButtonStop";
            this.modernButtonStop.Size = new System.Drawing.Size(91, 46);
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
            this.modernButtonExit.Location = new System.Drawing.Point(270, 3);
            this.modernButtonExit.Name = "modernButtonExit";
            this.modernButtonExit.Size = new System.Drawing.Size(91, 46);
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
            this.panelSettings.Size = new System.Drawing.Size(380, 735);
            this.panelSettings.TabIndex = 5;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.panelSettingsRunDisable);
            this.groupBoxSettings.Controls.Add(this.groupBox7);
            this.groupBoxSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(360, 729);
            this.groupBoxSettings.TabIndex = 2;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // panelSettingsRunDisable
            // 
            this.panelSettingsRunDisable.AutoScroll = true;
            this.panelSettingsRunDisable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSettingsRunDisable.Controls.Add(this.groupBox5);
            this.panelSettingsRunDisable.Controls.Add(this.groupBox4);
            this.panelSettingsRunDisable.Controls.Add(this.checkBoxDisableExtraSaveGames);
            this.panelSettingsRunDisable.Controls.Add(this.groupBoxExtraSavegames);
            this.panelSettingsRunDisable.Controls.Add(this.checkBoxIgnoreAddApps);
            this.panelSettingsRunDisable.Controls.Add(this.groupBoxAddApplication);
            this.panelSettingsRunDisable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettingsRunDisable.Location = new System.Drawing.Point(3, 21);
            this.panelSettingsRunDisable.Name = "panelSettingsRunDisable";
            this.panelSettingsRunDisable.Size = new System.Drawing.Size(354, 614);
            this.panelSettingsRunDisable.TabIndex = 18;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBoxAddSettings);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.textBoxProcess);
            this.groupBox5.Location = new System.Drawing.Point(5, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(345, 77);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Process";
            // 
            // pictureBoxAddSettings
            // 
            this.pictureBoxAddSettings.Image = global::CyberStart77.Properties.Resources._021_settings;
            this.pictureBoxAddSettings.Location = new System.Drawing.Point(305, 13);
            this.pictureBoxAddSettings.Name = "pictureBoxAddSettings";
            this.pictureBoxAddSettings.Size = new System.Drawing.Size(37, 26);
            this.pictureBoxAddSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAddSettings.TabIndex = 13;
            this.pictureBoxAddSettings.TabStop = false;
            this.pictureBoxAddSettings.Click += new System.EventHandler(this.pictureBoxAddSettings_Click);
            this.pictureBoxAddSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxAddSettings.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBoxAddSettings.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBoxAddSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Name of process to check:";
            // 
            // textBoxProcess
            // 
            this.textBoxProcess.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProcess.Location = new System.Drawing.Point(3, 43);
            this.textBoxProcess.Name = "textBoxProcess";
            this.textBoxProcess.Size = new System.Drawing.Size(336, 25);
            this.textBoxProcess.TabIndex = 0;
            this.textBoxProcess.TextChanged += new System.EventHandler(this.textBoxProcess_TextChanged);
            this.textBoxProcess.Leave += new System.EventHandler(this.textBoxProcess_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.numericUpDownSaveGame);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.numericUpDownProcess);
            this.groupBox4.Location = new System.Drawing.Point(5, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(345, 82);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Timer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Savegame interval (sec.)";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // numericUpDownSaveGame
            // 
            this.numericUpDownSaveGame.Location = new System.Drawing.Point(174, 54);
            this.numericUpDownSaveGame.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownSaveGame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSaveGame.Name = "numericUpDownSaveGame";
            this.numericUpDownSaveGame.Size = new System.Drawing.Size(48, 25);
            this.numericUpDownSaveGame.TabIndex = 2;
            this.numericUpDownSaveGame.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownSaveGame.ValueChanged += new System.EventHandler(this.numericUpDownSaveGame_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process interval (sec.)";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // numericUpDownProcess
            // 
            this.numericUpDownProcess.Location = new System.Drawing.Point(174, 20);
            this.numericUpDownProcess.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownProcess.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownProcess.Name = "numericUpDownProcess";
            this.numericUpDownProcess.Size = new System.Drawing.Size(48, 25);
            this.numericUpDownProcess.TabIndex = 0;
            this.numericUpDownProcess.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownProcess.ValueChanged += new System.EventHandler(this.numericUpDownProcess_ValueChanged);
            // 
            // checkBoxDisableExtraSaveGames
            // 
            this.checkBoxDisableExtraSaveGames.AutoSize = true;
            this.checkBoxDisableExtraSaveGames.Location = new System.Drawing.Point(5, 169);
            this.checkBoxDisableExtraSaveGames.Name = "checkBoxDisableExtraSaveGames";
            this.checkBoxDisableExtraSaveGames.Size = new System.Drawing.Size(184, 23);
            this.checkBoxDisableExtraSaveGames.TabIndex = 14;
            this.checkBoxDisableExtraSaveGames.Text = "Disable extra Savesgames";
            this.checkBoxDisableExtraSaveGames.UseVisualStyleBackColor = true;
            this.checkBoxDisableExtraSaveGames.CheckedChanged += new System.EventHandler(this.checkBoxDisableExtraSaveGames_CheckedChanged);
            // 
            // groupBoxExtraSavegames
            // 
            this.groupBoxExtraSavegames.Controls.Add(this.groupBox6);
            this.groupBoxExtraSavegames.Controls.Add(this.buttonSearchExtraSavegames);
            this.groupBoxExtraSavegames.Controls.Add(this.label5);
            this.groupBoxExtraSavegames.Controls.Add(this.textBoxPathExtraSavegames);
            this.groupBoxExtraSavegames.Controls.Add(this.buttonSearchSaveGamePath);
            this.groupBoxExtraSavegames.Controls.Add(this.label4);
            this.groupBoxExtraSavegames.Controls.Add(this.textBoxPathSavegame);
            this.groupBoxExtraSavegames.Location = new System.Drawing.Point(5, 196);
            this.groupBoxExtraSavegames.Name = "groupBoxExtraSavegames";
            this.groupBoxExtraSavegames.Size = new System.Drawing.Size(345, 240);
            this.groupBoxExtraSavegames.TabIndex = 13;
            this.groupBoxExtraSavegames.TabStop = false;
            this.groupBoxExtraSavegames.Text = "Extra savegames";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButtonCustomName);
            this.groupBox6.Controls.Add(this.radioButtonSavegameContentSchema);
            this.groupBox6.Controls.Add(this.radioButtonDirNameSchema);
            this.groupBox6.Location = new System.Drawing.Point(3, 130);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(330, 104);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Name schema";
            // 
            // radioButtonCustomName
            // 
            this.radioButtonCustomName.AutoEllipsis = true;
            this.radioButtonCustomName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCustomName.Location = new System.Drawing.Point(5, 77);
            this.radioButtonCustomName.Name = "radioButtonCustomName";
            this.radioButtonCustomName.Size = new System.Drawing.Size(319, 21);
            this.radioButtonCustomName.TabIndex = 8;
            this.radioButtonCustomName.Text = "Savegame Custom (not set)";
            this.radioButtonCustomName.UseVisualStyleBackColor = true;
            this.radioButtonCustomName.CheckedChanged += new System.EventHandler(this.radioButtonCustomName_CheckedChanged);
            // 
            // radioButtonSavegameContentSchema
            // 
            this.radioButtonSavegameContentSchema.AutoSize = true;
            this.radioButtonSavegameContentSchema.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSavegameContentSchema.Location = new System.Drawing.Point(5, 50);
            this.radioButtonSavegameContentSchema.Name = "radioButtonSavegameContentSchema";
            this.radioButtonSavegameContentSchema.Size = new System.Drawing.Size(315, 21);
            this.radioButtonSavegameContentSchema.TabIndex = 7;
            this.radioButtonSavegameContentSchema.Text = "Savegame content (Lifepath Gender Level + Date)";
            this.radioButtonSavegameContentSchema.UseVisualStyleBackColor = true;
            this.radioButtonSavegameContentSchema.CheckedChanged += new System.EventHandler(this.radioButtonSavegameContentSchema_CheckedChanged);
            // 
            // radioButtonDirNameSchema
            // 
            this.radioButtonDirNameSchema.AutoSize = true;
            this.radioButtonDirNameSchema.Checked = true;
            this.radioButtonDirNameSchema.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDirNameSchema.Location = new System.Drawing.Point(5, 23);
            this.radioButtonDirNameSchema.Name = "radioButtonDirNameSchema";
            this.radioButtonDirNameSchema.Size = new System.Drawing.Size(311, 21);
            this.radioButtonDirNameSchema.TabIndex = 6;
            this.radioButtonDirNameSchema.TabStop = true;
            this.radioButtonDirNameSchema.Text = "Directory name (Quicksave/Autosave etc. + Date)";
            this.radioButtonDirNameSchema.UseVisualStyleBackColor = true;
            this.radioButtonDirNameSchema.CheckedChanged += new System.EventHandler(this.radioButtonDirNameSchema_CheckedChanged);
            // 
            // buttonSearchExtraSavegames
            // 
            this.buttonSearchExtraSavegames.Location = new System.Drawing.Point(308, 100);
            this.buttonSearchExtraSavegames.Name = "buttonSearchExtraSavegames";
            this.buttonSearchExtraSavegames.Size = new System.Drawing.Size(27, 24);
            this.buttonSearchExtraSavegames.TabIndex = 5;
            this.buttonSearchExtraSavegames.Text = "...";
            this.buttonSearchExtraSavegames.UseVisualStyleBackColor = true;
            this.buttonSearchExtraSavegames.Click += new System.EventHandler(this.buttonSearchExtraSavegames_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Extra savegames Path";
            // 
            // textBoxPathExtraSavegames
            // 
            this.textBoxPathExtraSavegames.Location = new System.Drawing.Point(7, 100);
            this.textBoxPathExtraSavegames.Name = "textBoxPathExtraSavegames";
            this.textBoxPathExtraSavegames.ReadOnly = true;
            this.textBoxPathExtraSavegames.Size = new System.Drawing.Size(297, 25);
            this.textBoxPathExtraSavegames.TabIndex = 3;
            this.textBoxPathExtraSavegames.TextChanged += new System.EventHandler(this.textBoxPathExtraSavegames_TextChanged);
            // 
            // buttonSearchSaveGamePath
            // 
            this.buttonSearchSaveGamePath.Location = new System.Drawing.Point(308, 45);
            this.buttonSearchSaveGamePath.Name = "buttonSearchSaveGamePath";
            this.buttonSearchSaveGamePath.Size = new System.Drawing.Size(27, 24);
            this.buttonSearchSaveGamePath.TabIndex = 2;
            this.buttonSearchSaveGamePath.Text = "...";
            this.buttonSearchSaveGamePath.UseVisualStyleBackColor = true;
            this.buttonSearchSaveGamePath.Click += new System.EventHandler(this.buttonSearchSaveGamePath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Savegame Path";
            // 
            // textBoxPathSavegame
            // 
            this.textBoxPathSavegame.Location = new System.Drawing.Point(7, 45);
            this.textBoxPathSavegame.Name = "textBoxPathSavegame";
            this.textBoxPathSavegame.ReadOnly = true;
            this.textBoxPathSavegame.Size = new System.Drawing.Size(297, 25);
            this.textBoxPathSavegame.TabIndex = 0;
            this.textBoxPathSavegame.TextChanged += new System.EventHandler(this.textBoxPathSavegame_TextChanged);
            // 
            // checkBoxIgnoreAddApps
            // 
            this.checkBoxIgnoreAddApps.AutoSize = true;
            this.checkBoxIgnoreAddApps.Location = new System.Drawing.Point(5, 442);
            this.checkBoxIgnoreAddApps.Name = "checkBoxIgnoreAddApps";
            this.checkBoxIgnoreAddApps.Size = new System.Drawing.Size(208, 23);
            this.checkBoxIgnoreAddApps.TabIndex = 12;
            this.checkBoxIgnoreAddApps.Text = "Ignore additional applications";
            this.checkBoxIgnoreAddApps.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreAddApps.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreAddApps_CheckedChanged);
            // 
            // groupBoxAddApplication
            // 
            this.groupBoxAddApplication.Controls.Add(this.label3);
            this.groupBoxAddApplication.Controls.Add(this.pictureBoxAdd);
            this.groupBoxAddApplication.Controls.Add(this.pictureBoxEdit);
            this.groupBoxAddApplication.Controls.Add(this.pictureBoxDelete);
            this.groupBoxAddApplication.Controls.Add(this.listBoxProcess);
            this.groupBoxAddApplication.Location = new System.Drawing.Point(5, 466);
            this.groupBoxAddApplication.Name = "groupBoxAddApplication";
            this.groupBoxAddApplication.Size = new System.Drawing.Size(345, 146);
            this.groupBoxAddApplication.TabIndex = 12;
            this.groupBoxAddApplication.TabStop = false;
            this.groupBoxAddApplication.Text = "Run additional applications on start";
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
            this.pictureBoxAdd.Image = global::CyberStart77.Properties.Resources._132_add;
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
            this.pictureBoxEdit.Image = global::CyberStart77.Properties.Resources._092_edit;
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
            this.pictureBoxDelete.Image = global::CyberStart77.Properties.Resources._097_delete_3;
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
            this.groupBox7.Location = new System.Drawing.Point(8, 637);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(345, 82);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Other";
            // 
            // checkBoxCloseToTray
            // 
            this.checkBoxCloseToTray.AutoSize = true;
            this.checkBoxCloseToTray.Location = new System.Drawing.Point(185, 48);
            this.checkBoxCloseToTray.Name = "checkBoxCloseToTray";
            this.checkBoxCloseToTray.Size = new System.Drawing.Size(106, 23);
            this.checkBoxCloseToTray.TabIndex = 3;
            this.checkBoxCloseToTray.Text = "Close to tray";
            this.checkBoxCloseToTray.UseVisualStyleBackColor = true;
            this.checkBoxCloseToTray.CheckedChanged += new System.EventHandler(this.checkBoxCloseToTray_CheckedChanged);
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
            // 
            // checkBoxHideStatusLog
            // 
            this.checkBoxHideStatusLog.AutoSize = true;
            this.checkBoxHideStatusLog.Location = new System.Drawing.Point(10, 48);
            this.checkBoxHideStatusLog.Name = "checkBoxHideStatusLog";
            this.checkBoxHideStatusLog.Size = new System.Drawing.Size(116, 23);
            this.checkBoxHideStatusLog.TabIndex = 1;
            this.checkBoxHideStatusLog.Text = "Hide statuslog";
            this.checkBoxHideStatusLog.UseVisualStyleBackColor = true;
            this.checkBoxHideStatusLog.CheckedChanged += new System.EventHandler(this.checkBoxHideStatusLog_CheckedChanged);
            // 
            // checkBoxMinimizeToTray
            // 
            this.checkBoxMinimizeToTray.AutoSize = true;
            this.checkBoxMinimizeToTray.Location = new System.Drawing.Point(185, 24);
            this.checkBoxMinimizeToTray.Name = "checkBoxMinimizeToTray";
            this.checkBoxMinimizeToTray.Size = new System.Drawing.Size(128, 23);
            this.checkBoxMinimizeToTray.TabIndex = 0;
            this.checkBoxMinimizeToTray.Text = "Minimize to tray";
            this.checkBoxMinimizeToTray.UseVisualStyleBackColor = true;
            this.checkBoxMinimizeToTray.CheckedChanged += new System.EventHandler(this.checkBoxMinimizeToTray_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 813);
            this.Controls.Add(this.panelAll);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(772, 852);
            this.MinimumSize = new System.Drawing.Size(16, 400);
            this.Name = "Form1";
            this.Text = "CyberSave77 (v0.1)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cmsNotifyIcon.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelAll.PerformLayout();
            this.panelRightSide.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelCredit.ResumeLayout(false);
            this.panelCredit.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.panelSettingsRunDisable.ResumeLayout(false);
            this.panelSettingsRunDisable.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAddSettings)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaveGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcess)).EndInit();
            this.groupBoxExtraSavegames.ResumeLayout(false);
            this.groupBoxExtraSavegames.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownSaveGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownProcess;
        private System.Windows.Forms.ListBox listBoxProcess;
        private System.Windows.Forms.PictureBox pictureBoxDelete;
        private System.Windows.Forms.PictureBox pictureBoxAdd;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.GroupBox groupBoxAddApplication;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxIgnoreAddApps;
        private System.Windows.Forms.CheckBox checkBoxDisableExtraSaveGames;
        private System.Windows.Forms.GroupBox groupBoxExtraSavegames;
        private System.Windows.Forms.Button buttonSearchExtraSavegames;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPathExtraSavegames;
        private System.Windows.Forms.Button buttonSearchSaveGamePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPathSavegame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxProcess;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonSavegameContentSchema;
        private System.Windows.Forms.RadioButton radioButtonDirNameSchema;
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
        private System.Windows.Forms.RadioButton radioButtonCustomName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelCredit;
    }
}

