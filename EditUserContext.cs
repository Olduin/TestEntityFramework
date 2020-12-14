using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestEntityFramework
{
    public class EditUserContext
    {
        public User User { get; set; }

        public List<Person> Persons { get; set; }

        public List<Role> Roles { get; set; }

    }
}
