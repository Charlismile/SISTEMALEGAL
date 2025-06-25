using System.ComponentModel.DataAnnotations;
using SISTEMALEGAL.Components.Pages.Formularios;

namespace SISTEMALEGAL.Models.DTOs
{
    public class RegistroAsociacionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la asociación es obligatorio.")]
        public string Asociacion { get; set; }

        public int? Tomo { get; set; }
        public int? Folio { get; set; }
        public int? Asiento { get; set; }

        [Required(ErrorMessage = "La actividad de salud es obligatoria.")]
        public string ActividadSalud { get; set; }

        [Required(ErrorMessage = "Debe adjuntar una resolución.")]
        public string Resolucion { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime? FechaCreacion { get; set; }

        public List<string> DocumentosAdjuntos { get; set; } = new();

        public RepresentanteLegalDto RepresentanteLegal { get; set; } = new();
        public ApoderadoLegalDto ApoderadoLegal { get; set; } = new();
    }
    
    public class ApoderadoLegalDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string Cedula { get; set; }

        public bool Idoneidad { get; set; } // true si está validada
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public bool EsFirmaAbogados { get; set; }
        public string FirmaAbogadosNombre { get; set; } // Si pertenece a una firma
    }
    
    public class RepresentanteLegalDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public string Cargo { get; set; }

        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}