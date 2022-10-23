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
    [Table("Post")]
    public class Post
    {
        [Column("postId")]
        [Key]
        public int Id { get; set; }

        [Column("username")]
        [MaxLength(50)]
        [ForeignKey("username")]
        public string Username { get; set; }

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; }

        [Column("desc")]
        [MaxLength(255)]
        public string Desc { get; set; }

        [Column("title")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Column("image")]
        [MaxLength(255)]
        public string Image { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("logitude")]
        public double Longitude { get; set; }
        
    }
}
