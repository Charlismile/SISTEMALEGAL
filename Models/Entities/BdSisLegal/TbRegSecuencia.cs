using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class TbRegSecuencia
{
    public int SecuenciaId { get; set; }

    public int EntidadId { get; set; }

    public int Anio { get; set; }

    public int Numeracion { get; set; }

    public bool Activo { get; set; }
}
