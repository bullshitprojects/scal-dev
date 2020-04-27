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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pprogress.Width += 3;
            if (pprogress.Width>=pback.Width)
            {
                timer.Stop();
                frmMain frm = new frmMain();
                frm.Show();
                this.Close();
;            }
        }
    }
}
