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

        private EditUserContext editUserContext;

        public EditUserForm(EditUserContext editUserContext)
        {
            this.editUserContext = editUserContext;
            InitializeComponent();

            tbId.DataBindings.Add("Text", editUserContext.User, "Id");
            tbLogin.DataBindings.Add("Text", editUserContext.User, "Login");
            tbPassword.DataBindings.Add("Text", editUserContext.User, "Password");

            cbPersons.DisplayMember = "FullName";
            cbPersons.ValueMember = "Id";
            cbPersons.DataSource = editUserContext.Persons;

            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "Id";
            cbRole.DataSource = editUserContext.Roles;

            if (editUserContext.User?.Person != null)
            {
                var currentPerson = editUserContext.Persons.FirstOrDefault(p => p == editUserContext.User.Person);

                if (currentPerson != null) 
                    cbPersons.SelectedItem = currentPerson;
            }

            cbPersons.SelectedIndexChanged += OnPersonChanged;

            if (editUserContext.User?.Role != null)
            {
                var currentRole = editUserContext.Roles.FirstOrDefault(r => r == editUserContext.User.Role);

                if (currentRole != null)
                    cbRole.SelectedItem = currentRole;
            }

            cbRole.SelectedIndexChanged += OnRoleChanged;
        }

        private void OnPersonChanged(object sender, EventArgs e)
        {
            Person person = cbPersons.SelectedItem as Person;

            if (editUserContext.User.Person == person) return;

            editUserContext.User.Person = person;
        }

        private void OnRoleChanged(object sender, EventArgs e)
        {
            Role role = cbRole.SelectedItem as Role;

            if (editUserContext.User.Role == role) return;

            editUserContext.User.Role = role;
        }
                    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
