using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PruebaApiREST.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? idUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Password { get; set; }
        public DateTime FNac { get; set; }
        public string? Email { get; set; }
        public string? Ubicacion { get; set; }

    }
}