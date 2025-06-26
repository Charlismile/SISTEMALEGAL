using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Services.Interfaces;
using SISTEMALEGAL.Models.Extensions;

namespace SISTEMALEGAL.Services.Implementations
{
    public class ComiteRepository : IComiteRepository
    {
        private readonly DbContextSisLegal _context;

        public ComiteRepository(DbContextSisLegal context)
        {
            _context = context;
        }

        public async Task<List<ComiteDto>> GetAllAsync()
        {
            var registros = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .ToListAsync();

            return registros.Select(r => new ComiteDto
            {
                Id = r.Id,
                ComiteSalud = r.ComiteSalud,
                Corregimiento = r.Corregimiento,
                Distrito = r.Distrito,
                Provincia = r.Provincia,
                RegionSalud = r.RegionSalud,
                TipoTramite = r.TipoTramite,
                FechaEleccion = r.FechaEleccion,
                FechaCreacion = r.FechaCreacion,
                Comunidad = r.Comunidad,

                Miembros = r.MiembroComite?
                    .Select(m => new MiembroDto
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Cedula = m.Cedula,
                        Cargo = m.Cargo
                    }).ToList(),

                JuntaInterventoras = r.JuntaInterventora?
                    .Select(j => new JuntaInterventoraDto
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Cedula = j.Cedula
                    }).ToList()
            }).ToList();
        }

        public async Task<ComiteDto?> GetByIdAsync(int id)
        {
            var registro = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (registro == null) return null;

            return new ComiteDto
            {
                Id = registro.Id,
                ComiteSalud = registro.ComiteSalud,
                Corregimiento = registro.Corregimiento,
                Distrito = registro.Distrito,
                Provincia = registro.Provincia,
                RegionSalud = registro.RegionSalud,
                TipoTramite = registro.TipoTramite,
                FechaEleccion = registro.FechaEleccion,
                FechaCreacion = registro.FechaCreacion,
                Comunidad = registro.Comunidad,

                Miembros = registro.MiembroComite?
                    .Select(m => new MiembroDto
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Cedula = m.Cedula,
                        Cargo = m.Cargo
                    }).ToList(),

                JuntaInterventoras = registro.JuntaInterventora?
                    .Select(j => new JuntaInterventoraDto
                    {
                        Id = j.Id,
                        Nombre = j.Nombre,
                        Cedula = j.Cedula
                    }).ToList()
            };
        }

        public async Task<int> CreateAsync(ComiteDto dto)
        {
            var entity = new RegistroComite
            {
                ComiteSalud = dto.ComiteSalud,
                Corregimiento = dto.Corregimiento,
                Distrito = dto.Distrito,
                Provincia = dto.Provincia,
                RegionSalud = dto.RegionSalud,
                
            };

            await _context.RegistroComite.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(ComiteDto dto)
        {
            var entity = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (entity == null) throw new Exception("Comité no encontrado");

            entity.ComiteSalud = dto.ComiteSalud;
            entity.Corregimiento = dto.Corregimiento;
            entity.Distrito = dto.Distrito;
            entity.Provincia = dto.Provincia;
            entity.RegionSalud = dto.RegionSalud;
            entity.TipoTramite = dto.TipoTramite;
            entity.FechaEleccion = dto.FechaEleccion;
            entity.FechaCreacion = dto.FechaCreacion;
            entity.Comunidad = dto.Comunidad;

            // Reemplazar miembros
            _context.MiembroComite.RemoveRange(entity.MiembroComite);
            foreach (var miembro in dto.Miembros)
            {
                entity.MiembroComite.Add(miembro.ToEntity());
            }

            // Reemplazar junta interventora
            _context.JuntaInterventora.RemoveRange(entity.JuntaInterventora);
            foreach (var interventor in dto.JuntaInterventoras)
            {
                entity.JuntaInterventora.Add(interventor.ToEntity());
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity != null)
            {
                // Eliminar relaciones manuales
                if (entity.MiembroComite?.Any() == true)
                    _context.MiembroComite.RemoveRange(entity.MiembroComite);

                if (entity.JuntaInterventora?.Any() == true)
                    _context.JuntaInterventora.RemoveRange(entity.JuntaInterventora);

                // Finalmente, eliminar el comité
                _context.RegistroComite.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}