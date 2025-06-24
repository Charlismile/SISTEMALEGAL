using System.ComponentModel.DataAnnotations;
using SISTEMALEGAL.Components.Pages.Formularios;

namespace SISTEMALEGAL.Models.DTOs;

public class RegistroAsociacionDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre de la asociación es obligatorio.")]
    public string Asociacion { get; set; }

    public string Folio { get; set; }

    [Required(ErrorMessage = "La actividad de salud es obligatoria.")]
    public string ActividadSalud { get; set; }

    [Required(ErrorMessage = "Debe adjuntar una resolución.")]
    public string Resolucion { get; set; }

    [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
    public DateTime? FechaCreacion { get; set; }

    public string DocumentosAdjuntos { get; set; } // Nombres o rutas de documentos

    public RepresentanteLegalDto RepresentanteLegal { get; set; } = new();
    public ApoderadoLegalDto ApoderadoLegal { get; set; } = new();
}