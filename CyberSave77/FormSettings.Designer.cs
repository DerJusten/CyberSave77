
namespace CyberSave77
{
    partial class FormSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButtonCustomName = new System.Windows.Forms.RadioButton();
            this.radioButtonSavegameContentSchema = new System.Windows.Forms.RadioButton();
            this.radioButtonDirNameSchema = new System.Windows.Forms.RadioButton();
            this.buttonSearchExtraSavegames = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPathExtraSavegames = new System.Windows.Forms.TextBox();
            this.buttonSearchSaveGamePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPathSavegame = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPreview = new System.Windows.Forms.Label();
            this.modernButtonKeyNameList = new CyberSave77.ModernButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCustomNameSchema = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxTerminateStartAppOnExit = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelSaveGameCheck = new System.Windows.Forms.Label();
            this.numericUpDownSaveGame = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownProcess = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxProcess = new System.Windows.Forms.TextBox();
            this.labelAutoQsMaxRetries = new System.Windows.Forms.Label();
            this.numericUpDownAutosaveMaxRetries = new System.Windows.Forms.NumericUpDown();
            this.labelAutoQsRetry = new System.Windows.Forms.Label();
            this.numericUpDownAutosaveRetrySeconds = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.bgwBackup = new System.ComponentModel.BackgroundWorker();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.modernButtonAddToAutostart = new CyberSave77.ModernButton();
            this.modernButtonReset = new CyberSave77.ModernButton();
            this.modernButtonCreateBackup = new CyberSave77.ModernButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkBoxSvgmLoadAll = new System.Windows.Forms.CheckBox();
            this.checkBoxSvgmDisableConfirmation = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonQsOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonAsOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonAsAndQs = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaveGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutosaveMaxRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutosaveRetrySeconds)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.buttonSearchExtraSavegames);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxPathExtraSavegames);
            this.groupBox1.Controls.Add(this.buttonSearchSaveGamePath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPathSavegame);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(424, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 445);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Savegame history";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButtonCustomName);
            this.groupBox6.Controls.Add(this.radioButtonSavegameContentSchema);
            this.groupBox6.Controls.Add(this.radioButtonDirNameSchema);
            this.groupBox6.Location = new System.Drawing.Point(13, 126);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(330, 104);
            this.groupBox6.TabIndex = 18;
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
            this.radioButtonCustomName.MouseHover += new System.EventHandler(this.radioButtonCustomName_MouseHover);
            // 
            // radioButtonSavegameContentSchema
            // 
            this.radioButtonSavegameContentSchema.AutoSize = true;
            this.radioButtonSavegameContentSchema.Checked = true;
            this.radioButtonSavegameContentSchema.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSavegameContentSchema.Location = new System.Drawing.Point(5, 50);
            this.radioButtonSavegameContentSchema.Name = "radioButtonSavegameContentSchema";
            this.radioButtonSavegameContentSchema.Size = new System.Drawing.Size(315, 21);
            this.radioButtonSavegameContentSchema.TabIndex = 7;
            this.radioButtonSavegameContentSchema.TabStop = true;
            this.radioButtonSavegameContentSchema.Text = "Savegame content (Lifepath Gender Level + Date)";
            this.radioButtonSavegameContentSchema.UseVisualStyleBackColor = true;
            this.radioButtonSavegameContentSchema.CheckedChanged += new System.EventHandler(this.radioButtonSavegameContentSchema_CheckedChanged);
            this.radioButtonSavegameContentSchema.MouseHover += new System.EventHandler(this.radioButtonSavegameContentSchema_MouseHover);
            // 
            // radioButtonDirNameSchema
            // 
            this.radioButtonDirNameSchema.AutoSize = true;
            this.radioButtonDirNameSchema.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDirNameSchema.Location = new System.Drawing.Point(5, 23);
            this.radioButtonDirNameSchema.Name = "radioButtonDirNameSchema";
            this.radioButtonDirNameSchema.Size = new System.Drawing.Size(287, 21);
            this.radioButtonDirNameSchema.TabIndex = 6;
            this.radioButtonDirNameSchema.Text = "Directory name (Quicksave/Autosave + Date)";
            this.radioButtonDirNameSchema.UseVisualStyleBackColor = true;
            this.radioButtonDirNameSchema.CheckedChanged += new System.EventHandler(this.radioButtonDirNameSchema_CheckedChanged);
            this.radioButtonDirNameSchema.MouseHover += new System.EventHandler(this.radioButtonDirNameSchema_MouseHover);
            // 
            // buttonSearchExtraSavegames
            // 
            this.buttonSearchExtraSavegames.Location = new System.Drawing.Point(314, 95);
            this.buttonSearchExtraSavegames.Name = "buttonSearchExtraSavegames";
            this.buttonSearchExtraSavegames.Size = new System.Drawing.Size(27, 24);
            this.buttonSearchExtraSavegames.TabIndex = 17;
            this.buttonSearchExtraSavegames.Text = "...";
            this.buttonSearchExtraSavegames.UseVisualStyleBackColor = true;
            this.buttonSearchExtraSavegames.Click += new System.EventHandler(this.buttonSearchExtraSavegames_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "History savegame path";
            // 
            // textBoxPathExtraSavegames
            // 
            this.textBoxPathExtraSavegames.Location = new System.Drawing.Point(13, 95);
            this.textBoxPathExtraSavegames.Name = "textBoxPathExtraSavegames";
            this.textBoxPathExtraSavegames.ReadOnly = true;
            this.textBoxPathExtraSavegames.Size = new System.Drawing.Size(297, 25);
            this.textBoxPathExtraSavegames.TabIndex = 15;
            this.textBoxPathExtraSavegames.TextChanged += new System.EventHandler(this.textBoxPathExtraSavegames_TextChanged);
            this.textBoxPathExtraSavegames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPathSavegame_MouseDoubleClick);
            this.textBoxPathExtraSavegames.MouseHover += new System.EventHandler(this.textBoxPathExtraSavegames_MouseHover);
            // 
            // buttonSearchSaveGamePath
            // 
            this.buttonSearchSaveGamePath.Location = new System.Drawing.Point(314, 40);
            this.buttonSearchSaveGamePath.Name = "buttonSearchSaveGamePath";
            this.buttonSearchSaveGamePath.Size = new System.Drawing.Size(27, 24);
            this.buttonSearchSaveGamePath.TabIndex = 14;
            this.buttonSearchSaveGamePath.Text = "...";
            this.buttonSearchSaveGamePath.UseVisualStyleBackColor = true;
            this.buttonSearchSaveGamePath.Click += new System.EventHandler(this.buttonSearchSaveGamePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Default savegame path";
            // 
            // textBoxPathSavegame
            // 
            this.textBoxPathSavegame.Location = new System.Drawing.Point(13, 40);
            this.textBoxPathSavegame.Name = "textBoxPathSavegame";
            this.textBoxPathSavegame.ReadOnly = true;
            this.textBoxPathSavegame.Size = new System.Drawing.Size(297, 25);
            this.textBoxPathSavegame.TabIndex = 12;
            this.textBoxPathSavegame.TextChanged += new System.EventHandler(this.textBoxPathSavegame_TextChanged);
            this.textBoxPathSavegame.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPathSavegame_MouseDoubleClick);
            this.textBoxPathSavegame.MouseHover += new System.EventHandler(this.textBoxPathSavegame_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelPreview);
            this.groupBox2.Controls.Add(this.modernButtonKeyNameList);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxCustomNameSchema);
            this.groupBox2.Location = new System.Drawing.Point(6, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 199);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom Names";
            // 
            // labelPreview
            // 
            this.labelPreview.Location = new System.Drawing.Point(6, 126);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(375, 22);
            this.labelPreview.TabIndex = 10;
            this.labelPreview.Text = "-";
            // 
            // modernButtonKeyNameList
            // 
            this.modernButtonKeyNameList.BackColor = System.Drawing.Color.White;
            this.modernButtonKeyNameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonKeyNameList.ClickEffectEnabled = true;
            this.modernButtonKeyNameList.DefaultColor = System.Drawing.Color.White;
            this.modernButtonKeyNameList.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonKeyNameList.Location = new System.Drawing.Point(294, 157);
            this.modernButtonKeyNameList.Name = "modernButtonKeyNameList";
            this.modernButtonKeyNameList.Size = new System.Drawing.Size(94, 37);
            this.modernButtonKeyNameList.TabIndex = 9;
            this.modernButtonKeyNameList.Text = "Keyname List";
            this.modernButtonKeyNameList.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonKeyNameList.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonKeyNameList.Click += new System.EventHandler(this.modernButtonKeyNameList_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 73);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // textBoxCustomNameSchema
            // 
            this.textBoxCustomNameSchema.Location = new System.Drawing.Point(6, 98);
            this.textBoxCustomNameSchema.Name = "textBoxCustomNameSchema";
            this.textBoxCustomNameSchema.Size = new System.Drawing.Size(375, 25);
            this.textBoxCustomNameSchema.TabIndex = 4;
            this.textBoxCustomNameSchema.TextChanged += new System.EventHandler(this.textBoxCustomNameSchema_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.BackColor = System.Drawing.Color.White;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxTerminateStartAppOnExit);
            this.groupBox3.Location = new System.Drawing.Point(15, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Additional applications";
            // 
            // checkBoxTerminateStartAppOnExit
            // 
            this.checkBoxTerminateStartAppOnExit.AutoSize = true;
            this.checkBoxTerminateStartAppOnExit.Location = new System.Drawing.Point(13, 32);
            this.checkBoxTerminateStartAppOnExit.Name = "checkBoxTerminateStartAppOnExit";
            this.checkBoxTerminateStartAppOnExit.Size = new System.Drawing.Size(372, 23);
            this.checkBoxTerminateStartAppOnExit.TabIndex = 0;
            this.checkBoxTerminateStartAppOnExit.Text = "close all started applications, when Cyberpunk2077 exits";
            this.checkBoxTerminateStartAppOnExit.UseVisualStyleBackColor = true;
            this.checkBoxTerminateStartAppOnExit.MouseHover += new System.EventHandler(this.checkBoxTerminateStartAppOnExit_MouseHover);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.textBoxProcess);
            this.groupBox5.Location = new System.Drawing.Point(15, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(403, 169);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Process";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelSaveGameCheck);
            this.groupBox4.Controls.Add(this.numericUpDownSaveGame);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.numericUpDownProcess);
            this.groupBox4.Location = new System.Drawing.Point(18, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 82);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Timer";
            // 
            // labelSaveGameCheck
            // 
            this.labelSaveGameCheck.AutoSize = true;
            this.labelSaveGameCheck.Location = new System.Drawing.Point(6, 53);
            this.labelSaveGameCheck.Name = "labelSaveGameCheck";
            this.labelSaveGameCheck.Size = new System.Drawing.Size(196, 19);
            this.labelSaveGameCheck.TabIndex = 3;
            this.labelSaveGameCheck.Text = "Save game check interval (sec.)";
            this.labelSaveGameCheck.MouseHover += new System.EventHandler(this.labelSaveGameCheck_MouseHover);
            // 
            // numericUpDownSaveGame
            // 
            this.numericUpDownSaveGame.Location = new System.Drawing.Point(279, 51);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Process check interval (sec.)";
            this.label8.MouseHover += new System.EventHandler(this.label8_MouseHover);
            // 
            // numericUpDownProcess
            // 
            this.numericUpDownProcess.Location = new System.Drawing.Point(279, 17);
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
            this.textBoxProcess.Location = new System.Drawing.Point(18, 46);
            this.textBoxProcess.Name = "textBoxProcess";
            this.textBoxProcess.ReadOnly = true;
            this.textBoxProcess.Size = new System.Drawing.Size(369, 25);
            this.textBoxProcess.TabIndex = 0;
            this.textBoxProcess.TextChanged += new System.EventHandler(this.textBoxProcess_TextChanged);
            this.textBoxProcess.Leave += new System.EventHandler(this.textBoxProcess_Leave);
            this.textBoxProcess.MouseHover += new System.EventHandler(this.textBoxProcess_MouseHover);
            // 
            // labelAutoQsMaxRetries
            // 
            this.labelAutoQsMaxRetries.AutoSize = true;
            this.labelAutoQsMaxRetries.Location = new System.Drawing.Point(9, 69);
            this.labelAutoQsMaxRetries.Name = "labelAutoQsMaxRetries";
            this.labelAutoQsMaxRetries.Size = new System.Drawing.Size(112, 19);
            this.labelAutoQsMaxRetries.TabIndex = 5;
            this.labelAutoQsMaxRetries.Text = "Maximum retries";
            this.labelAutoQsMaxRetries.MouseHover += new System.EventHandler(this.labelAutoQsMaxRetries_MouseHover);
            // 
            // numericUpDownAutosaveMaxRetries
            // 
            this.numericUpDownAutosaveMaxRetries.Location = new System.Drawing.Point(297, 67);
            this.numericUpDownAutosaveMaxRetries.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownAutosaveMaxRetries.Name = "numericUpDownAutosaveMaxRetries";
            this.numericUpDownAutosaveMaxRetries.Size = new System.Drawing.Size(48, 25);
            this.numericUpDownAutosaveMaxRetries.TabIndex = 4;
            this.numericUpDownAutosaveMaxRetries.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownAutosaveMaxRetries.ValueChanged += new System.EventHandler(this.numericUpDownAutosaveMaxRetries_ValueChanged);
            // 
            // labelAutoQsRetry
            // 
            this.labelAutoQsRetry.AutoSize = true;
            this.labelAutoQsRetry.Location = new System.Drawing.Point(9, 34);
            this.labelAutoQsRetry.Name = "labelAutoQsRetry";
            this.labelAutoQsRetry.Size = new System.Drawing.Size(209, 19);
            this.labelAutoQsRetry.TabIndex = 3;
            this.labelAutoQsRetry.Text = "Time to wait until retry (seconds)";
            this.labelAutoQsRetry.MouseHover += new System.EventHandler(this.labelAutoQsRetry_MouseHover);
            // 
            // numericUpDownAutosaveRetrySeconds
            // 
            this.numericUpDownAutosaveRetrySeconds.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAutosaveRetrySeconds.Location = new System.Drawing.Point(297, 32);
            this.numericUpDownAutosaveRetrySeconds.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownAutosaveRetrySeconds.Name = "numericUpDownAutosaveRetrySeconds";
            this.numericUpDownAutosaveRetrySeconds.Size = new System.Drawing.Size(48, 25);
            this.numericUpDownAutosaveRetrySeconds.TabIndex = 2;
            this.numericUpDownAutosaveRetrySeconds.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownAutosaveRetrySeconds.ValueChanged += new System.EventHandler(this.numericUpDownAutosaveRetrySeconds_ValueChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.labelAutoQsMaxRetries);
            this.groupBox7.Controls.Add(this.numericUpDownAutosaveMaxRetries);
            this.groupBox7.Controls.Add(this.labelAutoQsRetry);
            this.groupBox7.Controls.Add(this.numericUpDownAutosaveRetrySeconds);
            this.groupBox7.Location = new System.Drawing.Point(15, 354);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(403, 103);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Auto Quicksave";
            // 
            // bgwBackup
            // 
            this.bgwBackup.WorkerReportsProgress = true;
            this.bgwBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBackup_DoWork);
            this.bgwBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwBackup_ProgressChanged);
            this.bgwBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBackup_RunWorkerCompleted);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.modernButtonAddToAutostart);
            this.groupBox8.Controls.Add(this.modernButtonReset);
            this.groupBox8.Controls.Add(this.modernButtonCreateBackup);
            this.groupBox8.Location = new System.Drawing.Point(424, 463);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(403, 79);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Other";
            // 
            // modernButtonAddToAutostart
            // 
            this.modernButtonAddToAutostart.BackColor = System.Drawing.Color.White;
            this.modernButtonAddToAutostart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonAddToAutostart.ClickEffectEnabled = true;
            this.modernButtonAddToAutostart.DefaultColor = System.Drawing.Color.White;
            this.modernButtonAddToAutostart.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonAddToAutostart.Location = new System.Drawing.Point(13, 24);
            this.modernButtonAddToAutostart.Name = "modernButtonAddToAutostart";
            this.modernButtonAddToAutostart.Size = new System.Drawing.Size(111, 44);
            this.modernButtonAddToAutostart.TabIndex = 2;
            this.modernButtonAddToAutostart.Text = "Start with Windows";
            this.modernButtonAddToAutostart.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonAddToAutostart.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonAddToAutostart.Click += new System.EventHandler(this.modernButtonAddToAutostart_Click);
            this.modernButtonAddToAutostart.MouseHover += new System.EventHandler(this.modernButtonAddToAutostart_MouseHover);
            // 
            // modernButtonReset
            // 
            this.modernButtonReset.BackColor = System.Drawing.Color.White;
            this.modernButtonReset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonReset.ClickEffectEnabled = true;
            this.modernButtonReset.DefaultColor = System.Drawing.Color.White;
            this.modernButtonReset.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonReset.Location = new System.Drawing.Point(286, 24);
            this.modernButtonReset.Name = "modernButtonReset";
            this.modernButtonReset.Size = new System.Drawing.Size(101, 44);
            this.modernButtonReset.TabIndex = 1;
            this.modernButtonReset.Text = "Reset settings";
            this.modernButtonReset.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonReset.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonReset.Click += new System.EventHandler(this.modernButtonReset_Click);
            this.modernButtonReset.MouseHover += new System.EventHandler(this.modernButtonReset_MouseHover);
            // 
            // modernButtonCreateBackup
            // 
            this.modernButtonCreateBackup.BackColor = System.Drawing.Color.White;
            this.modernButtonCreateBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonCreateBackup.ClickEffectEnabled = true;
            this.modernButtonCreateBackup.DefaultColor = System.Drawing.Color.White;
            this.modernButtonCreateBackup.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonCreateBackup.Location = new System.Drawing.Point(153, 24);
            this.modernButtonCreateBackup.Name = "modernButtonCreateBackup";
            this.modernButtonCreateBackup.Size = new System.Drawing.Size(101, 44);
            this.modernButtonCreateBackup.TabIndex = 0;
            this.modernButtonCreateBackup.Text = "Backup Savegames";
            this.modernButtonCreateBackup.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonCreateBackup.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonCreateBackup.Click += new System.EventHandler(this.modernButtonCreateBackup_Click);
            this.modernButtonCreateBackup.MouseHover += new System.EventHandler(this.modernButtonCreateBackup_MouseHover);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.checkBoxSvgmLoadAll);
            this.groupBox9.Controls.Add(this.checkBoxSvgmDisableConfirmation);
            this.groupBox9.Location = new System.Drawing.Point(15, 463);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(403, 79);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "SaveGameManager";
            // 
            // checkBoxSvgmLoadAll
            // 
            this.checkBoxSvgmLoadAll.AutoSize = true;
            this.checkBoxSvgmLoadAll.Location = new System.Drawing.Point(6, 53);
            this.checkBoxSvgmLoadAll.Name = "checkBoxSvgmLoadAll";
            this.checkBoxSvgmLoadAll.Size = new System.Drawing.Size(344, 23);
            this.checkBoxSvgmLoadAll.TabIndex = 1;
            this.checkBoxSvgmLoadAll.Text = "always load all savegames (takes a moment to load)";
            this.checkBoxSvgmLoadAll.UseVisualStyleBackColor = true;
            this.checkBoxSvgmLoadAll.CheckedChanged += new System.EventHandler(this.checkBoxSvgmLoadAll_CheckedChanged);
            // 
            // checkBoxSvgmDisableConfirmation
            // 
            this.checkBoxSvgmDisableConfirmation.AutoSize = true;
            this.checkBoxSvgmDisableConfirmation.Location = new System.Drawing.Point(6, 24);
            this.checkBoxSvgmDisableConfirmation.Name = "checkBoxSvgmDisableConfirmation";
            this.checkBoxSvgmDisableConfirmation.Size = new System.Drawing.Size(207, 23);
            this.checkBoxSvgmDisableConfirmation.TabIndex = 0;
            this.checkBoxSvgmDisableConfirmation.Text = "disable confirmation dialogue";
            this.checkBoxSvgmDisableConfirmation.UseVisualStyleBackColor = true;
            this.checkBoxSvgmDisableConfirmation.CheckedChanged += new System.EventHandler(this.checkBoxSGMdisableConfirmation_CheckedChanged);
            this.checkBoxSvgmDisableConfirmation.MouseHover += new System.EventHandler(this.checkBoxSGMdisableConfirmation_MouseHover);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.radioButtonQsOnly);
            this.groupBox10.Controls.Add(this.radioButtonAsOnly);
            this.groupBox10.Controls.Add(this.radioButtonAsAndQs);
            this.groupBox10.Location = new System.Drawing.Point(15, 187);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(403, 90);
            this.groupBox10.TabIndex = 21;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Savegame files";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Which savegame types should be checked?";
            // 
            // radioButtonQsOnly
            // 
            this.radioButtonQsOnly.AutoSize = true;
            this.radioButtonQsOnly.Location = new System.Drawing.Point(308, 53);
            this.radioButtonQsOnly.Name = "radioButtonQsOnly";
            this.radioButtonQsOnly.Size = new System.Drawing.Size(89, 23);
            this.radioButtonQsOnly.TabIndex = 2;
            this.radioButtonQsOnly.Text = "Quicksave";
            this.radioButtonQsOnly.UseVisualStyleBackColor = true;
            this.radioButtonQsOnly.CheckedChanged += new System.EventHandler(this.radioButtonQsOnly_CheckedChanged);
            // 
            // radioButtonAsOnly
            // 
            this.radioButtonAsOnly.AutoSize = true;
            this.radioButtonAsOnly.Location = new System.Drawing.Point(196, 53);
            this.radioButtonAsOnly.Name = "radioButtonAsOnly";
            this.radioButtonAsOnly.Size = new System.Drawing.Size(84, 23);
            this.radioButtonAsOnly.TabIndex = 1;
            this.radioButtonAsOnly.Text = "Autosave";
            this.radioButtonAsOnly.UseVisualStyleBackColor = true;
            this.radioButtonAsOnly.CheckedChanged += new System.EventHandler(this.radioButtonAsOnly_CheckedChanged);
            // 
            // radioButtonAsAndQs
            // 
            this.radioButtonAsAndQs.AutoSize = true;
            this.radioButtonAsAndQs.Checked = true;
            this.radioButtonAsAndQs.Location = new System.Drawing.Point(10, 53);
            this.radioButtonAsAndQs.Name = "radioButtonAsAndQs";
            this.radioButtonAsAndQs.Size = new System.Drawing.Size(164, 23);
            this.radioButtonAsAndQs.TabIndex = 0;
            this.radioButtonAsAndQs.TabStop = true;
            this.radioButtonAsAndQs.Text = "Autosave + Quicksave";
            this.radioButtonAsAndQs.UseVisualStyleBackColor = true;
            this.radioButtonAsAndQs.CheckedChanged += new System.EventHandler(this.radioButtonAsAndQs_CheckedChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 552);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(853, 600);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSettings_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSaveGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutosaveMaxRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutosaveRetrySeconds)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private ModernButton modernButtonKeyNameList;
        public System.Windows.Forms.TextBox textBoxCustomNameSchema;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxTerminateStartAppOnExit;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxProcess;
        private System.Windows.Forms.Button buttonSearchExtraSavegames;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPathExtraSavegames;
        private System.Windows.Forms.Button buttonSearchSaveGamePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPathSavegame;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelSaveGameCheck;
        private System.Windows.Forms.NumericUpDown numericUpDownSaveGame;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownProcess;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonCustomName;
        private System.Windows.Forms.RadioButton radioButtonSavegameContentSchema;
        private System.Windows.Forms.RadioButton radioButtonDirNameSchema;
        private System.Windows.Forms.Label labelAutoQsRetry;
        private System.Windows.Forms.NumericUpDown numericUpDownAutosaveRetrySeconds;
        private System.Windows.Forms.Label labelAutoQsMaxRetries;
        private System.Windows.Forms.NumericUpDown numericUpDownAutosaveMaxRetries;
        private System.Windows.Forms.GroupBox groupBox7;
        private ModernButton modernButtonCreateBackup;
        private System.ComponentModel.BackgroundWorker bgwBackup;
        private System.Windows.Forms.GroupBox groupBox8;
        private ModernButton modernButtonReset;
        private ModernButton modernButtonAddToAutostart;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox checkBoxSvgmDisableConfirmation;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonQsOnly;
        private System.Windows.Forms.RadioButton radioButtonAsOnly;
        private System.Windows.Forms.RadioButton radioButtonAsAndQs;
        private System.Windows.Forms.CheckBox checkBoxSvgmLoadAll;
    }
}