using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.ConectionUtils;
using System.Data;
using PalcoNet.Dao;
using PalcoNet.Model;

namespace PalcoNet
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseConection.initDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnExit);
            Application.Run(new Form1());

            
        }

        static void OnExit(object sender, EventArgs e) {
            DatabaseConection.closeDatabase();
        }
    }
}
