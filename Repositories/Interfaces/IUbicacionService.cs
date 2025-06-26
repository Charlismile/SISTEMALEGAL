using System.Collections.Generic;
using System.Threading.Tasks;
using SISTEMALEGAL.Models.Entities.BDUbicaciones;

namespace SISTEMALEGAL.Services.Interfaces
{
    public interface IUbicacionService
    {
        Task<List<RegionSalud>> GetAllRegionesAsync();
        Task<List<Provincia>> GetProvinciasByRegionAsync(int regionId);
        Task<List<Distrito>> GetDistritosByProvinciaAsync(int provinciaId);
        Task<List<Corregimiento>> GetCorregimientosByDistritoAsync(int distritoId);
    }
}