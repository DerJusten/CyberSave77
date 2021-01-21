using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CyberSave77
{
    public partial class FormKeyNames : Form
    {
        public FormKeyNames(FormSettings fs)
        {
            InitializeComponent();
            fSettings = fs;
        }
        private FormSettings fSettings;
        private void FormKeyNames_Load(object sender, EventArgs e)
        {
            FormSettings.keylistOpen = true;
            JObject jo = Form1.readJsonFromFile(Properties.Resources.test_json_106);

            listBox1.Items.Add("#Date of Savegame");
            foreach (JProperty item in jo["Data"]["metadata"])
            {
                if (item.Name != "playerPosition")
                listBox1.Items.Add(item.Name);
            }
           
        }

        private void FormKeyNames_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormSettings.keylistOpen = false;
        }

        private void FormKeyNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                if(listBox1.SelectedItem.ToString() == "#Date of Savegame")
                    fSettings.textBoxCustomNameSchema.AppendText("[dd-MM-yy_HH-mm-ss]");
                else
                fSettings.textBoxCustomNameSchema.AppendText("%"+listBox1.SelectedItem.ToString()+"%");
            }
        }
    }
}
