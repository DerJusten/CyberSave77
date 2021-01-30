
namespace CyberSave77
{
    partial class FormSaveGameManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSaveGameManager));
            this.panelDatagrid = new System.Windows.Forms.Panel();
            this.labelHint = new System.Windows.Forms.Label();
            this.labelDirNameDatagrid = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxFilterNonCustomSaves = new System.Windows.Forms.CheckBox();
            this.radioButtonOrderByName = new System.Windows.Forms.RadioButton();
            this.textBoxSearchBar = new System.Windows.Forms.TextBox();
            this.labelSelected = new System.Windows.Forms.Label();
            this.radioButtonOrderByLastWriteTime = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLeftButtons = new System.Windows.Forms.Panel();
            this.checkBoxSimulate = new System.Windows.Forms.CheckBox();
            this.comboBoxPath = new System.Windows.Forms.ComboBox();
            this.panelSaveGames = new System.Windows.Forms.Panel();
            this.labelCount = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxRefresh = new System.Windows.Forms.PictureBox();
            this.pictureBoxCopySelected = new System.Windows.Forms.PictureBox();
            this.pictureBoxMove = new System.Windows.Forms.PictureBox();
            this.pictureBoxDelete = new System.Windows.Forms.PictureBox();
            this.modernButtonEnableSelectionMode = new CyberSave77.ModernButton();
            this.modernButtonSelectAll = new CyberSave77.ModernButton();
            this.modernButtonHideDetails = new CyberSave77.ModernButton();
            this.modernButtonLoadMore = new CyberSave77.ModernButton();
            this.modernButtonScrollDown = new CyberSave77.ModernButton();
            this.modernButtonScrollUp = new CyberSave77.ModernButton();
            this.panelDatagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelLeftButtons.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopySelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDatagrid
            // 
            this.panelDatagrid.AutoScroll = true;
            this.panelDatagrid.Controls.Add(this.labelHint);
            this.panelDatagrid.Controls.Add(this.labelDirNameDatagrid);
            this.panelDatagrid.Controls.Add(this.dataGridView1);
            this.panelDatagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatagrid.Location = new System.Drawing.Point(0, 0);
            this.panelDatagrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelDatagrid.Name = "panelDatagrid";
            this.panelDatagrid.Size = new System.Drawing.Size(490, 768);
            this.panelDatagrid.TabIndex = 5;
            // 
            // labelHint
            // 
            this.labelHint.BackColor = System.Drawing.Color.Transparent;
            this.labelHint.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHint.Location = new System.Drawing.Point(52, 307);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(389, 131);
            this.labelHint.TabIndex = 5;
            this.labelHint.Text = "Click on a savegame for more information";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDirNameDatagrid
            // 
            this.labelDirNameDatagrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirNameDatagrid.Location = new System.Drawing.Point(3, 24);
            this.labelDirNameDatagrid.Name = "labelDirNameDatagrid";
            this.labelDirNameDatagrid.Size = new System.Drawing.Size(479, 25);
            this.labelDirNameDatagrid.TabIndex = 4;
            this.labelDirNameDatagrid.Text = "-";
            this.labelDirNameDatagrid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(479, 693);
            this.dataGridView1.TabIndex = 3;
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.pictureBoxRefresh);
            this.panelLeft.Controls.Add(this.label2);
            this.panelLeft.Controls.Add(this.checkBoxFilterNonCustomSaves);
            this.panelLeft.Controls.Add(this.radioButtonOrderByName);
            this.panelLeft.Controls.Add(this.textBoxSearchBar);
            this.panelLeft.Controls.Add(this.labelSelected);
            this.panelLeft.Controls.Add(this.radioButtonOrderByLastWriteTime);
            this.panelLeft.Controls.Add(this.modernButtonEnableSelectionMode);
            this.panelLeft.Controls.Add(this.modernButtonSelectAll);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.panelLeftButtons);
            this.panelLeft.Controls.Add(this.comboBoxPath);
            this.panelLeft.Controls.Add(this.panelSaveGames);
            this.panelLeft.Controls.Add(this.labelCount);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(737, 772);
            this.panelLeft.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sort by:";
            // 
            // checkBoxFilterNonCustomSaves
            // 
            this.checkBoxFilterNonCustomSaves.AutoSize = true;
            this.checkBoxFilterNonCustomSaves.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterNonCustomSaves.Location = new System.Drawing.Point(469, 43);
            this.checkBoxFilterNonCustomSaves.Name = "checkBoxFilterNonCustomSaves";
            this.checkBoxFilterNonCustomSaves.Size = new System.Drawing.Size(150, 19);
            this.checkBoxFilterNonCustomSaves.TabIndex = 13;
            this.checkBoxFilterNonCustomSaves.Text = "filter non-custom saves";
            this.checkBoxFilterNonCustomSaves.UseVisualStyleBackColor = true;
            this.checkBoxFilterNonCustomSaves.CheckedChanged += new System.EventHandler(this.checkBoxFilterNonCustomSaves_CheckedChanged);
            // 
            // radioButtonOrderByName
            // 
            this.radioButtonOrderByName.AutoSize = true;
            this.radioButtonOrderByName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOrderByName.Location = new System.Drawing.Point(408, 42);
            this.radioButtonOrderByName.Name = "radioButtonOrderByName";
            this.radioButtonOrderByName.Size = new System.Drawing.Size(57, 19);
            this.radioButtonOrderByName.TabIndex = 16;
            this.radioButtonOrderByName.Text = "Name";
            this.radioButtonOrderByName.UseVisualStyleBackColor = true;
            this.radioButtonOrderByName.CheckedChanged += new System.EventHandler(this.radioButtonOrderByName_CheckedChanged);
            // 
            // textBoxSearchBar
            // 
            this.textBoxSearchBar.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxSearchBar.Location = new System.Drawing.Point(261, 12);
            this.textBoxSearchBar.Name = "textBoxSearchBar";
            this.textBoxSearchBar.Size = new System.Drawing.Size(256, 25);
            this.textBoxSearchBar.TabIndex = 13;
            this.textBoxSearchBar.Text = "Search...";
            this.textBoxSearchBar.TextChanged += new System.EventHandler(this.textBoxSearchBar_TextChanged);
            this.textBoxSearchBar.Enter += new System.EventHandler(this.textBoxSearchBar_Enter);
            this.textBoxSearchBar.Leave += new System.EventHandler(this.textBoxSearchBar_Leave);
            // 
            // labelSelected
            // 
            this.labelSelected.Location = new System.Drawing.Point(8, 698);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(121, 16);
            this.labelSelected.TabIndex = 12;
            this.labelSelected.Text = "Selected: 999/999";
            this.labelSelected.Visible = false;
            // 
            // radioButtonOrderByLastWriteTime
            // 
            this.radioButtonOrderByLastWriteTime.AutoSize = true;
            this.radioButtonOrderByLastWriteTime.Checked = true;
            this.radioButtonOrderByLastWriteTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOrderByLastWriteTime.Location = new System.Drawing.Point(307, 42);
            this.radioButtonOrderByLastWriteTime.Name = "radioButtonOrderByLastWriteTime";
            this.radioButtonOrderByLastWriteTime.Size = new System.Drawing.Size(99, 19);
            this.radioButtonOrderByLastWriteTime.TabIndex = 15;
            this.radioButtonOrderByLastWriteTime.TabStop = true;
            this.radioButtonOrderByLastWriteTime.Text = "last write time";
            this.radioButtonOrderByLastWriteTime.UseVisualStyleBackColor = true;
            this.radioButtonOrderByLastWriteTime.CheckedChanged += new System.EventHandler(this.radioButtonOrderByLastWriteTime_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "SaveGame Directory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelLeftButtons
            // 
            this.panelLeftButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftButtons.Controls.Add(this.pictureBoxCopySelected);
            this.panelLeftButtons.Controls.Add(this.checkBoxSimulate);
            this.panelLeftButtons.Controls.Add(this.pictureBoxMove);
            this.panelLeftButtons.Controls.Add(this.modernButtonHideDetails);
            this.panelLeftButtons.Controls.Add(this.pictureBoxDelete);
            this.panelLeftButtons.Controls.Add(this.modernButtonLoadMore);
            this.panelLeftButtons.Controls.Add(this.modernButtonScrollDown);
            this.panelLeftButtons.Controls.Add(this.modernButtonScrollUp);
            this.panelLeftButtons.Location = new System.Drawing.Point(-2, 716);
            this.panelLeftButtons.Name = "panelLeftButtons";
            this.panelLeftButtons.Size = new System.Drawing.Size(737, 56);
            this.panelLeftButtons.TabIndex = 2;
            // 
            // checkBoxSimulate
            // 
            this.checkBoxSimulate.AutoSize = true;
            this.checkBoxSimulate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSimulate.Location = new System.Drawing.Point(235, 18);
            this.checkBoxSimulate.Name = "checkBoxSimulate";
            this.checkBoxSimulate.Size = new System.Drawing.Size(71, 19);
            this.checkBoxSimulate.TabIndex = 14;
            this.checkBoxSimulate.Text = "simulate";
            this.checkBoxSimulate.UseVisualStyleBackColor = true;
            this.checkBoxSimulate.Visible = false;
            // 
            // comboBoxPath
            // 
            this.comboBoxPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPath.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPath.FormattingEnabled = true;
            this.comboBoxPath.Location = new System.Drawing.Point(8, 31);
            this.comboBoxPath.Name = "comboBoxPath";
            this.comboBoxPath.Size = new System.Drawing.Size(228, 28);
            this.comboBoxPath.TabIndex = 1;
            this.comboBoxPath.SelectedIndexChanged += new System.EventHandler(this.comboBoxPath_SelectedIndexChanged);
            this.comboBoxPath.MouseHover += new System.EventHandler(this.comboBoxPath_MouseHover);
            // 
            // panelSaveGames
            // 
            this.panelSaveGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSaveGames.AutoScroll = true;
            this.panelSaveGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSaveGames.Location = new System.Drawing.Point(8, 66);
            this.panelSaveGames.Name = "panelSaveGames";
            this.panelSaveGames.Size = new System.Drawing.Size(720, 632);
            this.panelSaveGames.TabIndex = 0;
            // 
            // labelCount
            // 
            this.labelCount.Location = new System.Drawing.Point(672, 697);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(63, 19);
            this.labelCount.TabIndex = 8;
            this.labelCount.Text = "999/999";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelDatagrid);
            this.panelRight.Location = new System.Drawing.Point(743, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(490, 772);
            this.panelRight.TabIndex = 9;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 750;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // pictureBoxRefresh
            // 
            this.pictureBoxRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRefresh.Image = global::CyberSave77.Properties.Resources._032_repeat_1;
            this.pictureBoxRefresh.Location = new System.Drawing.Point(523, 12);
            this.pictureBoxRefresh.Name = "pictureBoxRefresh";
            this.pictureBoxRefresh.Size = new System.Drawing.Size(26, 25);
            this.pictureBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRefresh.TabIndex = 18;
            this.pictureBoxRefresh.TabStop = false;
            this.pictureBoxRefresh.Click += new System.EventHandler(this.pictureBoxRefresh_Click);
            // 
            // pictureBoxCopySelected
            // 
            this.pictureBoxCopySelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCopySelected.Image = global::CyberSave77.Properties.Resources.add_file;
            this.pictureBoxCopySelected.Location = new System.Drawing.Point(119, 7);
            this.pictureBoxCopySelected.Name = "pictureBoxCopySelected";
            this.pictureBoxCopySelected.Size = new System.Drawing.Size(47, 35);
            this.pictureBoxCopySelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCopySelected.TabIndex = 15;
            this.pictureBoxCopySelected.TabStop = false;
            this.pictureBoxCopySelected.Visible = false;
            this.pictureBoxCopySelected.Click += new System.EventHandler(this.pictureBoxCopySelected_Click);
            // 
            // pictureBoxMove
            // 
            this.pictureBoxMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMove.Image = global::CyberSave77.Properties.Resources.move;
            this.pictureBoxMove.Location = new System.Drawing.Point(66, 7);
            this.pictureBoxMove.Name = "pictureBoxMove";
            this.pictureBoxMove.Size = new System.Drawing.Size(47, 35);
            this.pictureBoxMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMove.TabIndex = 12;
            this.pictureBoxMove.TabStop = false;
            this.pictureBoxMove.Visible = false;
            this.pictureBoxMove.Click += new System.EventHandler(this.pictureBoxMove_Click);
            // 
            // pictureBoxDelete
            // 
            this.pictureBoxDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDelete.Image = global::CyberSave77.Properties.Resources._097_delete_3;
            this.pictureBoxDelete.Location = new System.Drawing.Point(13, 7);
            this.pictureBoxDelete.Name = "pictureBoxDelete";
            this.pictureBoxDelete.Size = new System.Drawing.Size(47, 35);
            this.pictureBoxDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDelete.TabIndex = 11;
            this.pictureBoxDelete.TabStop = false;
            this.pictureBoxDelete.Visible = false;
            this.pictureBoxDelete.Click += new System.EventHandler(this.pictureBoxDelete_Click);
            // 
            // modernButtonEnableSelectionMode
            // 
            this.modernButtonEnableSelectionMode.BackColor = System.Drawing.Color.White;
            this.modernButtonEnableSelectionMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonEnableSelectionMode.ClickEffectEnabled = true;
            this.modernButtonEnableSelectionMode.DefaultColor = System.Drawing.Color.White;
            this.modernButtonEnableSelectionMode.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonEnableSelectionMode.Location = new System.Drawing.Point(565, 3);
            this.modernButtonEnableSelectionMode.Name = "modernButtonEnableSelectionMode";
            this.modernButtonEnableSelectionMode.Size = new System.Drawing.Size(163, 22);
            this.modernButtonEnableSelectionMode.TabIndex = 10;
            this.modernButtonEnableSelectionMode.Text = "Enable selection mode";
            this.modernButtonEnableSelectionMode.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonEnableSelectionMode.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonEnableSelectionMode.Click += new System.EventHandler(this.modernButtonEnableSelectionMode_Click);
            // 
            // modernButtonSelectAll
            // 
            this.modernButtonSelectAll.BackColor = System.Drawing.Color.White;
            this.modernButtonSelectAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonSelectAll.ClickEffectEnabled = true;
            this.modernButtonSelectAll.DefaultColor = System.Drawing.Color.White;
            this.modernButtonSelectAll.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonSelectAll.Location = new System.Drawing.Point(625, 34);
            this.modernButtonSelectAll.Name = "modernButtonSelectAll";
            this.modernButtonSelectAll.Size = new System.Drawing.Size(103, 22);
            this.modernButtonSelectAll.TabIndex = 11;
            this.modernButtonSelectAll.Text = "Select all";
            this.modernButtonSelectAll.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonSelectAll.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonSelectAll.Visible = false;
            this.modernButtonSelectAll.Click += new System.EventHandler(this.modernButtonSelectAll_Click);
            // 
            // modernButtonHideDetails
            // 
            this.modernButtonHideDetails.BackColor = System.Drawing.Color.White;
            this.modernButtonHideDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonHideDetails.ClickEffectEnabled = true;
            this.modernButtonHideDetails.DefaultColor = System.Drawing.Color.White;
            this.modernButtonHideDetails.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonHideDetails.Location = new System.Drawing.Point(329, 6);
            this.modernButtonHideDetails.Name = "modernButtonHideDetails";
            this.modernButtonHideDetails.Size = new System.Drawing.Size(91, 35);
            this.modernButtonHideDetails.TabIndex = 14;
            this.modernButtonHideDetails.Text = "Hide details";
            this.modernButtonHideDetails.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonHideDetails.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonHideDetails.Click += new System.EventHandler(this.modernButtonHideDetails_Click);
            // 
            // modernButtonLoadMore
            // 
            this.modernButtonLoadMore.BackColor = System.Drawing.Color.White;
            this.modernButtonLoadMore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonLoadMore.ClickEffectEnabled = true;
            this.modernButtonLoadMore.DefaultColor = System.Drawing.Color.White;
            this.modernButtonLoadMore.HoverColor = System.Drawing.Color.LightGray;
            this.modernButtonLoadMore.Location = new System.Drawing.Point(480, 6);
            this.modernButtonLoadMore.Name = "modernButtonLoadMore";
            this.modernButtonLoadMore.Size = new System.Drawing.Size(129, 36);
            this.modernButtonLoadMore.TabIndex = 7;
            this.modernButtonLoadMore.Text = "load more files";
            this.modernButtonLoadMore.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonLoadMore.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonLoadMore.Click += new System.EventHandler(this.modernButtonLoadMore_Click);
            // 
            // modernButtonScrollDown
            // 
            this.modernButtonScrollDown.BackColor = System.Drawing.Color.Transparent;
            this.modernButtonScrollDown.BackgroundImage = global::CyberSave77.Properties.Resources.bottom;
            this.modernButtonScrollDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.modernButtonScrollDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonScrollDown.ClickEffectEnabled = true;
            this.modernButtonScrollDown.DefaultColor = System.Drawing.Color.Transparent;
            this.modernButtonScrollDown.HoverColor = System.Drawing.Color.Transparent;
            this.modernButtonScrollDown.Location = new System.Drawing.Point(674, 7);
            this.modernButtonScrollDown.Name = "modernButtonScrollDown";
            this.modernButtonScrollDown.Size = new System.Drawing.Size(53, 35);
            this.modernButtonScrollDown.TabIndex = 9;
            this.modernButtonScrollDown.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonScrollDown.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonScrollDown.Click += new System.EventHandler(this.modernButtonScrollDown_Click);
            // 
            // modernButtonScrollUp
            // 
            this.modernButtonScrollUp.BackColor = System.Drawing.Color.Transparent;
            this.modernButtonScrollUp.BackgroundImage = global::CyberSave77.Properties.Resources.up_arrow;
            this.modernButtonScrollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.modernButtonScrollUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modernButtonScrollUp.ClickEffectEnabled = true;
            this.modernButtonScrollUp.DefaultColor = System.Drawing.Color.Transparent;
            this.modernButtonScrollUp.HoverColor = System.Drawing.Color.Transparent;
            this.modernButtonScrollUp.Location = new System.Drawing.Point(615, 6);
            this.modernButtonScrollUp.Name = "modernButtonScrollUp";
            this.modernButtonScrollUp.Size = new System.Drawing.Size(53, 36);
            this.modernButtonScrollUp.TabIndex = 0;
            this.modernButtonScrollUp.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonScrollUp.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonScrollUp.Click += new System.EventHandler(this.modernButtonScrollUp_Click);
            // 
            // FormSaveGameManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1233, 766);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1249, 805);
            this.Name = "FormSaveGameManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SaveGameManager (Beta)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSaveGameManager_FormClosed);
            this.Load += new System.EventHandler(this.FormSaveGameManager_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSaveGameManager_KeyDown);
            this.panelDatagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelLeftButtons.ResumeLayout(false);
            this.panelLeftButtons.PerformLayout();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopySelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDatagrid;
        private System.Windows.Forms.Label labelDirNameDatagrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelLeft;
        private ModernButton modernButtonLoadMore;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelSaveGames;
        private System.Windows.Forms.ComboBox comboBoxPath;
        private System.Windows.Forms.Panel panelLeftButtons;
        private System.Windows.Forms.Label labelCount;
        private ModernButton modernButtonScrollDown;
        private ModernButton modernButtonScrollUp;
        private System.Windows.Forms.Label label1;
        private ModernButton modernButtonSelectAll;
        private ModernButton modernButtonEnableSelectionMode;
        private System.Windows.Forms.PictureBox pictureBoxDelete;
        private System.Windows.Forms.PictureBox pictureBoxMove;
        private ModernButton modernButtonHideDetails;
        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxFilterNonCustomSaves;
        private System.Windows.Forms.CheckBox checkBoxSimulate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonOrderByName;
        private System.Windows.Forms.RadioButton radioButtonOrderByLastWriteTime;
        private System.Windows.Forms.TextBox textBoxSearchBar;
        private System.Windows.Forms.PictureBox pictureBoxCopySelected;
        private System.Windows.Forms.PictureBox pictureBoxRefresh;
    }
}