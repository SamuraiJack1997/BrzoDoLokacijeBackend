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
        [ForeignKey("userId")]
        public int userId { get; set; }

        [ForeignKey("postId")]
        public int postId { get; set; }

        [Column("comment")]
        public string comment { get; set; }

        [Column("date")]
        public DateTime date { get; set; }
    }
}
