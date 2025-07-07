using System;
using System.Collections.Generic;

namespace SISTEMALEGAL.Models.Entities.BdSisLegal;

public partial class RegistroComite
{
    public int RegistroComiteId { get; set; }

    public string? ComiteSalud { get; set; }

    public string? Corregimiento { get; set; }

    public string? Distrito { get; set; }

    public string? Provincia { get; set; }

    public string? RegionSalud { get; set; }

    public string? TipoTramite { get; set; }

    public string? Resolucion { get; set; }

    public DateTime FechaEleccion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Comunidad { get; set; }

    public virtual ICollection<DocumentoAdjunto> DocumentoAdjunto { get; set; } = new List<DocumentoAdjunto>();

    public virtual ICollection<JuntaInterventora> JuntaInterventora { get; set; } = new List<JuntaInterventora>();

    public virtual ICollection<MiembroComite> MiembroComite { get; set; } = new List<MiembroComite>();
}
