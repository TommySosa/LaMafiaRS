using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaMafiaRS.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        //[Column("User")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        //[Column("PASS")]
        public byte[] PASS { get; set; }
        //[Column("EMAIL")]
        public string Email { get; set; }
        //[Column("SALT")]
        public string Salt { get; set; }
        //[Column("Username")]
        public string Username { get; set; }
        //[Column("Tipo")]
        public string Tipo { get; set; }
        //[Column("CreationDate")]
        //public DateTime CreationDate { get; set; }

        public ICollection<Tweet> Tweet { get; set; }

    }
}
