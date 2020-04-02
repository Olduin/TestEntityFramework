using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestEntityFramework.Models
{
    public class UserView
    {
        public long Id { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Личность")]
        public string PersonName { get; set; }
    }
}
