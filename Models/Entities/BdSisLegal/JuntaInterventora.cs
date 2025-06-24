using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class JuntaInterventora
{
    public int Id { get; set; }

    public int RegistroComiteId { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public virtual RegistroComite RegistroComite { get; set; } = null!;
}
