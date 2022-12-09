using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProjekatAPI.Models
{
    [Table("likes")]
    public class Like
    {
        public int userId { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        public int postId { get; set; }

        [ForeignKey("postId")]
        public Post post { get; set; }

        [Column("date")]
        public DateTime date { get; set; }
    }
}
