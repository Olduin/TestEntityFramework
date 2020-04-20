using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestEntityFramework.Models;

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
            TestDbContext dbContext = new TestDbContext();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new RunContext(dbContext));

        }
    }
}
