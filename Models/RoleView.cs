using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestEntityFramework.Models
{
    class RoleView
    {
        public long Id { get; set; }
        [DisplayName("Должность")]
        public string Name { get; set; }
    }
}
