using Microsoft.EntityFrameworkCore;
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

        public async Task<List<RegionSalud>> GetAllRegionesAsync()
        {
            return await _context.RegionSalud.ToListAsync();
        }

        public async Task<List<Provincia>> GetProvinciasByRegionAsync(int regionId)
        {
            return await _context.Provincia
                .Where(p => p.RegionSaludId == regionId)
                .ToListAsync();
        }

        public async Task<List<Distrito>> GetDistritosByProvinciaAsync(int provinciaId)
        {
            return await _context.Distrito
                .Where(d => d.ProvinciaId == provinciaId)
                .ToListAsync();
        }

        public async Task<List<Corregimiento>> GetCorregimientosByDistritoAsync(int distritoId)
        {
            return await _context.Corregimiento
                .Where(c => c.DistritoId == distritoId)
                .ToListAsync();
        }
    }
}