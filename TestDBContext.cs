using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() 
            : base("name=EFTestConnectionString")
        {
            Database.SetInitializer(new TestDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }

        private UsersRepository usersRepository;

       
    }
}
