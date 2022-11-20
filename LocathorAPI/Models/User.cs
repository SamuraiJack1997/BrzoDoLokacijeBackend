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
        [Column("userId")]
        [Key]
        public int UserId { get; set; }

        [Column("username")]
        [MaxLength(255)]
        public string Username { get; set; }

        [Column("email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("surname")]
        [MaxLength(255)]
        public string Surname { get; set; }

        [Column("profilePicId")]
        [MaxLength(255)]
        public string ProfilePicId { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [Column("password")]
        [MaxLength(255)]
        public byte[] Hash { get; set; }
    }
}
