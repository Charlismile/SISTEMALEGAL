using System.ComponentModel.DataAnnotations;

namespace SISTEMALEGAL.Models.DTOs;

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