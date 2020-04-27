using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scal_dev_project
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUI.Splash splash = new GUI.Splash();
            splash.FormClosed += SplashClosed;
            splash.Show();
            Application.Run();
        }
        private static void SplashClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= SplashClosed;
            if (Application.OpenForms.Count==0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += SplashClosed;
            }
        }
    }
}
