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
        private void numericUpDownMinSaveGames_ValueChanged(object sender, EventArgs e)
        {

            if (numericUpDownTryAutosave.Value < numericUpDownMinSaveGames.Value && numericUpDownTryAutosave.Value != 0)
            {
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.SetToolTip(numericUpDownMinSaveGames, "'Minutes between Savegames' value shouldn't be higher than 'Autosave'");
            }
            Properties.Settings.Default.minDifferenceLastSaveGame = (int)numericUpDownMinSaveGames.Value;
            Properties.Settings.Default.Save();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        { 
            
            exampleJson = Form1.readJsonFromFile(Properties.Resources.test_json_106);
            numericUpDownTryAutosave.Minimum = (Properties.Settings.Default.savegameTimer / 60);
            numericUpDownMinSaveGames.Value = Properties.Settings.Default.minDifferenceLastSaveGame;
            numericUpDownTryAutosave.Value = Properties.Settings.Default.minAutosaveGame;
            textBoxCustomNameSchema.Text = Properties.Settings.Default.customNameSchema;

           
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(label1, "Copy only savegames which are older than " + numericUpDownMinSaveGames.Value + " minutes than the last save.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(label2, "Try to autosave the game if the latest save is older than " + numericUpDownMinSaveGames.Value + " minutes (0 is disable)");
        }

        private void numericUpDownTryAutosave_ValueChanged(object sender, EventArgs e)
        {

            if (numericUpDownTryAutosave.Value < numericUpDownMinSaveGames.Value && numericUpDownTryAutosave.Value != 0)
            {
                toolTip1.ShowAlways = true;
                toolTip1.IsBalloon = true;
                toolTip1.SetToolTip(numericUpDownTryAutosave, "Autosave value shouldn't be lower than 'Minutes between Savegames'");
            }

            Properties.Settings.Default.minAutosaveGame = (int)numericUpDownTryAutosave.Value;
            Properties.Settings.Default.Save();
        }

        private void textBoxCustomNameSchema_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("[\\<>:\"\\/\\|\\?\\*]");
            if (!reg.IsMatch(textBoxCustomNameSchema.Text))
            {
                textBoxCustomNameSchema.BackColor = Color.White;
                Properties.Settings.Default.customNameSchema = textBoxCustomNameSchema.Text;
                Properties.Settings.Default.Save();
               labelPreview.Text= Form1.getNameSchemaSaveGame(exampleJson, DateTime.Now);
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
    }
}
