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
        
        public string? TipoTramite { get; set; }
        public DateTime? FechaEleccion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? Comunidad { get; set; }

        public List<DocumentoAdjuntoDto> DocumentosAdjuntos { get; set; } = new();
        public List<MiembroDto> Miembros { get; set; } = new();
        public List<JuntaInterventoraDto> JuntaInterventoras { get; set; } = new();

        public bool MostrarJunta => TipoTramite == "Junta Interventora";
    }
    public class MiembroDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "La cédula es obligatoria")]
        public string Cedula { get; set; } = "";

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = "";
    }

    public class JuntaInterventoraDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
    }
}