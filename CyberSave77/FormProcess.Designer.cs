
namespace CyberSave77
{
    partial class FormProcess
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProcessArg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPathWorkingDir = new System.Windows.Forms.Button();
            this.textBoxProcessWdir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPathProcess = new System.Windows.Forms.Button();
            this.textBoxProcessfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProcessname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(369, 274);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(130, 45);
            this.buttonSave.TabIndex = 23;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Arguments (optional)";
            // 
            // textBoxProcessArg
            // 
            this.textBoxProcessArg.Location = new System.Drawing.Point(16, 230);
            this.textBoxProcessArg.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxProcessArg.Name = "textBoxProcessArg";
            this.textBoxProcessArg.Size = new System.Drawing.Size(430, 29);
            this.textBoxProcessArg.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Process working directory";
            // 
            // buttonPathWorkingDir
            // 
            this.buttonPathWorkingDir.Location = new System.Drawing.Point(454, 165);
            this.buttonPathWorkingDir.Name = "buttonPathWorkingDir";
            this.buttonPathWorkingDir.Size = new System.Drawing.Size(34, 29);
            this.buttonPathWorkingDir.TabIndex = 19;
            this.buttonPathWorkingDir.Text = "...";
            this.buttonPathWorkingDir.UseVisualStyleBackColor = true;
            this.buttonPathWorkingDir.Click += new System.EventHandler(this.buttonPathWorkingDir_Click);
            // 
            // textBoxProcessWdir
            // 
            this.textBoxProcessWdir.Location = new System.Drawing.Point(16, 165);
            this.textBoxProcessWdir.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxProcessWdir.Name = "textBoxProcessWdir";
            this.textBoxProcessWdir.ReadOnly = true;
            this.textBoxProcessWdir.Size = new System.Drawing.Size(430, 29);
            this.textBoxProcessWdir.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Path to process (.exe)";
            // 
            // buttonPathProcess
            // 
            this.buttonPathProcess.Location = new System.Drawing.Point(454, 100);
            this.buttonPathProcess.Name = "buttonPathProcess";
            this.buttonPathProcess.Size = new System.Drawing.Size(34, 29);
            this.buttonPathProcess.TabIndex = 16;
            this.buttonPathProcess.Text = "...";
            this.buttonPathProcess.UseVisualStyleBackColor = true;
            this.buttonPathProcess.Click += new System.EventHandler(this.buttonPathProcess_Click);
            // 
            // textBoxProcessfile
            // 
            this.textBoxProcessfile.Location = new System.Drawing.Point(16, 100);
            this.textBoxProcessfile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxProcessfile.Name = "textBoxProcessfile";
            this.textBoxProcessfile.ReadOnly = true;
            this.textBoxProcessfile.Size = new System.Drawing.Size(430, 29);
            this.textBoxProcessfile.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Processname";
            // 
            // textBoxProcessname
            // 
            this.textBoxProcessname.Location = new System.Drawing.Point(16, 35);
            this.textBoxProcessname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBoxProcessname.Name = "textBoxProcessname";
            this.textBoxProcessname.Size = new System.Drawing.Size(430, 29);
            this.textBoxProcessname.TabIndex = 13;
            // 
            // FormProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 331);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxProcessArg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonPathWorkingDir);
            this.Controls.Add(this.textBoxProcessWdir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPathProcess);
            this.Controls.Add(this.textBoxProcessfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProcessname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProcessEditior";
            this.Load += new System.EventHandler(this.FormProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProcessArg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPathWorkingDir;
        private System.Windows.Forms.TextBox textBoxProcessWdir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPathProcess;
        private System.Windows.Forms.TextBox textBoxProcessfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProcessname;
    }
}