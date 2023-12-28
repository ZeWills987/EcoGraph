using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoGraph
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Accueil ac = new Accueil();
            //ac.ShowDialog();
            //string firstData = ac.GetData();
            //if(firstData!=null)
            //{
            //    Application.Run(new EcoGraph(firstData));
            //}
            Application.Run(new EcoGraph());
        }
    }
}
