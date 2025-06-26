namespace SISTEMALEGAL.Models.DTOs;

public class UbicacionDto
{
    public string? RegionSalud { get; set; }
    public string? Provincia { get; set; }
    public string? Distrito { get; set; }
    public string? Corregimiento { get; set; }

    // IDs (opcional si necesitas validar relaciones)
    public int RegionSaludId { get; set; }
    public int ProvinciaId { get; set; }
    public int DistritoId { get; set; }
    public int CorregimientoId { get; set; }
}