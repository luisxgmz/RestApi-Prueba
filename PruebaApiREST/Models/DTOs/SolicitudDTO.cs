using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaApiREST.Models
{
    public class SolicitudDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? idSolicitud { get; set; }        
        public string? Descripcion { get; set; }
        public string? Importancia { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Status { get; set; }
    }
}