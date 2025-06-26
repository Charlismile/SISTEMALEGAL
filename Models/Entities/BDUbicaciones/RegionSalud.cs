using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BDUbicaciones;

public partial class RegionSalud
{
    public int Id { get; set; }

    public int CodigoRegion { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}
