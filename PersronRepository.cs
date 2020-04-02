using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public class PersronRepository
    {
        private TestDbContext dbContext;

        public List<Person> GetPersons()
        {
            return dbContext.Persons.ToList();
        }
    }
}
