using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaLegalBlazor.Repositories.Interfaces;

namespace SistemaLegalBlazor.Repositories.Implementations
{
    public class ComiteRepository : IComiteRepository
    {
        private readonly DbContextSisLegal _context;

        public ComiteRepository(DbContextSisLegal context)
        {
            _context = context;
        }

        public async Task<List<ComiteDto>> GetAllComites()
        {
            var comites = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .ToListAsync();

            return comites.Select(c => new ComiteDto
            {
                Id = c.Id,
                ComiteSalud = c.ComiteSalud,
                Corregimiento = c.Corregimiento,
                Distrito = c.Distrito,
                Provincia = c.Provincia,
                RegionSalud = c.RegionSalud,
                TipoTramite = c.TipoTramite,

                // Conversión DateOnly <-> DateTime (si usas DateOnly en DTOs)
                FechaEleccion = c.FechaEleccion.HasValue ?
                    new DateTime(c.FechaEleccion.Value.Year, c.FechaEleccion.Value.Month, c.FechaEleccion.Value.Day) :
                    (DateTime?)null,

                FechaCreacion = c.FechaCreacion.HasValue ?
                    new DateTime(c.FechaCreacion.Value.Year, c.FechaCreacion.Value.Month, c.FechaCreacion.Value.Day) :
                    (DateTime?)null,

                Miembros = c.MiembroComite?.Select(m => new MiembroDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Cedula = m.Cedula,
                    Cargo = m.Cargo
                }).ToList(),

                JuntaInterventoras = c.JuntaInterventora?.Select(j => new JuntaInterventoraDto
                {
                    Id = j.Id,
                    Nombre = j.Nombre,
                    Cedula = j.Cedula
                }).ToList()
            }).ToList();
        }

        public async Task<ComiteDto> GetComiteById(int id)
        {
            var comite = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comite == null) return null;

            return new ComiteDto
            {
                Id = comite.Id,
                ComiteSalud = comite.ComiteSalud,
                Corregimiento = comite.Corregimiento,
                Distrito = comite.Distrito,
                Provincia = comite.Provincia,
                RegionSalud = comite.RegionSalud,
                TipoTramite = comite.TipoTramite,

                FechaEleccion = comite.FechaEleccion.HasValue ?
                    new DateTime(comite.FechaEleccion.Value.Year, comite.FechaEleccion.Value.Month, comite.FechaEleccion.Value.Day) :
                    (DateTime?)null,

                FechaCreacion = comite.FechaCreacion.HasValue ?
                    new DateTime(comite.FechaCreacion.Value.Year, comite.FechaCreacion.Value.Month, comite.FechaCreacion.Value.Day) :
                    (DateTime?)null,

                Miembros = comite.MiembroComite?.Select(m => new MiembroDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Cedula = m.Cedula,
                    Cargo = m.Cargo
                }).ToList(),

                JuntaInterventoras = comite.JuntaInterventora?.Select(j => new JuntaInterventoraDto
                {
                    Id = j.Id,
                    Nombre = j.Nombre,
                    Cedula = j.Cedula
                }).ToList()
            };
        }

        public async Task<int> CreateComite(ComiteDto dto)
        {
            var entidad = new RegistroComite
            {
                Id = dto.Id,
                ComiteSalud = dto.ComiteSalud,
                Corregimiento = dto.Corregimiento,
                Distrito = dto.Distrito,
                Provincia = dto.Provincia,
                RegionSalud = dto.RegionSalud,
                TipoTramite = dto.TipoTramite,

                // Directamente asignable
                FechaEleccion = dto.FechaEleccion,
                FechaCreacion = dto.FechaCreacion,

                MiembroComite = dto.Miembros?
                    .Select(m => new MiembroComite
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Cedula = m.Cedula,
                        Cargo = m.Cargo
                    }).ToList() ?? new List<MiembroComite>(),

                JuntaInterventora = dto.JuntaInterventoras?
                    .Select(j => new JuntaInterventora
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Cedula = j.Cedula
                    }).ToList() ?? new List<JuntaInterventora>()
            };
            await _context.RegistroComite.AddAsync(entidad);
            await _context.SaveChangesAsync();

            return entidad.Id;
        }

        public async Task UpdateComite(ComiteDto dto)
        {
            var entidad = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (entidad == null)
                throw new Exception("Comité no encontrado");

            // Actualiza campos principales
            entidad.ComiteSalud = dto.ComiteSalud;
            entidad.Corregimiento = dto.Corregimiento;
            entidad.Distrito = dto.Distrito;
            entidad.Provincia = dto.Provincia;
            entidad.RegionSalud = dto.RegionSalud;
            entidad.TipoTramite = dto.TipoTramite;

            // Reemplazar miembros
            _context.MiembroComite.RemoveRange(entidad.MiembroComite);
            foreach (var miembro in dto.Miembros)
            {
                entidad.MiembroComite.Add(new MiembroComite
                {
                    Nombre = miembro.Nombre,
                    Cedula = miembro.Cedula,
                    Cargo = miembro.Cargo
                });
            }

            // Reemplazar junta interventora
            _context.JuntaInterventora.RemoveRange(entidad.JuntaInterventora);
            foreach (var interventor in dto.JuntaInterventoras)
            {
                entidad.JuntaInterventora.Add(new JuntaInterventora
                {
                    Nombre = interventor.Nombre,
                    Cedula = interventor.Cedula
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteComite(int id)
        {
            var entidad = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entidad != null)
            {
                _context.RegistroComite.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
    }
}