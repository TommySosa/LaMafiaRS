using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMafiaRS.Models
{
    [Table("User")]
    public class User
    {

        //[Column("User")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]


        public int UserId { get; set; }
        public byte[] PASS { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        [RegularExpression(@"^(?=.{3,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "El nombre de usuario no es válido.")]
        public string Username { get; set; }
        public string Tipo { get; set; }


        public ICollection<Tweet> Tweet { get; set; }

    }
}
