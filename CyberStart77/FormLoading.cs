using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberStart77
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            progressBar1.Location = new Point((this.Width - progressBar1.Width) / 2, progressBar1.Location.Y);
            label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
        }
    }
}
