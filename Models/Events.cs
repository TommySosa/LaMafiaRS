
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMafiaRS.Models
{
    [Table("Events")]
    public class Events
    {
        [Key]
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaYHora { get; set; }
        public DateTime Finalizacion { get; set; }
    }
}
