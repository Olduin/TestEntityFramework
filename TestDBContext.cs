using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFramework;
using System.Data.Entity;

namespace TestEntityFramework
{
    public class TestDBContext : DbContext
    {
        public TestDBContext()
            : base("Server=localHost\\SQLEXPRESS;Integrated Security=True;Initial Catalog=EFTest")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }

        //public DbSet<Genre> Genres { get; set; }

        //public DbSet<Author> Authors { get; set; }


        public void Seed()
        {
            List<Person> persons = new List<Person>
            {
                new Person{FirstName = "Vasia", LastName = "Vasilev", MiddleName= "Asda" },
                 new Person{FirstName = "Егор", LastName = "Васе", MiddleName= "Сергеевич" }
            };

            this.Persons.AddRange(persons);

            List<User> users = new List<User>
            {
                new User{Login = "Login", Password = "Password", Person = persons[0]}
            };
            this.Users.AddRange(users);

            //List<Author> authors = new List<Author>
            //{
            //    new Author{NickName="Озорной",Person = persons[1]},
            //    new Author{ NickName = "Роман",Person = persons[0]}
            //};

            //dBContext.Authors.AddRange(Authors);

            //List<Genre> genres = new List<Genre>
            //{
            //    new Genre{GenreName="Детектив"},
            //    new Genre { GenreName = "Роман" }
            //};

            //dBContext.Genres.AddRange(genres);


            this.SaveChanges();

        }
    }
}
