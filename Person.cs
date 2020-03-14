using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework
{
    
    [Table("Persons")]

    public class Person
    {
        [Key]
       public long PersonId { get; set; }
        [MaxLength(50)]
       public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
       public string MiddleName { get; set; }
        //public virtual Position Position { get; set; }
    }
}
 