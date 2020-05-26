using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

        //mover la ventana haciendo click en la parte superior --Inicio
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //mover la ventana haciendo click en la parte superior --Fin

        //Bordes redondeados -- Inicio
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        //Bordes redondeados -- Fin
        public frmDescriptiva()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));//Ejecución del código de redondeado
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string variable = txtvariable.Text;
                //int clases = int.Parse(txtclases.Text);
                desc = new Descriptiva(datos, variable);

                if (dashboard == null)
                {
                    dashboard = new frmDashboard(datos, variable);
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
                    if (dgvDatos.Rows[i].Cells[0].Value.ToString() != null)
                    {
                        datos.Add(Double.Parse(dgvDatos.Rows[i].Cells[0].Value.ToString()));
                    }
                }
                datos.Sort();
                desc = new Descriptiva(datos, "");
                txtLi.Text = datos[0].ToString();
                txtLs.Text = datos[dgvDatos.RowCount - 2].ToString();
                txtamplitud.Text = desc.Amplitud().ToString();
                txtclases.Text = desc.Clases().ToString();
                txtanchoc.Text = desc.AnchoClase().ToString();
                txtmenor.Text = "Menor: " + datos[0].ToString();
                txtmayor.Text = "Mayor: " + datos[dgvDatos.RowCount - 2].ToString();
                txtcantidad.Text = "Cantiad: " + (dgvDatos.RowCount - 1).ToString();
                txtmedia.Text = "Media: " + Math.Round(desc.Media(), 2);
                txtmediana.Text = "Mediana: " + desc.Mediana().ToString();
                txtmoda.Text = "Moda: " + desc.Moda().ToString();
            }
            catch (Exception)
            {

            }

        }
        void CerrarForm(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }


        private void frmDescriptiva_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

