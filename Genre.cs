﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityFramework
{
    [Table("Genres")]

    public class Genre
    {
        [Key]
        public long GenreId { get; set; }
        [MaxLength(50)]
        public string GenreName { get; set; }
    }
}
