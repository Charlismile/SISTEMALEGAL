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
                Provincia = dto.Provincia,
                Distrito = dto.Distrito,
                Corregimiento = dto.Corregimiento,

                MiembroComite = dto.Miembros.Select(m => m.ToEntity()).ToList(),
                JuntaInterventora = dto.JuntaInterventoras.Select(j => j.ToEntity()).ToList(),

                // ✅ Ahora sí puedes asignar listas
                DocumentoAdjunto = dto.DocumentosAdjuntos?.Select(d => d.ToEntity()).ToList() ?? new List<DocumentoAdjunto>()
            };
        }

        public static ComiteDto ToDto(this RegistroComite entity)
        {
            return new ComiteDto
            {
                Id = entity.Id,
                ComiteSalud = entity.ComiteSalud,
                Provincia = entity.Provincia,
                Distrito = entity.Distrito,
                Corregimiento = entity.Corregimiento,

                Miembros = entity.MiembroComite?.Select(m => m.ToDto()).ToList() ?? new(),
                JuntaInterventoras = entity.JuntaInterventora?.Select(j => j.ToDto()).ToList() ?? new(),
        
                // ✅ Mapea correctamente desde entidad a DTO
                DocumentosAdjuntos = entity.DocumentoAdjunto?.Select(d => d.ToDto()).ToList() ?? new()
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
        
        public static MiembroDto ToDto(this MiembroComite entity)
        {
            return new MiembroDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Cedula = entity.Cedula,
                Cargo = entity.Cargo
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

        public static JuntaInterventoraDto ToDto(this JuntaInterventora entity)
        {
            return new JuntaInterventoraDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Cedula = entity.Cedula
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
                RegistroComiteId = entity.RegistroComiteId
            };
        }
    }
}