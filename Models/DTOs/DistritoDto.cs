namespace SISTEMALEGAL.Models.DTOs;

public class DistritoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int ProvinciaId { get; set; }
}