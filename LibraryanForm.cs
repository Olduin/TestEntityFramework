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
    public partial class LibraryanForm : Form
    {
        private RunContext runContext;

        public LibraryanForm(RunContext runContext )
        {
            this.runContext = runContext;

            InitializeComponent();

            dataGridView1.DataSource = runContext.UsersRepository.GetUsers();
            tscbRole.Items.AddRange(runContext.RolesRepository.GetRoles().ToArray());
        }

        private void dataGridView_CellDublieClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            long userId = Convert.ToInt64(row.Cells[0].Value.ToString());

            User user = runContext.UsersRepository.GetUser(userId);

            OpenEditUserDialog(user);
                       
        }

        private void OnTsbAddUser_Click(object sender, EventArgs e)
        {
            User user = new User();

            OpenEditUserDialog(user);
        }

        private void OnTscbRole_Changed(object sender, EventArgs e)
        {
            dataGridView1.DataSource = runContext.UsersRepository.GetUsers(tscbRole.SelectedItem as Role);
        }

        private void OpenEditUserDialog(User user)
        {
            EditUserContext editUserContext = new EditUserContext
            {
                User = user,
                Persons = runContext.PersonRepository.GetPersons(),
                Roles = runContext.RolesRepository.GetRoles()
            };

            using (EditUserForm editUserForm = new EditUserForm(editUserContext))
            {
                editUserForm.ShowDialog();

                if (editUserForm.DialogResult != DialogResult.OK) return;

                if (editUserContext.User.Id == 0)
                    runContext.UsersRepository.AddUser(editUserContext.User);
                else
                    runContext.UsersRepository.UpdateUser(editUserContext.User);

                dataGridView1.DataSource = runContext.UsersRepository.GetUsers();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PersonFormContext personFormContext = new PersonFormContext
            {
                Persons = runContext.PersonRepository.GetPersons()
            };

            using (PersonForm personForm = new PersonForm(personFormContext)) 
            {
                personForm.ShowDialog();
            }
        }
    }
}
