using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;

namespace SISTEMALEGAL.Models.Extensions
{
    public static class DtoExtensions
    {
        public static RegistroComite ToEntity(this ComiteDto dto)
        {
            return new RegistroComite
            {
                Id = dto.Id,
                ComiteSalud = dto.ComiteSalud,
                Corregimiento = dto.Corregimiento,
                Distrito = dto.Distrito,
                Provincia = dto.Provincia,
                RegionSalud = dto.RegionSalud,
                TipoTramite = dto.TipoTramite,
                FechaEleccion = dto.FechaEleccion,
                FechaCreacion = dto.FechaCreacion,

                MiembroComite = dto.Miembros?
                    .Select(m => m.ToEntity())
                    .ToList() ?? new List<MiembroComite>(),

                JuntaInterventora = dto.JuntaInterventoras?
                    .Select(j => j.ToEntity())
                    .ToList() ?? new List<JuntaInterventora>()
            };
        }

        public static MiembroComite ToEntity(this MiembroDto dto)
        {
            return new MiembroComite
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Cargo = dto.Cargo
            };
        }

        public static JuntaInterventora ToEntity(this JuntaInterventoraDto dto)
        {
            return new JuntaInterventora
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Cedula = dto.Cedula
            };
        }
    }
}