using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntityFramework
{
    public class MyAppContext : ApplicationContext
    {
        TestDBContext testDB;

        Form form;

        public MyAppContext()
        {
            testDB = new TestDBContext();
            //testDB.Seed();
            //form = new Form1(this);
            form = new UserForm( GetUser(1));
            form.FormClosed += OnFormClosed;
            //form.Show();
            form.ShowDialog();
        }

        public List<User> GetUsers()
        {
            return testDB.Users.ToList();
        }

        public User GetUser(string login) 
        {
            return testDB.Users.FirstOrDefault(u => u.Login == login);
        }

        public User GetUser(long id)
        {
            return testDB.Users.FirstOrDefault(u => u.Id == id);
        }

        private void OnFormClosed(object sender, EventArgs e)
        { 
            ExitThread();
        }
    }
}
