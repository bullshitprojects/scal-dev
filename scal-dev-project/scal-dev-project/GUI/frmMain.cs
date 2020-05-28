using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project.GUI
{
    public partial class frmMain : Form
    {
        private Form formActivo = null; 
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
        public frmMain()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));//Ejecución del código de redondeado
            manipularMenu();
        }

        private void btnDescriptiva_Click(object sender, EventArgs e)
        {
            abrirForm(new frmDescriptiva());
            esconderSubMenu();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void topPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void topPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void manipularMenu()
        {
            panelSubDescriptiva.Visible = false;
        }
        private void esconderSubMenu()
        {
            if (panelSubDescriptiva.Visible == true)
            {
                panelSubDescriptiva.Visible = false;
            }
        }
        private void mostrarSubMenu(Panel sub)
        {
            if (sub.Visible==false)
            {
                esconderSubMenu();
                sub.Visible = true;
            }
            else
            {
                sub.Visible = false;
            }
        }

        private void abrirForm(Form hijo)
        {
            if (formActivo!=null)
                formActivo.Close();
            formActivo = hijo;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            parentPanel.Controls.Add(hijo);
            parentPanel.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubDescriptiva);
        }
    }
}
