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
using System.Reflection;

namespace CyberSave77
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
                checkBoxTerminateStartAppOnExit.Text = "close all started applications, when " + Properties.Settings.Default.processName + " exits";
            else
                checkBoxTerminateStartAppOnExit.Text = "close all started applications, when main process exits";

            numericUpDownAutosaveMaxRetries.Value = Properties.Settings.Default.autoQuickSaveMaxRetries;
            numericUpDownAutosaveRetrySeconds.Value = Properties.Settings.Default.autoQuickSaveErrorDelay;

            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "CyberSave77.lnk")))
                modernButtonAddToAutostart.Text = "Remove from Autostart";
            else
                modernButtonAddToAutostart.Text = "Start with Windows";

            checkBoxSvgmDisableConfirmation.Checked = Properties.Settings.Default.svgmDisableConfirmation;

            if (Properties.Settings.Default.savegameCheckMode == 0)
                radioButtonAsAndQs.Checked = true;
            else if (Properties.Settings.Default.savegameCheckMode == 1)
                radioButtonAsOnly.Checked = true;
            else if (Properties.Settings.Default.savegameCheckMode == 2)
                radioButtonQsOnly.Checked = true;

            checkBoxSvgmLoadAll.Checked= Properties.Settings.Default.svgmLoadAll; 
        }


        private void textBoxCustomNameSchema_TextChanged(object sender, EventArgs e)
        {
          //  Regex reg = new Regex("[\\<>:\"\\/\\|\\?\\*]");
            Regex reg = new Regex(@"^[a-zA-Z 0-9\.\,\+\-_\*]*$");
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
            if (!System.IO.File.Exists(Path.Combine(folder, filename)))
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
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "CyberSave77.lnk")))
                File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "CyberSave77.lnk"));

            Application.Restart();
        }

        private void setTooltip(string text, Control ctrl)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(ctrl, text);
        }
        private void textBoxProcess_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Name of the process to check (not editable)", textBoxProcess);
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Sets the interval when the process (" + Properties.Settings.Default.processName + ") is checked", label8);
        }

        private void labelSaveGameCheck_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Sets the interval when the savegame files get checked", labelSaveGameCheck);
        }

        private void checkBoxTerminateStartAppOnExit_MouseHover(object sender, EventArgs e)
        {
            setTooltip("All applications started by CyperSave77 get closed, when " + Properties.Settings.Default.processName + " exits", checkBoxTerminateStartAppOnExit);
        }

        private void labelAutoQsRetry_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Interval between the retries when an auto quicksave failed", labelAutoQsRetry);
        }

        private void labelAutoQsMaxRetries_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Number of retries when an auto quicksave failed", labelAutoQsMaxRetries);
        }

        private void textBoxPathSavegame_MouseHover(object sender, EventArgs e)
        {
            setTooltip(@"Path to your default savegames in CyberPunk2077 (default %userdir%\Saved Games\CD Projekt Red\Cyberpunk 2077)", textBoxPathSavegame);
        }

        private void textBoxPathExtraSavegames_MouseHover(object sender, EventArgs e)
        {
            setTooltip(@"Path will be used for your copied Auto-/Quicksaves. Can be different than the default savegame path.", textBoxPathSavegame);
        }

        private void radioButtonDirNameSchema_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Sets the directory name of your copied savegame to |Autosave-Date| (e.g. 'Autosave-21_01_2021-17-05-33')", radioButtonDirNameSchema);
        }

        private void radioButtonSavegameContentSchema_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Sets the directory name of your copied savegame to |Path Gender Level Date| (e.g. 'Nomad Female 27 19-01-21_21-58-13')", radioButtonSavegameContentSchema);
        }

        private void radioButtonCustomName_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Sets the directory name of your copied savem to any custom name, including data of your savegames", radioButtonCustomName);
        }

        private void modernButtonAddToAutostart_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "CyberSave77.lnk")))
            {
                File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "CyberSave77.lnk"));
                modernButtonAddToAutostart.Text = "Start with Windows";
            }
            else
            {
                CreateShortcut();
                modernButtonAddToAutostart.Text = "Remove from Autostart";
            }
        }

        private void CreateShortcut()
        {

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            string shortcutAddress = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "CyberSave77.lnk");
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);

            shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
            shortcut.WorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            shortcut.Save();
        }

        private void modernButtonAddToAutostart_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Adds or removes CyberSave77 from Windows Autostart", modernButtonAddToAutostart);
        }

        private void modernButtonCreateBackup_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Creates a ZIP backup of your default savegame directory", modernButtonCreateBackup);
        }

        private void modernButtonReset_MouseHover(object sender, EventArgs e)
        {
            setTooltip("Resets all the settings to default and restarts CyberSave77", modernButtonReset);
        }

        private void checkBoxSGMdisableConfirmation_MouseHover(object sender, EventArgs e)
        {
            setTooltip("won't disable dialogue for multiple selections", checkBoxSvgmDisableConfirmation);
        }

        private void checkBoxSGMdisableConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.svgmDisableConfirmation = checkBoxSvgmDisableConfirmation.Checked;
            Properties.Settings.Default.Save();
        }

        private void radioButtonAsAndQs_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegameCheckMode = 0;
            Properties.Settings.Default.Save();
        }

        private void radioButtonAsOnly_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegameCheckMode = 1;
            Properties.Settings.Default.Save();
        }

        private void radioButtonQsOnly_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.savegameCheckMode = 2;
            Properties.Settings.Default.Save();
        }

        private void checkBoxSvgmLoadAll_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.svgmLoadAll = checkBoxSvgmLoadAll.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
