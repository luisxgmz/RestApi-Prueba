using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaApiREST.Models
{
    public class Solicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? idSolicitud { get; set; }
        public string? Descripcion { get; set; }
        public int? idUsuario { get; set; }
    }
}