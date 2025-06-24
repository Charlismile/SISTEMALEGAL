using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Models.Extensions;

namespace SISTEMALEGAL.Services
{
    public class ComiteService
    {
        private readonly DbContextSisLegal _context;

        public ComiteService(DbContextSisLegal context)
        {
            _context = context;
        }

        // Guardar un nuevo comité
        public async Task<int> CreateComiteAsync(ComiteDto dto)
        {
            var entity = dto.ToEntity();

            await _context.RegistroComite.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        // Actualizar comité
        public async Task UpdateComiteAsync(ComiteDto dto)
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

            // Limpiar y reemplazar miembros
            _context.MiembroComite.RemoveRange(entity.MiembroComite);
            foreach (var miembro in dto.Miembros)
            {
                entity.MiembroComite.Add(miembro.ToEntity());
            }

            // Limpiar y reemplazar junta interventora
            _context.JuntaInterventora.RemoveRange(entity.JuntaInterventora);
            foreach (var interventor in dto.JuntaInterventoras)
            {
                entity.JuntaInterventora.Add(interventor.ToEntity());
            }

            await _context.SaveChangesAsync();
        }

        // Obtener todos los comités
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

                Miembros = r.MiembroComite?.Select(m => new MiembroDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Cedula = m.Cedula,
                    Cargo = m.Cargo
                }).ToList(),

                JuntaInterventoras = r.JuntaInterventora?.Select(j => new JuntaInterventoraDto
                {
                    Id = j.Id,
                    Nombre = j.Nombre,
                    Cedula = j.Cedula
                }).ToList()
            }).ToList();
        }
    }
}