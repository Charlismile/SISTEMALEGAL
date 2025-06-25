namespace SISTEMALEGAL.Models.DTOs;

public class DocumentoAdjuntoDto
{
    public int Id { get; set; }
    public string NombreOriginal { get; set; } = string.Empty;
    public string RutaArchivo { get; set; } = string.Empty;
    public string? TipoDocumento { get; set; }
    public DateTime FechaSubida { get; set; }
    public string? UsuarioId { get; set; }

    // Opcional: Solo uno puede estar presente
    public int? RegistroComiteId { get; set; }
    public int? RegistroAsociacionId { get; set; }
}