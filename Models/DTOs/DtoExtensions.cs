using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;

namespace SISTEMALEGAL.Models.Extensions
{
    public static class DtoExtensions
    {
        // Mapea ComiteDto → RegistroComite
        public static RegistroComite ToEntity(this ComiteDto dto)
        {
            return new RegistroComite
            {
                Id = dto.Id,
                ComiteSalud = dto.ComiteSalud,

                // Campos de ubicación
                RegionSalud = dto.RegionSalud,
                Provincia = dto.Provincia,
                Distrito = dto.Distrito,
                Corregimiento = dto.Corregimiento,

                // Datos adicionales
                TipoTramite = dto.TipoTramite,
                FechaEleccion = dto.FechaEleccion,
                FechaCreacion = dto.FechaCreacion,
                Comunidad = dto.Comunidad,

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

        // Mapea RegistroAsociacionDto → RegistroAsociaciones
        public static RegistroAsociaciones ToEntity(this RegistroAsociacionDto dto)
        {
            return new RegistroAsociaciones
            {
                Id = dto.Id,
                Asociacion = dto.Asociacion,
                Tomo = dto.Tomo,
                Folio = dto.Folio,
                Asiento = dto.Asiento,
                ActividadSalud = dto.ActividadSalud,
                Resolucion = dto.Resolucion,
                FechaCreacion = dto.FechaCreacion,

                // Si son listas (uno a muchos)
                RepresentanteLegal = dto.RepresentanteLegal != null 
                    ? new List<RepresentanteLegal> { dto.RepresentanteLegal.ToEntity() } 
                    : new List<RepresentanteLegal>(),

                ApoderadoLegal = dto.ApoderadoLegal != null 
                    ? new List<ApoderadoLegal> { dto.ApoderadoLegal.ToEntity() } 
                    : new List<ApoderadoLegal>()
            };
        }

        public static RepresentanteLegal ToEntity(this RepresentanteLegalDto dto)
        {
            if (dto == null) return null;

            return new RepresentanteLegal
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Cargo = dto.Cargo,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };
        }

        public static ApoderadoLegal ToEntity(this ApoderadoLegalDto dto)
        {
            if (dto == null) return null;

            return new ApoderadoLegal
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Idoneidad = dto.Idoneidad,
                Email = dto.Email,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                EsFirmaAbogados = dto.EsFirmaAbogados,
                FirmaAbogadosNombre = dto.FirmaAbogadosNombre
            };
        }
        public static DocumentoAdjunto ToEntity(this DocumentoAdjuntoDto dto)
        {
            return new DocumentoAdjunto
            {
                Id = dto.Id,
                NombreOriginal = dto.NombreOriginal,
                RutaArchivo = dto.RutaArchivo,
                TipoDocumento = dto.TipoDocumento,
                FechaSubida = dto.FechaSubida,
                RegistroComiteId = dto.RegistroComiteId,
                RegistroAsociacionId = dto.RegistroAsociacionId
            };
        }
        
        public static DocumentoAdjuntoDto ToDto(this DocumentoAdjunto entity)
        {
            return new DocumentoAdjuntoDto
            {
                Id = entity.Id,
                NombreOriginal = entity.NombreOriginal,
                RutaArchivo = entity.RutaArchivo,
                TipoDocumento = entity.TipoDocumento,
                FechaSubida = entity.FechaSubida,
                RegistroComiteId = entity.RegistroComiteId,
                RegistroAsociacionId = entity.RegistroAsociacionId
            };
        }
    }
}