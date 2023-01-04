using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMafiaRS.Models
{
    [Table("Tweet")]
    public class Tweet
    {
        [Key]
        [Column("TweetId")]
        public int TweetId { get; set; }
        [Column("Text")]
        [MaxLength(280)]
        public string Text { get; set; }
        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("RetweetId")]
        public int RetweetId { get; set; }
        [Column("Imagen1")]
        public string Imagen1 { get; set; }
        [Column("Imagen1")]
        public string Imagen2 { get; set; }
        [Column("Imagen1")]
        public string Imagen3 { get; set; }
        [Column("Imagen1")]
        public string Imagen4 { get; set; }
        [Column("Video")]
        public string Video { get; set; }

        public User User { get; set; }

    }
}
