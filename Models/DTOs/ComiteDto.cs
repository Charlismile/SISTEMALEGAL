using System.ComponentModel.DataAnnotations;

namespace SISTEMALEGAL.Models.DTOs
{
    public class ComiteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del comité es obligatorio.")]
        public string ComiteSalud { get; set; }

        public string Corregimiento { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string RegionSalud { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de trámite.")]
        public string TipoTramite { get; set; }

        public DateTime? FechaEleccion { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime? FechaCreacion { get; set; }

        public List<MiembroDto> Miembros { get; set; } = new();
        public List<JuntaInterventoraDto> JuntaInterventoras { get; set; } = new();
    }

    public class MiembroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Cargo { get; set; }
    }

    public class JuntaInterventoraDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
    }
}