using System.Collections.Generic;
using System.Threading.Tasks;
using SISTEMALEGAL.Models.DTOs;

namespace SISTEMALEGAL.Services.Interfaces
{
    public interface IAsociacionRepository
    {
        Task<List<RegistroAsociacionDto>> GetAllAsync();
        Task<RegistroAsociacionDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(RegistroAsociacionDto dto);
        Task UpdateAsync(RegistroAsociacionDto dto);
        Task DeleteAsync(int id);
    }
}