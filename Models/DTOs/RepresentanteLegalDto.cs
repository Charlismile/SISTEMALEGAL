using System.ComponentModel.DataAnnotations;

namespace SISTEMALEGAL.Models.DTOs;

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