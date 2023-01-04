using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMafiaRS.Models
{
    [Table("Like")]
    public class Like
    {
        [Key]
        [Column("LikeId")]
        public int LikeId { get; set; }
        [Column("TweetId")]
        public int TweetId { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        public User User { get; set; }
    }
}
