using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project
{
    public partial class frmDashboard : Form
    {
        Descriptiva desc;
        public frmDashboard(ArrayList datos, String variable, int clases)
        {
            InitializeComponent();
            desc = new Descriptiva(datos, variable, clases);
            LlenarResumen();
        }

        public void LlenarResumen()
        {
            string [] resumen = new string[] { desc.datos.Count.ToString(), desc.Media().ToString(), 
                                                desc.Mediana().ToString(),desc.Moda().ToString(),
                                                desc.datos[0].ToString(),desc.datos[desc.datos.Count-1].ToString(),
                                                desc.clases.ToString()};
            dgvresumen.Rows.Add(resumen);
        }
}
}
