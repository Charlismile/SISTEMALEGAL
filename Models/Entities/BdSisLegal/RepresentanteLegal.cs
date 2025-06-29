using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class RepresentanteLegal
{
    public int RepresentanteLegalId { get; set; }

    public int RegistroAsociacionId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string? Cargo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual RegistroAsociaciones RegistroAsociacion { get; set; } = null!;
}
