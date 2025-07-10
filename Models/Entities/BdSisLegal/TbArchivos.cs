﻿using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class TbArchivos
{
    public int ArchivoId { get; set; }

    public int? DetRegAsociacionId { get; set; }

    public int? DetRegComiteId { get; set; }

    public string Categoria { get; set; } = null!;

    public string NombreOriginal { get; set; } = null!;

    public string NombreArchivoGuardado { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime FechaSubida { get; set; }

    public int Version { get; set; }

    public bool IsActivo { get; set; }

    public virtual TbDetalleRegAsociacion? DetRegAsociacion { get; set; }

    public virtual TbDetalleRegComite? DetRegComite { get; set; }
}
