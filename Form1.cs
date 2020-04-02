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
    public partial class Form1 : Form
    {
        UsersRepository usersRepository;
        PersronRepository persronRepository;
        public Form1(UsersRepository usersRepository, PersronRepository persronRepository)
        {
            this.usersRepository = usersRepository;

            InitializeComponent();

            dataGridView1.DataSource = usersRepository.GetUsers();
            tscbPersons.Items.AddRange(persronRepository.GetPersons().ToArray());
        }

        private void dataGridView_CellDublieClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            long userId = Convert.ToInt64(row.Cells[0].Value.ToString());

            User user = usersRepository.GetUser(userId);
            List<Person> persons = usersRepository.GetPersons();

            using (EditUserForm editUserForm = new EditUserForm(user, persons))
            {
                editUserForm.ShowDialog();

                if (editUserForm.DialogResult != DialogResult.OK) return;

                if (user.Id == 0)
                    usersRepository.AddUser(user);
                else
                    usersRepository.UpdateUser(user);

                dataGridView1.DataSource = usersRepository.GetUsers();
            }
        }

        private void OnTsbAddUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            List<Person> persons = usersRepository.GetPersons();

            using (EditUserForm userEditForm = new EditUserForm(user, persons))
            {
                userEditForm.ShowDialog();

                if (userEditForm.DialogResult != DialogResult.OK) return;

                if (user.Id == 0)
                    usersRepository.AddUser(user);
                else
                    usersRepository.UpdateUser(user);

                dataGridView1.DataSource = usersRepository.GetUsers();
            }
        }

        private void OnTscbPersons_Changed(object sender, EventArgs e)
        {
            dataGridView1.DataSource = usersRepository.GetUsers(tscbPersons.SelectedItem as Person);
        }
    }
}
