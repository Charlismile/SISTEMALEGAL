using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class DocumentoAdjunto
{
    public int DocumentoAdjuntoId { get; set; }

    public string NombreOriginal { get; set; } = null!;

    public string RutaArchivo { get; set; } = null!;

    public string? TipoDocumento { get; set; }

    public DateTime FechaSubida { get; set; }

    public string? UsuarioId { get; set; }

    public int? RegistroComiteId { get; set; }

    public int? RegistroAsociacionId { get; set; }

    public virtual RegistroAsociaciones? RegistroAsociacion { get; set; }

    public virtual RegistroComite? RegistroComite { get; set; }
}
