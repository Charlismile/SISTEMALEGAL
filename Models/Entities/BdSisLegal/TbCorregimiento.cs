﻿using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class TbCorregimiento
{
    public int CorregimientoId { get; set; }

    public string NombreCorregimiento { get; set; } = null!;

    public int DistritoId { get; set; }

    public virtual TbDistrito Distrito { get; set; } = null!;

    public virtual ICollection<TbDatosComite> TbDatosComite { get; set; } = new List<TbDatosComite>();
}
