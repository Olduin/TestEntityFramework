using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public class TestDbInitializer : DropCreateDatabaseIfModelChanges<TestDbContext>
    {
        protected override void Seed(TestDbContext dbContext)
        {
            IList<Role> roles = new List<Role>
            {
                new Role {Name = "Библиотекарь"},
                new Role {Name = "Работник отдела кадров"}
                //new Role { Name = "Читатель" }
            };

            dbContext.Roles.AddRange(roles);

            IList<Person> person = new List<Person>
            {
                new Person { FirstName = "Ivan", LastName = "Petrov" },
                new Person { FirstName = "Petr", LastName = "Ivanov" }
            };

            dbContext.Persons.AddRange(person);

            IList<User> users = new List<User>
            {
                new User {Login = "ivan", Password = "1234", Person = person[0], Role = roles[0]},
                new User {Login = "Petr", Password = "1234", Person = person[1], Role = roles[1] }
            };  

            dbContext.Users.AddRange(users);
            
            dbContext.SaveChanges();
        }
    }
}
