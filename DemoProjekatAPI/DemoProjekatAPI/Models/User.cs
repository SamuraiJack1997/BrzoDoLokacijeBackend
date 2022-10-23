using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProjekatAPI.Models
{
    [Table("User")]
    public class User
    {
        [Column("username")]
        [MaxLength(50)]
        [Key]
        public string Username { get; set; }

        [Column("password")]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
