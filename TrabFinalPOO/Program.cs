using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabFinalPOO
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            TrabFinalPOO.Source.File.read("C:\\Users\\major\\source\\repos\\TrabFinalPOO\\TrabFinalPOO\\BD\\endereco.txt");

        }
    }
}
