using Clinica_01.Forms;
using Data.SQLiteORM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica_01
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var empresa = EmpresaRepositorySQLite.GetAll();
            if((empresa == null) || empresa != null && empresa.Count == 0)
                Application.Run(new FormConfig());
            else
                Application.Run(new Form1());
        }
    }
}
