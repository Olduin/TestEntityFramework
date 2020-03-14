using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestEntityFramework
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public long AuthorId { get; set; }
        public virtual Person Person { get; set; }
        [MaxLength(50)]
        public string NickName { get; set; }
    }
}
