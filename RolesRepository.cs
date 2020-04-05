using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFramework.Models;

namespace TestEntityFramework
{
    public class RolesRepository
    {
        private TestDbContext dbContext;

        public RolesRepository(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Role> GetRoles()
        {
            return dbContext.Roles.ToList();
        }
    }
}
