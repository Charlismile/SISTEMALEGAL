using System.ComponentModel.DataAnnotations;

namespace SISTEMALEGAL.Models.DTOs
{
    public class RegistroAsociacionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la asociación es obligatorio")]
        public string? Asociacion { get; set; }

        public int? Tomo { get; set; }
        public int? Folio { get; set; }
        public int? Asiento { get; set; }

        public string? ActividadSalud { get; set; }
        
        [Required(ErrorMessage = "El número de resolucion es obligatorio")]
        public string? Resolucion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        // Propiedades de ubicación
        public int? RegionSaludId { get; set; }
        public string? RegionSalud { get; set; }
        public int? ProvinciaId { get; set; }
        public string? Provincia { get; set; }
        public int? DistritoId { get; set; }
        public string? Distrito { get; set; }
        public int? CorregimientoId { get; set; }
        public string? Corregimiento { get; set; }

        // Relaciones uno a muchos
        public RepresentanteLegalDto? RepresentanteLegal { get; set; }
        public ApoderadoLegalDto? ApoderadoLegal { get; set; }

        // Listas (por si decides tener más de uno)
        public List<DocumentoAdjuntoDto> DocumentosAdjuntos { get; set; } = new();
    }
}