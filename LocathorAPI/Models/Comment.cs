using DemoProjekatAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocathorAPI.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Column("commentId", TypeName = "Int")]
        [Key]
        public int commentId { get; set; }
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
