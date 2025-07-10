using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class TbTipoTramite
{
    public int TramiteId { get; set; }

    public string NombreTramite { get; set; } = null!;

    public bool IsActivo { get; set; }

    public virtual ICollection<TbDetalleRegComite> TbDetalleRegComite { get; set; } = new List<TbDetalleRegComite>();
}
