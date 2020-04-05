using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public class PersonRepository
    {
        private TestDbContext dbContext;

        public PersonRepository(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Person> GetPersons()
        {
            return dbContext.Persons.ToList();
        }
    }
}
