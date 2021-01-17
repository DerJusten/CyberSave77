
namespace CyberStart77
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownMinSaveGames = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownTryAutosave = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCustomNameSchema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPreview = new System.Windows.Forms.Label();
            this.modernButtonKeyNameList = new CyberStart77.ModernButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinSaveGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTryAutosave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minutes between savegames:";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPreview);
            this.groupBox1.Controls.Add(this.modernButtonKeyNameList);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCustomNameSchema);
            this.groupBox1.Controls.Add(this.numericUpDownTryAutosave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownMinSaveGames);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 319);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SaveGame";
            // 
            // numericUpDownMinSaveGames
            // 
            this.numericUpDownMinSaveGames.Location = new System.Drawing.Point(222, 34);
            this.numericUpDownMinSaveGames.Name = "numericUpDownMinSaveGames";
            this.numericUpDownMinSaveGames.Size = new System.Drawing.Size(74, 25);
            this.numericUpDownMinSaveGames.TabIndex = 1;
            this.numericUpDownMinSaveGames.ValueChanged += new System.EventHandler(this.numericUpDownMinSaveGames_ValueChanged);
            // 
            // numericUpDownTryAutosave
            // 
            this.numericUpDownTryAutosave.Location = new System.Drawing.Point(222, 75);
            this.numericUpDownTryAutosave.Name = "numericUpDownTryAutosave";
            this.numericUpDownTryAutosave.Size = new System.Drawing.Size(74, 25);
            this.numericUpDownTryAutosave.TabIndex = 3;
            this.numericUpDownTryAutosave.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTryAutosave.ValueChanged += new System.EventHandler(this.numericUpDownTryAutosave_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Autosave (experimental):";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // textBoxCustomNameSchema
            // 
            this.textBoxCustomNameSchema.Location = new System.Drawing.Point(6, 217);
            this.textBoxCustomNameSchema.Name = "textBoxCustomNameSchema";
            this.textBoxCustomNameSchema.Size = new System.Drawing.Size(391, 25);
            this.textBoxCustomNameSchema.TabIndex = 4;
            this.textBoxCustomNameSchema.TextChanged += new System.EventHandler(this.textBoxCustomNameSchema_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Custom Name Schema (experimental)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 73);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // labelPreview
            // 
            this.labelPreview.Location = new System.Drawing.Point(6, 245);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(391, 22);
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
            this.modernButtonKeyNameList.Location = new System.Drawing.Point(303, 276);
            this.modernButtonKeyNameList.Name = "modernButtonKeyNameList";
            this.modernButtonKeyNameList.Size = new System.Drawing.Size(94, 37);
            this.modernButtonKeyNameList.TabIndex = 9;
            this.modernButtonKeyNameList.Text = "Keyname List";
            this.modernButtonKeyNameList.TextColor = System.Drawing.SystemColors.ControlText;
            this.modernButtonKeyNameList.TextFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modernButtonKeyNameList.Click += new System.EventHandler(this.modernButtonKeyNameList_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 338);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSettings_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinSaveGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTryAutosave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownMinSaveGames;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDownTryAutosave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ModernButton modernButtonKeyNameList;
        public System.Windows.Forms.TextBox textBoxCustomNameSchema;
        private System.Windows.Forms.Label labelPreview;
    }
}