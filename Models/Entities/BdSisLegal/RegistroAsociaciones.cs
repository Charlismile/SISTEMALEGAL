using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class RegistroAsociaciones
{
    public int Id { get; set; }

    public string? Asociacion { get; set; }

    public string? Folio { get; set; }

    public string? ActividadSalud { get; set; }

    public string? Resolucion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? DocumentosAdjuntos { get; set; }

    public virtual ICollection<ApoderadoLegal> ApoderadoLegal { get; set; }
    public virtual ICollection<RepresentanteLegal> RepresentanteLegal { get; set; }
}
