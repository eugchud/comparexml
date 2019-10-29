using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace CompareCFGs
{
    public class Global
    {
        public static DataTable dataTable1 = new DataTable();
        public static DataTable dataTable2 = new DataTable();
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
