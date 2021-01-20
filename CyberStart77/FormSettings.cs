using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace CyberStart77
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        public static bool keylistOpen = false;
        private FormKeyNames fKN;
        private JObject exampleJson;
        private FormLoading fl;

        private void FormSettings_Load(object sender, EventArgs e)
        {

            exampleJson = Form1.readJsonFromFile(Properties.Resources.test_json_106);
            //numericUpDownTryAutosave.Minimum = (Properties.Settings.Default.savegameTimer / 60);


            loadSettings();

        }

        private void loadSettings()
        {

            if (!string.IsNullOrEmpty(Properties.Settings.Default.customNameSchema))
                radioButtonCustomName.Text = "Savegame Custom (" + Properties.Settings.Default.customNameSchema + ")";
            textBoxPathExtraSavegames.Text = Properties.Settings.Default.savegameHistoryPath;
            textBoxPathSavegame.Text = Properties.Settings.Default.savegameDefaultPath;
            textBoxProcess.Text = Properties.Settings.Default.processName;
            textBoxCustomNameSchema.Text = Properties.Settings.Default.customNameSchema;

            if (Properties.Settings.Default.nameSchemaMode == 1)
                radioButtonSavegameContentSchema.Checked = true;

            else if (Properties.Settings.Default.nameSchemaMode == 2)
                radioButtonCustomName.Checked = true;
            else
                radioButtonDirNameSchema.Checked = true;


            numericUpDownProcess.Value = Properties.Settings.Default.counterProcessCheck;
            numericUpDownSaveGame.Value = Properties.Settings.Default.intervalSaveGameCheckSeconds;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.processName))
                checkBoxTerminateStartAppOnExit.Text = "terminate application(s) when " + Properties.Settings.Default.processName + " exited";
            else
                checkBoxTerminateStartAppOnExit.Text = "terminate application(s) when main process exited";

            numericUpDownAutosaveMaxRetries.Value = Properties.Settings.Default.autoQuickSaveMaxRetries;
            numericUpDownAutosaveRetrySeconds.Value = Properties.Settings.Default.autoQuickSaveErrorDelay;
        }


        private void textBoxCustomNameSchema_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("[\\<>:\"\\/\\|\\?\\*]");
            if (!reg.IsMatch(textBoxCustomNameSchema.Text))
            {
                textBoxCustomNameSchema.BackColor = Color.White;
                Properties.Settings.Default.customNameSchema = textBoxCustomNameSchema.Text;
                Properties.Settings.Default.Save();
                labelPreview.Text = Form1.getNameSchemaSaveGame(exampleJson, DateTime.Now);
            }
            else
            {
                textBoxCustomNameSchema.BackColor = Color.LightCoral;
            }

        }

        private void modernButtonTestSchema_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(Form1.getNameSchemaSaveGame(, DateTime.Now));
        }

        private void FormSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void modernButtonKeyNameList_Click(object sender, EventArgs e)
        {
            if (keylistOpen == false)
            {
                fKN = new FormKeyNames(this);
                keylistOpen = true;
                fKN.Location = new Point(this.Right, this.Location.Y);
                fKN.Show();
            }

        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fKN != null)
            {
                if (keylistOpen == true)
                    fKN.Close();

                fKN.Dispose();
            }
        }

        private void textBoxProcess_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.processName = textBoxProcess.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxPathSavegame_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!string.IsNullOrEmpty(tb.Text))
                Process.Start(tb.Text);
        }

        private void buttonSearchSaveGamePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPathSavegame.Text = fbd.SelectedPath;
            }
        }

        private void buttonSearchExtraSavegames_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (textBoxPathSavegame.Text != string.Empty)
                fbd.SelectedPath = textBoxPathSavegame.Text;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPathExtraSavegames.Text = fbd.SelectedPath;
            }
        }

        private void numericUpDownProcess_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.counterProcessCheck = (int)numericUpDownSaveGame.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDownSaveGame_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.intervalSaveGameCheckSeconds = (int)numericUpDownSaveGame.Value;
            Properties.Settings.Default.Save();
        }

        private void radioButtonDirNameSchema_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDirNameSchema.Checked == true)
                Properties.Settings.Default.nameSchemaMode = 0;
            Properties.Settings.Default.Save();
        }

        private void radioButtonSavegameContentSchema_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSavegameContentSchema.Checked == true)
                Properties.Settings.Default.nameSchemaMode = 1;
            Properties.Settings.Default.Save();
        }

        private void radioButtonCustomName_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.nameSchemaMode = 2;
            Properties.Settings.Default.Save();
        }

        private void textBoxProcess_Leave(object sender, EventArgs e)
        {
            if (textBoxProcess.Text.Contains("."))
                textBoxProcess.Text = textBoxProcess.Text.Split('.').FirstOrDefault();
        }

        private void numericUpDownAutosaveRetrySeconds_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoQuickSaveErrorDelay = (int)numericUpDownAutosaveRetrySeconds.Value;
            Properties.Settings.Default.Save();
        }

        private void numericUpDownAutosaveMaxRetries_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoQuickSaveMaxRetries = (int)numericUpDownAutosaveMaxRetries.Value;
            Properties.Settings.Default.Save();
        }

        private void textBoxPathExtraSavegames_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegameHistoryPath = textBoxPathExtraSavegames.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxPathSavegame_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegameDefaultPath = textBoxPathSavegame.Text;
            Properties.Settings.Default.Save();
        }

        private void modernButtonCreateBackup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.savegameDefaultPath))
            {
                fl = new FormLoading();
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                    bgwBackup.RunWorkerAsync(fbd.SelectedPath);
            }
            else
                MessageBox.Show("Invalid save game path. Please check your settings");


        }

        private void bgwBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwBackup.ReportProgress(0);
            string folder = (string)e.Argument;
            String filename = "CB2077_SaveGame_BK_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + ".zip";
            if (!File.Exists(Path.Combine(folder, filename)))
            {
                ZipFile.CreateFromDirectory(Properties.Settings.Default.savegameDefaultPath, Path.Combine(folder, filename));
                e.Result = "Successfully created backup at " + Path.Combine(folder, filename);
            }
            else
                e.Result = "Filename already exists, please check backup location";
        }

        private void bgwBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            fl.ShowDialog();
        }

        private void bgwBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fl.Close();
            fl.Dispose();
            if (e.Result != null)
                MessageBox.Show(e.Result.ToString());
        }

        private void modernButtonReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();

            Application.Restart();
        }
    }
}
