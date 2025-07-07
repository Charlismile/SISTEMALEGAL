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
        public string? Resolucion { get; set; }

        // ✅ Estos deben ser DateTime?
        public DateTime? FechaCreacion { get; set; }

        // Si también usas FechaEleccion:
        public DateTime? FechaEleccion { get; set; }

        public RepresentanteLegalDto RepresentanteLegal { get; set; } = new();
        public ApoderadoLegalDto ApoderadoLegal { get; set; } = new();
        public List<DocumentoAdjuntoDto> DocumentosAdjuntos { get; set; } = new();
    }
}