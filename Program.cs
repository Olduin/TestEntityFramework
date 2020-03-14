using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntityFramework
{
    static class Program
    {
        /// <summary>
        /// Главная  точка входа
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyAppContext myAppContext = new MyAppContext();
            Application.Run(myAppContext);
        }
    }
}
