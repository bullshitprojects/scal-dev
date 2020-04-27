using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project
{
   
    public partial class MDIStatisticalSoftware : Form
    {
        private frmDescriptiva descriptiva;

        public MDIStatisticalSoftware()
        {
            InitializeComponent();
        }

        private void analizarUnaVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (descriptiva == null)
            {
                descriptiva = new frmDescriptiva();
                descriptiva.MdiParent = this;
                descriptiva.FormClosed += new FormClosedEventHandler(CerrarForm);
                descriptiva.Show();
            }
            else
            {
                descriptiva.Activate();
            }
        }

        void CerrarForm(object sender, FormClosedEventArgs e)
        {
            descriptiva = null;
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dashboard == null)
            //{
            //    dashboard = new frmDashboard();
            //    dashboard.MdiParent = this;
            //    dashboard.FormClosed += new FormClosedEventHandler(CerrarForm);
            //    dashboard.Show();
            //}
            //else
            //{
            //    dashboard.Activate();
            //}
        }

        private void MDIStatisticalSoftware_Load(object sender, EventArgs e)
        {

        }
    }
}

