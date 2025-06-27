using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.DTOs;
using SISTEMALEGAL.Models.Entities.BDUbicaciones;
using SISTEMALEGAL.Services.Interfaces;

namespace SISTEMALEGAL.Services.Implementations
{
    public class UbicacionService : IUbicacionService
    {
        private readonly DbUbicacionPanama _context;

        public UbicacionService(DbUbicacionPanama context)
        {
            _context = context;
        }

        public async Task<List<RegionSaludDto>> GetAllRegionesAsync()
        {
            return await _context.RegionSalud
                .Select(r => new RegionSaludDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                }).ToListAsync();
        }

        public async Task<List<ProvinciaDto>> GetProvinciasByRegionAsync(int regionId)
        {
            return await _context.Provincia
                .Where(p => p.RegionSaludId == regionId)
                .Select(p => new ProvinciaDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                }).ToListAsync();
        }

        public async Task<List<DistritoDto>> GetDistritosByProvinciaAsync(int provinciaId)
        {
            return await _context.Distrito
                .Where(d => d.ProvinciaId == provinciaId)
                .Select(d => new DistritoDto
                {
                    Id = d.Id,
                    Nombre = d.Nombre
                }).ToListAsync();
        }

        public async Task<List<CorregimientoDto>> GetCorregimientosByDistritoAsync(int distritoId)
        {
            return await _context.Corregimiento
                .Where(c => c.DistritoId == distritoId)
                .Select(c => new CorregimientoDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                }).ToListAsync();
        }
    }
}