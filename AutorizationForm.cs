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
    public partial class AutorizationForm : Form
    {
        private RunContext runContext;

        public AutorizationForm(RunContext runContext)
        {
            this.runContext = runContext;
            InitializeComponent();
        }

        private void btnAuhorization_Click(object sender, EventArgs e)
        {
            AuthInformationDTO authInformation = new AuthInformationDTO();
            authInformation.Login = tbLogin.Text;
            authInformation.Password = tbPassword.Text;

            runContext.Authorization(authInformation);
               
        }
    }
}