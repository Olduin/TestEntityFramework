using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestEntityFramework
{
    public class RunContext : ApplicationContext
    {
        public User CurrentUser { get; private set; }

        public UsersRepository UsersRepository { get; private set; }

        public RolesRepository RolesRepository { get; private set; }

        public PersonRepository PersonRepository { get; private set; }

        private Form form;

        public RunContext(TestDbContext dbContext)
        {
            UsersRepository = new UsersRepository(dbContext);

            RolesRepository = new RolesRepository(dbContext);

            PersonRepository = new PersonRepository(dbContext);

            //заглушка для отладки
#if DEBUG
           // CurrentUser = UsersRepository.GetUser("Petr");
#endif
            SwitchContext();
        }

        public void Authorization(AuthInformationDTO authInfo)
        {
            User user = UsersRepository.GetUser(authInfo.Login);

            if (user != null && user.Password == authInfo.Password)
            {
                this.CurrentUser = user;
                SwitchContext();
            }
        }

       
        private void SwitchContext()
        {
            if (CurrentUser == null) 
            {
                form = new AutorizationForm(this);

                form.FormClosed += OnFormClosed;

                form.Show();

                return; 
            }

            if (form != null)
            {
                form.FormClosed -= OnFormClosed;
                form.Close();
            }
            

            switch (CurrentUser.Role.Name)
            { 
                case "Работник отдела кадров":
                    form = new Form1(this);
                    form.FormClosed += OnFormClosed;
                    form.Show();
                    break;
                default:
                    ExitThread();
                    break;
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            ExitThread();
        }
    }
}
