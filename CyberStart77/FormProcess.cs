using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CyberStart77
{
    public partial class FormProcess : Form
    {
        public FormProcess(ProcInfoMin pMin,bool editMode)
        {
            InitializeComponent();
            procInfo = pMin;
            editModeEnabled = editMode;
        }

        private ProcInfoMin procInfo;
        private bool editModeEnabled;
        private void buttonPathProcess_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = ""
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxProcessfile.Text = ofd.FileName;
            }
        }

        private void buttonPathWorkingDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (textBoxProcessfile.Text != string.Empty)
                fbd.SelectedPath = Path.GetDirectoryName(textBoxProcessfile.Text);
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxProcessWdir.Text = fbd.SelectedPath;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ((editModeEnabled == true)||  Form1.ExistsProcessFriendlyName(textBoxProcessname.Text) == false)
            {
                Form1.procInfo.friendlyName = textBoxProcessname.Text;
                Form1.procInfo.processFile = textBoxProcessfile.Text;
                Form1.procInfo.processWorkDir = textBoxProcessWdir.Text;
                Form1.procInfo.processArguments = textBoxProcessArg.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("The process name " + textBoxProcessname.Text + " already exists.");
        }

        private void FormProcess_Load(object sender, EventArgs e)
        {
            if (procInfo != null)
            {
                textBoxProcessfile.Text = procInfo.processFile;
                textBoxProcessname.Text = procInfo.friendlyName;
                textBoxProcessWdir.Text = procInfo.processWorkDir;
                textBoxProcessArg.Text = procInfo.processArguments;
            }
              
        }
    }
}
