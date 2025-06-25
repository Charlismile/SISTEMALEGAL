using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Services.Interfaces;
using SISTEMALEGAL.Models.Extensions;

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
            var registros = await _context.RegistroAsociaciones.ToListAsync();

            return registros.Select(r => new RegistroAsociacionDto
            {
                Id = r.Id,
                Asociacion = r.Asociacion,
                Tomo = r.Tomo,
                Folio = r.Folio,
                Asiento = r.Asiento,
                ActividadSalud = r.ActividadSalud,
                Resolucion = r.Resolucion,
                FechaCreacion = r.FechaCreacion,
                
            }).ToList();
        }

        public async Task<RegistroAsociacionDto?> GetByIdAsync(int id)
        {
            var registro = await _context.RegistroAsociaciones
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (registro == null) return null;

            return new RegistroAsociacionDto
            {
                Id = registro.Id,
                Asociacion = registro.Asociacion,
                Tomo = registro.Tomo,
                Folio = registro.Folio,
                Asiento = registro.Asiento,
                ActividadSalud = registro.ActividadSalud,
                Resolucion = registro.Resolucion,
                FechaCreacion = registro.FechaCreacion,
                
            };
        }

        public async Task<int> CreateAsync(RegistroAsociacionDto dto)
{
    var entity = dto.ToEntity();
    await _context.RegistroAsociaciones.AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity.Id;
}

        public async Task UpdateAsync(RegistroAsociacionDto dto)
        {
            var entity = await _context.RegistroAsociaciones
                .Include(r => r.RepresentanteLegal)
                .Include(r => r.ApoderadoLegal)
                .FirstOrDefaultAsync(r => r.Id == dto.Id);

            if (entity == null) throw new Exception("Asociación no encontrada");

            // Actualizar campos principales
            entity.Asociacion = dto.Asociacion;
            entity.Tomo = dto.Tomo;
            entity.Folio = dto.Folio;
            entity.Asiento = dto.Asiento;
            entity.ActividadSalud = dto.ActividadSalud;
            entity.Resolucion = dto.Resolucion;
            entity.FechaCreacion = dto.FechaCreacion;

            // Actualizar representante legal (uno o varios)
            if (entity.RepresentanteLegal is not null)
                _context.RepresentanteLegal.RemoveRange(entity.RepresentanteLegal);
    
            if (dto.RepresentanteLegal != null)
                entity.RepresentanteLegal.Add(dto.RepresentanteLegal.ToEntity());

            // Actualizar apoderado legal (uno o varios)
            if (entity.ApoderadoLegal is not null)
                _context.ApoderadoLegal.RemoveRange(entity.ApoderadoLegal);

            if (dto.ApoderadoLegal != null)
                entity.ApoderadoLegal.Add(dto.ApoderadoLegal.ToEntity());
    
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.RegistroAsociaciones.FindAsync(id);
            if (entity != null)
            {
                _context.RegistroAsociaciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}