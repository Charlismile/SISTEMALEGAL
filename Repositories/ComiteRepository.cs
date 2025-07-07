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
                .Include(c => c.DocumentoAdjunto)
                .ToListAsync();

            return registros.Select(r => r.ToDto()).ToList();
        }

        public async Task<ComiteDto?> GetByIdAsync(int id)
        {
            var registro = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .Include(c => c.DocumentoAdjunto)
                .FirstOrDefaultAsync(c => c.RegistroComiteId == id);

            return registro?.ToDto();
        }

        public async Task<int> CreateAsync(ComiteDto dto)
        {
            var entity = dto.ToEntity();
            await _context.RegistroComite.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.RegistroComiteId;
        }

        public async Task UpdateAsync(ComiteDto dto)
        {
            var entity = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .Include(c => c.DocumentoAdjunto)
                .FirstOrDefaultAsync(c => c.RegistroComiteId == dto.Id);

            if (entity == null) throw new Exception("Comité no encontrado");

            // Actualizar campos principales
            entity.ComiteSalud = dto.ComiteSalud;
            entity.RegionSalud = dto.RegionSalud;
            entity.Provincia = dto.Provincia;
            entity.Distrito = dto.Distrito;
            entity.Corregimiento = dto.Corregimiento;
            entity.TipoTramite = dto.TipoTramite;
            entity.FechaEleccion = (DateTime)dto.FechaEleccion;
            entity.FechaCreacion = (DateTime)dto.FechaCreacion;
            entity.Comunidad = dto.Comunidad;

            // Eliminar relaciones anteriores
            if (entity.MiembroComite?.Any() == true)
                _context.MiembroComite.RemoveRange(entity.MiembroComite);

            if (entity.JuntaInterventora?.Any() == true)
                _context.JuntaInterventora.RemoveRange(entity.JuntaInterventora);

            if (entity.DocumentoAdjunto?.Any() == true)
                _context.DocumentoAdjunto.RemoveRange(entity.DocumentoAdjunto);

            // Agregar nuevas relaciones
            foreach (var miembro in dto.Miembros)
            {
                entity.MiembroComite.Add(miembro.ToEntity());
            }

            foreach (var junta in dto.JuntaInterventoras)
            {
                entity.JuntaInterventora.Add(junta.ToEntity());
            }

            foreach (var doc in dto.DocumentosAdjuntos)
            {
                entity.DocumentoAdjunto.Add(doc.ToEntity());
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegistroComite
                .Include(c => c.MiembroComite)
                .Include(c => c.JuntaInterventora)
                .Include(c => c.DocumentoAdjunto)
                .FirstOrDefaultAsync(c => c.RegistroComiteId == id);

            if (entity != null)
            {
                _context.RegistroComite.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}