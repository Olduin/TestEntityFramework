using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntityFramework
{
    public partial class UserForm : Form
    {

        //private MyAppContext myAppContext;

        private User user;

        public UserForm( User user)
        {
            //this.myAppContext = myAppContext;
            this.user = user;
            InitializeComponent();
        }
    }
}
