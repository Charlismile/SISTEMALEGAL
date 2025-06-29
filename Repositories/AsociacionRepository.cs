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

        public async Task<List<RegistroAsociacionDto>> GetAllAsync()
        {
            var registros = await _context.RegistroAsociaciones
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .ToListAsync();

            return registros.Select(r => r.ToDto()).ToList();
        }

        public async Task<RegistroAsociacionDto?> GetByIdAsync(int id)
        {
            var registro = await _context.RegistroAsociaciones
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .FirstOrDefaultAsync(r => r.RegistroAsociacionId == id);

            return registro?.ToDto();
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
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .Include(r => r.DocumentoAdjunto)
                .FirstOrDefaultAsync(r => r.RegistroAsociacionId == dto.Id);

            if (entity == null) throw new Exception("Asociación no encontrada");

            // Actualizar campos principales
            entity.Asociacion = dto.Asociacion;
            entity.Tomo = dto.Tomo;
            entity.Folio = dto.Folio;
            entity.Asiento = dto.Asiento;
            entity.ActividadSalud = dto.ActividadSalud;
            entity.Resolucion = dto.Resolucion;
            entity.FechaCreacion = dto.FechaCreacion;

            // Eliminar relaciones anteriores
            if (entity.RepresentanteLegal?.Any() == true)
            {
                _context.RepresentanteLegal.RemoveRange(entity.RepresentanteLegal);
            }

            if (entity.ApoderadoLegal?.Any() == true)
            {
                _context.ApoderadoLegal.RemoveRange(entity.ApoderadoLegal);
            }

            if (entity.DocumentoAdjunto?.Any() == true)
            {
                _context.DocumentoAdjunto.RemoveRange(entity.DocumentoAdjunto);
            }

            // Agregar nuevas relaciones
            if (dto.RepresentanteLegal != null)
            {
                entity.RepresentanteLegal.Add(dto.RepresentanteLegal.ToEntity());
            }

            if (dto.ApoderadoLegal != null)
            {
                entity.ApoderadoLegal.Add(dto.ApoderadoLegal.ToEntity());
            }

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
                if (entity.RepresentanteLegal?.Any() == true)
                    _context.RepresentanteLegal.RemoveRange(entity.RepresentanteLegal);

                if (entity.ApoderadoLegal?.Any() == true)
                    _context.ApoderadoLegal.RemoveRange(entity.ApoderadoLegal);

                if (entity.DocumentoAdjunto?.Any() == true)
                    _context.DocumentoAdjunto.RemoveRange(entity.DocumentoAdjunto);

                _context.RegistroAsociaciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}