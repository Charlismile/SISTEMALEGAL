﻿using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class TbDatosComite
{
    public int DcomiteId { get; set; }

    public string NombreComiteSalud { get; set; } = null!;

    public string? Comunidad { get; set; }

    public int RegionSaludId { get; set; }

    public int ProvinciaId { get; set; }

    public int DistritoId { get; set; }

    public int CorregimientoId { get; set; }

    public int MiembroId { get; set; }

    public virtual TbCorregimiento Corregimiento { get; set; } = null!;

    public virtual TbDistrito Distrito { get; set; } = null!;

    public virtual TbDatosMiembros Miembro { get; set; } = null!;

    public virtual TbProvincia Provincia { get; set; } = null!;

    public virtual TbRegionSalud RegionSalud { get; set; } = null!;
}
