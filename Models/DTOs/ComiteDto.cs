using System.ComponentModel.DataAnnotations;

namespace SISTEMALEGAL.Models.DTOs
{
    public class ComiteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del comité es obligatorio")]
        public string? ComiteSalud { get; set; }

        public string? RegionSalud { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
        public string? Corregimiento { get; set; }

        [Required(ErrorMessage = "El tipo de tramite es obligatorio")]
        public string? TipoTramite { get; set; }
        public DateTime? FechaEleccion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? Comunidad { get; set; }

        public List<MiembroDto> Miembros { get; set; } = new();
        public List<JuntaInterventoraDto> JuntaInterventoras { get; set; } = new();
        public List<DocumentoAdjuntoDto> DocumentosAdjuntos { get; set; } = new();

        public bool MostrarJunta => TipoTramite == "Junta Interventora";
    }
}