using System.ComponentModel.DataAnnotations;

namespace SISTEMALEGAL.Models.DTOs
{
    public class DocumentoAdjuntoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un archivo")]
        public string NombreOriginal { get; set; } = string.Empty;

        [Required]
        public string RutaArchivo { get; set; } = string.Empty;

        public string? TipoDocumento { get; set; }
        public DateTime FechaSubida { get; set; } = DateTime.Now;
        public string? UsuarioId { get; set; }

        public int? RegistroComiteId { get; set; }
        public int? RegistroAsociacionId { get; set; }
    }
}