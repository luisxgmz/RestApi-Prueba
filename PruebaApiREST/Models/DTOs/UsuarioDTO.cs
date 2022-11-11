using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PruebaApiREST.Models
{
    public class UsuarioDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? idUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
    }
}