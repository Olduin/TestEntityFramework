using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public partial class EditUserForm : Form
    {
        User user;

        public EditUserForm(User user, List<Person> persons)
        {
            this.user = user;
            InitializeComponent();

            tbId.DataBindings.Add("Text", user, "Id");
            tbLogin.DataBindings.Add("Text", user, "Login");
            tbPassword.DataBindings.Add("Text", user, "Password");

            cbPersons.DisplayMember = "FullName";
            cbPersons.ValueMember = "Id";
            cbPersons.DataSource = persons;

            if (user?.Person != null)
            {
                var currentPerson = persons.FirstOrDefault(p => p == user.Person);

                if (currentPerson != null)
                    cbPersons.SelectedItem = currentPerson;
            }

            cbPersons.SelectedIndexChanged += OnPersonChanged;
        }

        private void OnPersonChanged(object sender, EventArgs e)
        {
            Person person = cbPersons.SelectedItem as Person;

            if (user.Person == person) return;

            user.Person = person;
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}