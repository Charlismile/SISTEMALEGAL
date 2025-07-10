using System.ComponentModel.DataAnnotations;

public class RegistroComiteDTO
{
    [Required(ErrorMessage = "El nombre del comité es obligatorio")]
    public string NombreComiteSalud { get; set; }

    public string Comunidad { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una región válida")]
    public int RegionSaludId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una provincia válida")]
    public int ProvinciaId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un distrito válido")]
    public int DistritoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un corregimiento válido")]
    public int CorregimientoId { get; set; }

    public List<MiembroComiteDTO> Miembros { get; set; } = new();
}

public class MiembroComiteDTO
{
    [Required]
    public string NombreMiembro { get; set; }

    [Required]
    [RegularExpression(@"^\d{3}-\d{4}-\d{5}$", ErrorMessage = "Formato inválido (000-0000-00000)")]
    public string CedulaMiembro { get; set; }

    [Range(1, int.MaxValue)]
    public int CargoId { get; set; }
}