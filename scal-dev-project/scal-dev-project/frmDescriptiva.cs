using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project
{
    public partial class frmDescriptiva : Form
    {
        ArrayList datos;
        Descriptiva desc;
        private frmDashboard dashboard;

        public frmDescriptiva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string variable = txtvariable.Text;
                int clases = int.Parse(txtclases.Text);
                desc = new Descriptiva(datos,variable,clases);

                if (dashboard == null)
                {
                    dashboard = new frmDashboard(datos, variable, clases);
                    dashboard.FormClosed += new FormClosedEventHandler(CerrarForm);
                    dashboard.Show();
                }
                else
                {
                    dashboard.Activate();
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                datos = new ArrayList();
                for (int i = 0; i < dgvDatos.RowCount - 1; i++)
                {
                    datos.Add(Double.Parse(dgvDatos.Rows[i].Cells[0].Value.ToString()));
                }
                datos.Sort();
                desc = new Descriptiva(datos, "", 0);
                txtLi.Text = datos[0].ToString();
                txtLs.Text = datos[dgvDatos.RowCount - 2].ToString();
                txtmenor.Text = "Menor: " + datos[0].ToString();
                txtmayor.Text = "Mayor: " + datos[dgvDatos.RowCount - 2].ToString();
                txtcantidad.Text = "Cantiad: " + (dgvDatos.RowCount - 2).ToString();
                txtmedia.Text = "Media: " + Math.Round(desc.Media(),2);
                txtmediana.Text = "Mediana: " + desc.Mediana().ToString();
            }
            catch (Exception)
            {

            }

        }
        void CerrarForm(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }


    }
}

