
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework
{

    [Table("Person")]
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Display(Name = "Полное имя")]
        public string FullName
        {
            get
            {
                return (FirstName?.Length > 0 ? FirstName : "")
                    + (LastName?.Length > 0 ? " " + LastName.Substring(0, 1) + "." : "")
                    + (MiddleName?.Length > 0 ? " " + MiddleName.Substring(0, 1) + "." : "");
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
 