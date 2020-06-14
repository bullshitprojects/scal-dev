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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace scal_dev_project
{
    public partial class frmDashboard : Form
    {
        Descriptiva desc;
        public frmDashboard(ArrayList datos, String variable)
        {
            InitializeComponent();
            desc = new Descriptiva(datos, variable);
        }


        public void LlenarFrecuencias()
        {
            ArrayList frecuencias = new ArrayList();
            frecuencias = desc.TablaFrecuencia();
            dgvTablafrec.DataSource = frecuencias;
        }


        public void LlenarGrafica()
        {
            ArrayList series = new ArrayList();
            ArrayList puntos = new ArrayList();
            series = desc.Series();
            puntos = desc.Puntos();
            chart1.Titles.Add("Histograma");
            for (int i = 0; i < series.Count; i++)
            {
                chart1.Series["Frecuencias"].Points.AddXY(series[i], puntos[i]);
                chart2.Series["Frecuencias"].Points.AddXY(series[i], puntos[i]);
            }


        }
        public void LlenarResumen()
        {
            dgvresumen.Rows.Add("Recuento", desc.datos.Count.ToString());
            dgvresumen.Rows.Add("Media", Math.Round(desc.Media(), 2).ToString());
            dgvresumen.Rows.Add("Mediana", desc.Mediana().ToString());
            dgvresumen.Rows.Add("Moda", desc.Moda().ToString());
            dgvresumen.Rows.Add("Menor", desc.Moda().ToString());
            dgvresumen.Rows.Add("Mayor", desc.datos[desc.datos.Count - 1].ToString());
            dgvresumen.Rows.Add("Rango", desc.Amplitud().ToString());
        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LlenarResumen();
            LlenarFrecuencias();
            LlenarGrafica();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Grafica de barras
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = @"C:\";
            save.Title = "Selecciona una ubicación";
            save.DefaultExt = "png";
            save.Filter = "Imágenes png (*.png)|*.png|All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.CheckFileExists = false;
            save.CheckPathExists = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FileName != "")
                {
                    string fs = save.FileName;
                    chart1.SaveImage(fs, ChartImageFormat.Png);
                    MessageBox.Show("Imagen guardada correctamente en: " + fs, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Grafica de pastel
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = @"C:\";
            save.Title = "Selecciona una ubicación";
            save.DefaultExt = "png";
            save.Filter = "Imágenes png (*.png)|*.png|All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.CheckFileExists = false;
            save.CheckPathExists = true;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FileName != "")
                {
                    string fs = save.FileName;
                    chart2.SaveImage(fs, ChartImageFormat.Png);
                    MessageBox.Show("Imagen guardada correctamente en: " + fs, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
