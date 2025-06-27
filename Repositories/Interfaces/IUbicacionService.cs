using System.Threading.Tasks;
using SISTEMALEGAL.Models.DTOs;

namespace SISTEMALEGAL.Services.Interfaces
{
    public interface IUbicacionService
    {
        Task<List<RegionSaludDto>> GetAllRegionesAsync();
        Task<List<ProvinciaDto>> GetProvinciasByRegionAsync(int regionId);
        Task<List<DistritoDto>> GetDistritosByProvinciaAsync(int provinciaId);
        Task<List<CorregimientoDto>> GetCorregimientosByDistritoAsync(int distritoId);
    }
}