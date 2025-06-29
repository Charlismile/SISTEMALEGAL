namespace SISTEMALEGAL.Models.DTOs
{
    public class DocumentoAdjuntoDto
    {
        public int Id { get; set; }
        public string NombreOriginal { get; set; } = "";
        public string RutaArchivo { get; set; } = "";
        public string? TipoDocumento { get; set; }
        public DateTime FechaSubida { get; set; }
        public string? UsuarioId { get; set; }
        public int? RegistroComiteId { get; set; }
        public int? RegistroAsociacionId { get; set; }
    }
}