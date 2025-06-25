using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class RegistroAsociaciones
{
    public int Id { get; set; }

    public string? Asociacion { get; set; }

    public string? ActividadSalud { get; set; }

    public string? Resolucion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? DocumentosAdjuntos { get; set; }

    public int? Tomo { get; set; }

    public int? Folio { get; set; }

    public int? Asiento { get; set; }

    public virtual ICollection<ApoderadoLegal> ApoderadoLegal { get; set; } = new List<ApoderadoLegal>();

    public virtual ICollection<DocumentoAdjunto> DocumentoAdjunto { get; set; } = new List<DocumentoAdjunto>();

    public virtual ICollection<RepresentanteLegal> RepresentanteLegal { get; set; } = new List<RepresentanteLegal>();
}
