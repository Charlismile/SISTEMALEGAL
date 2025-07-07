using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class MiembroComite
{
    public int MiembroComiteId { get; set; }

    public int RegistroComiteId { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public string? Cargo { get; set; }

    public virtual RegistroComite RegistroComite { get; set; } = null!;
}
