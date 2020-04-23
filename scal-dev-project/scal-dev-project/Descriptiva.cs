using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace scal_dev_project
{
    class Descriptiva
    {
        public ArrayList datos;
        public string variable;
        public int clases;

        public Descriptiva(ArrayList datos, String variable, int clases)
        {
            this.datos = datos;
            this.variable = variable;
            this.clases = clases;
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
            //Pendiente de programar
            return 0;
        }


    }
}
