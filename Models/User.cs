
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Index("IX_User_login", IsUnique = true)]
        [MaxLength(100)]
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [MaxLength(100)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Личность")]
        public virtual Person Person { get; set; }
    }

}
