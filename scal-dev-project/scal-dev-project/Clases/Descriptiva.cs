using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project
{
    class Descriptiva
    {    
        public string variable;
        public int clases;
        public int anchoclase;
        public double amplitud;
        public double vmax;
        public double vmin;
        public ArrayList datos;
        ArrayList frecuencias;


        public Descriptiva(ArrayList datos, String variable)
        {
            this.datos = datos;
            this.variable = variable;
            vmin = double.Parse(datos[0].ToString());
            vmax = double.Parse(datos[datos.Count - 1].ToString());
        }

        public double Media()
        {
            double total = 0;
            double media = 0;
            for (int i = 0; i < datos.Count; i++)
            {
                total += double.Parse(datos[i].ToString());
            }
            media = total / datos.Count;
            return media;
        }

        public double Mediana()
        {
            double mediana;
            if (datos.Count % 2 == 0)
            {
                int valor = (datos.Count - 1) / 2;
                mediana = (double.Parse(datos[valor].ToString()) + double.Parse(datos[valor + 1].ToString())) / 2;
                return mediana;
            }
            else
            {
                mediana = double.Parse(datos[datos.Count / 2].ToString());
                return mediana;
            }
        }

        public double Moda()
        {
            double n, val=0, rep=0;
            for (int i = 0; i < datos.Count; i++)
            {
                n = Convert.ToDouble(datos[i]);
                if (rep<contar(n))
                {
                    rep = contar(n);
                    val = Convert.ToDouble(datos[i]);
                }
            }
            return val;
        }
        private int contar(double num)
        {
            int x = 0;
            for (int i = 0; i < datos.Count; i++)
            {
                if (num==Convert.ToDouble(datos[i]))
                {
                    x++;
                }
            }
            return x;
        }

        public double Amplitud()
        {
            amplitud = vmax - vmin;
            return amplitud;
        }
        public int AnchoClase()
        {
            clases = Convert.ToInt32(Math.Ceiling(1 + (3.322 * Math.Log10(datos.Count))));
            anchoclase = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(Amplitud())/ clases));
            return anchoclase;
        }
        public int Clases()
        {
            clases = Convert.ToInt32(Math.Ceiling(1 + (3.322 * Math.Log10(datos.Count))));
            return clases;
        }

        public ArrayList TablaFrecuencia() {
            frecuencias = new ArrayList();
            int fabs=0,frec;
            double vinicial = vmin;
            int aclase = AnchoClase();
            for (int i = 0; i < clases; i++)
            {
                double vfinal = vmin+ aclase;               
                Frecuencias filaFrecuencia = new Frecuencias();
                filaFrecuencia.clase = i + 1;
                filaFrecuencia.Linferior = vinicial;
                filaFrecuencia.lsuperior = vfinal;
                filaFrecuencia.marcaClase = (vfinal + vinicial) / 2;
                frec = Frecuencia(vfinal, vinicial);
                filaFrecuencia.frecuencia = (frec);
                filaFrecuencia.frecueciaAbs = fabs + frec;
                filaFrecuencia.frecuenciare = Math.Round((Convert.ToDouble(frec) / Convert.ToDouble(datos.Count)), 3);
                filaFrecuencia.frecueciapor = Math.Round(((Convert.ToDouble(frec) / Convert.ToDouble(datos.Count))*100), 3);
                frecuencias.Add(filaFrecuencia);
                fabs += frec;
                vmin += aclase;
                vinicial += aclase;
            }
            return frecuencias;
        }
        public int Frecuencia(double vf, double vi) {
            int frec=0;
            for (int i = 0; i < datos.Count; i++)
            {             
                if (double.Parse(datos[i].ToString()) >= vi & double.Parse(datos[i].ToString()) <vf)
                {
                    frec += 1;
                }
            }
            return frec;
        }
        public ArrayList Series() {
            frecuencias = new ArrayList();
            vmin = double.Parse(datos[0].ToString());
            vmax = double.Parse(datos[datos.Count - 1].ToString());
            double vinicial = vmin;
            int aclase =  AnchoClase();
            for (int i = 0; i < clases; i++)
            {
                double vfinal = vmin + aclase;
                string serie = vinicial + " < "+ vfinal;
                frecuencias.Add(serie);
                vmin += aclase;
                vinicial += aclase;
            }
            return frecuencias;
        }
        public ArrayList Puntos()
        {
            frecuencias = new ArrayList();
            vmin = double.Parse(datos[0].ToString());
            vmax = double.Parse(datos[datos.Count - 1].ToString());
            double vinicial = vmin;
            int aclase = AnchoClase();
            for (int i = 0; i < clases; i++)
            {
                double vfinal = vmin + aclase;
                Frecuencias filaFrecuencia = new Frecuencias();
                frecuencias.Add(Frecuencia(vfinal, vinicial));
                vmin += aclase;
                vinicial += aclase;
            }
            return frecuencias;
        }
    }

}
