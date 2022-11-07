using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProjekatAPI.Models
{
    [Table("Post")]
    public class Post
    {
        [Column("postId")]
        [Key]
        public int postId { get; set; }

        [Column("userId")]
        [MaxLength(50)]
        [ForeignKey("userId")]
        public int UserId { get; set; }

        [Column("createdDate")]
        public DateTime CreatedDate { get; set; }

        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Column("title")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }
        
    }
}
