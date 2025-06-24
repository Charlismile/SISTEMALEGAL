using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class ApoderadoLegal
{
    public int Id { get; set; }

    public int RegistroAsociacionId { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public bool? Idoneidad { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public bool? EsFirmaAbogados { get; set; }

    public string? FirmaAbogadosNombre { get; set; }

    // Clave foránea
    // Relación inversa
    public RegistroAsociaciones RegistroAsociaciones { get; set; }
}
