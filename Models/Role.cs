using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework
{
    [Table("Role")]

    public class Role
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
