using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMafiaRS.Models
{
    [Table("Tweet")]
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }
        [MaxLength(280)]
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserId { get; set; }
        public string? Imagen1 { get; set; }
        public string? Imagen2 { get; set; }
        public string? Imagen3 { get; set; }
        public string? Imagen4 { get; set; }
        public string? Video { get; set; }

        public User? User { get; set; }

    }
}
