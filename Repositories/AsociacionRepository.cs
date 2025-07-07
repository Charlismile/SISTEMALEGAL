using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Models.Extensions;
using SISTEMALEGAL.Services.Interfaces;

namespace SISTEMALEGAL.Services.Implementations
{
    public class AsociacionRepository : IAsociacionRepository
    {
        private readonly DbContextSisLegal _context;

        public AsociacionRepository(DbContextSisLegal context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(RegistroAsociacionDto dto)
        {
            var entity = dto.ToEntity();
            await _context.RegistroAsociaciones.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.RegistroAsociacionId;
        }

        public async Task UpdateAsync(RegistroAsociacionDto dto)
        {
            var entity = await _context.RegistroAsociaciones
                .Include(a => a.RepresentanteLegal)
                .Include(a => a.ApoderadoLegal)
                .FirstOrDefaultAsync(a => a.RegistroAsociacionId == dto.Id);

            if (entity == null) throw new Exception("Asociación no encontrada");

            entity.Asociacion = dto.Asociacion;
            entity.ActividadSalud = dto.ActividadSalud;
            entity.Resolucion = dto.Resolucion;
            entity.FechaCreacion = dto.FechaCreacion;
            entity.Tomo = dto.Tomo;
            entity.Folio = dto.Folio;
            entity.Asiento = dto.Asiento;

            // Limpia relaciones anteriores
            if (entity.RepresentanteLegal?.Any() == true)
                _context.RepresentanteLegal.RemoveRange(entity.RepresentanteLegal);

            if (entity.ApoderadoLegal?.Any() == true)
                _context.ApoderadoLegal.RemoveRange(entity.ApoderadoLegal);

            if (entity.DocumentoAdjunto?.Any() == true)
                _context.DocumentoAdjunto.RemoveRange(entity.DocumentoAdjunto);

            // Agrega nuevas relaciones
            entity.RepresentanteLegal.Add(dto.RepresentanteLegal.ToEntity());
            entity.ApoderadoLegal.Add(dto.ApoderadoLegal.ToEntity());

            foreach (var doc in dto.DocumentosAdjuntos)
            {
                entity.DocumentoAdjunto.Add(doc.ToEntity());
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegistroAsociaciones
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .Include(r => r.DocumentoAdjunto)
                .FirstOrDefaultAsync(r => r.RegistroAsociacionId == id);

            if (entity != null)
            {
                _context.RegistroAsociaciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<RegistroAsociacionDto>> GetAllAsync()
        {
            var registros = await _context.RegistroAsociaciones.ToListAsync();
            return registros.Select(r => r.ToDto()).ToList();
        }

        public async Task<RegistroAsociacionDto?> GetByIdAsync(int id)
        {
            var registro = await _context.RegistroAsociaciones
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .Include(r => r.DocumentoAdjunto)
                .FirstOrDefaultAsync(r => r.RegistroAsociacionId == id);

            return registro?.ToDto();
        }
    }
}