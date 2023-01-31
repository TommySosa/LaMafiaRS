using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMafiaRS.Models
{
    [Table("Tweet")]
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(280)]
        public string Text { get; set; }
        public string Username { get; set; }
        public string CreationDate { get; set; }
        //[ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
