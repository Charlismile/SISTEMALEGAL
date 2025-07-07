using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;

namespace SISTEMALEGAL.Models.Extensions
{
    public static class DtoExtensions
    {
        // ComiteDto -> RegistroComite
        public static RegistroComite ToEntity(this ComiteDto dto)
        {
            return new RegistroComite
            {
                RegistroComiteId = dto.Id,
                ComiteSalud = dto.ComiteSalud,
                RegionSalud = dto.RegionSalud,
                Provincia = dto.Provincia,
                Distrito = dto.Distrito,
                Corregimiento = dto.Corregimiento,
                TipoTramite = dto.TipoTramite,
                FechaEleccion = dto.FechaEleccion,
                FechaCreacion = dto.FechaCreacion,
                Comunidad = dto.Comunidad,

                MiembroComite = dto.Miembros.Select(m => m.ToEntity()).ToList(),
                JuntaInterventora = dto.JuntaInterventoras.Select(j => j.ToEntity()).ToList(),
                DocumentoAdjunto = dto.DocumentosAdjuntos.Select(d => d.ToEntity()).ToList()
            };
        }

        public static ComiteDto ToDto(this RegistroComite entity)
        {
            return new ComiteDto
            {
                Id = entity.RegistroComiteId,
                ComiteSalud = entity.ComiteSalud,
                RegionSalud = entity.RegionSalud,
                Provincia = entity.Provincia,
                Distrito = entity.Distrito,
                Corregimiento = entity.Corregimiento,
                TipoTramite = entity.TipoTramite,
                FechaEleccion = entity.FechaEleccion,
                FechaCreacion = entity.FechaCreacion,
                Comunidad = entity.Comunidad,

                Miembros = entity.MiembroComite?.Select(m => m.ToDto()).ToList() ?? new(),
                JuntaInterventoras = entity.JuntaInterventora?.Select(j => j.ToDto()).ToList() ?? new(),
                DocumentosAdjuntos = entity.DocumentoAdjunto?.Select(d => d.ToDto()).ToList() ?? new()
            };
        }

        // MiembroDto <-> MiembroComite
        public static MiembroComite ToEntity(this MiembroDto dto)
        {
            return new MiembroComite
            {
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Cargo = dto.Cargo
            };
        }

        public static MiembroDto ToDto(this MiembroComite entity)
        {
            return new MiembroDto
            {
                Id = entity.MiembroComiteId,
                Nombre = entity.Nombre,
                Cedula = entity.Cedula,
                Cargo = entity.Cargo
            };
        }

        // JuntaInterventoraDto <-> JuntaInterventora
        public static JuntaInterventora ToEntity(this JuntaInterventoraDto dto)
        {
            return new JuntaInterventora
            {
                Nombre = dto.Nombre,
                Cedula = dto.Cedula
            };
        }

        public static JuntaInterventoraDto ToDto(this JuntaInterventora entity)
        {
            return new JuntaInterventoraDto
            {
                Id = entity.JuntaInterventoraId,
                Nombre = entity.Nombre,
                Cedula = entity.Cedula
            };
        }

        // DocumentoAdjuntoDto <-> DocumentoAdjunto
        public static DocumentoAdjunto ToEntity(this DocumentoAdjuntoDto dto)
        {
            return new DocumentoAdjunto
            {
                NombreOriginal = dto.NombreOriginal,
                RutaArchivo = dto.RutaArchivo,
                TipoDocumento = dto.TipoDocumento,
                FechaSubida = dto.FechaSubida,
                UsuarioId = dto.UsuarioId,
                RegistroComiteId = dto.RegistroComiteId,
                RegistroAsociacionId = dto.RegistroAsociacionId
            };
        }

        public static DocumentoAdjuntoDto ToDto(this DocumentoAdjunto entity)
        {
            return new DocumentoAdjuntoDto
            {
                Id = entity.DocumentoAdjuntoId,
                NombreOriginal = entity.NombreOriginal,
                RutaArchivo = entity.RutaArchivo,
                TipoDocumento = entity.TipoDocumento,
                FechaSubida = entity.FechaSubida,
                RegistroComiteId = entity.RegistroComiteId,
                RegistroAsociacionId = entity.RegistroAsociacionId
            };
        }

        // RegistroAsociacionDto <-> RegistroAsociaciones

        public static RegistroAsociaciones ToEntity(this RegistroAsociacionDto dto)
        {
            return new RegistroAsociaciones
            {
                RegistroAsociacionId = dto.Id,
                Asociacion = dto.Asociacion,
                Tomo = dto.Tomo,
                Folio = dto.Folio,
                Asiento = dto.Asiento,
                ActividadSalud = dto.ActividadSalud,
                Resolucion = dto.Resolucion,

                // ✅ Asegura que se pueda guardar null
                FechaCreacion = dto.FechaCreacion ?? default,

                RepresentanteLegal = new List<RepresentanteLegal> { dto.RepresentanteLegal.ToEntity() },
                ApoderadoLegal = new List<ApoderadoLegal> { dto.ApoderadoLegal.ToEntity() },
                DocumentoAdjunto = dto.DocumentosAdjuntos.Select(d => d.ToEntity()).ToList()
            };
        }

        public static RegistroAsociacionDto ToDto(this RegistroAsociaciones entity)
        {
            return new RegistroAsociacionDto
            {
                Id = entity.RegistroAsociacionId,
                Asociacion = entity.Asociacion,
                Tomo = entity.Tomo,
                Folio = entity.Folio,
                Asiento = entity.Asiento,
                ActividadSalud = entity.ActividadSalud,
                Resolucion = entity.Resolucion,
                FechaCreacion = entity.FechaCreacion,

                // ✅ Toma solo el primer elemento si existe
                RepresentanteLegal = entity.RepresentanteLegal?.FirstOrDefault()?.ToDto(),
                ApoderadoLegal = entity.ApoderadoLegal?.FirstOrDefault()?.ToDto(),

                DocumentosAdjuntos = entity.DocumentoAdjunto?.Select(d => d.ToDto()).ToList() ?? new()
            };
        }

        // RepresentanteLegalDto <-> RepresentanteLegal
        public static RepresentanteLegal ToEntity(this RepresentanteLegalDto dto)
        {
            if (dto == null) return null;

            return new RepresentanteLegal
            {
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Cargo = dto.Cargo,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };
        }

        public static RepresentanteLegalDto ToDto(this RepresentanteLegal entity)
        {
            return new RepresentanteLegalDto
            {
                Id = entity.RepresentanteLegalId,
                Nombre = entity.Nombre,
                Cedula = entity.Cedula,
                Cargo = entity.Cargo,
                Telefono = entity.Telefono,
                Direccion = entity.Direccion
            };
        }

        // ApoderadoLegalDto <-> ApoderadoLegal
        public static ApoderadoLegal ToEntity(this ApoderadoLegalDto dto)
        {
            if (dto == null) return null;

            return new ApoderadoLegal
            {
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

        public static ApoderadoLegalDto ToDto(this ApoderadoLegal entity)
        {
            return new ApoderadoLegalDto
            {
                Id = entity.ApoderadoLegalId,
                Nombre = entity.Nombre,
                Cedula = entity.Cedula,
                Idoneidad = entity.Idoneidad,
                Email = entity.Email,
                Telefono = entity.Telefono,
                Direccion = entity.Direccion,
                EsFirmaAbogados = entity.EsFirmaAbogados,
                FirmaAbogadosNombre = entity.FirmaAbogadosNombre
            };
        }
    }
}