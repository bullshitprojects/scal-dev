using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDescriptiva_Click(object sender, EventArgs e)
        {
            frmDescriptiva frm = new frmDescriptiva();
            frm.Show();
            this.Close();
        }

    }
}
