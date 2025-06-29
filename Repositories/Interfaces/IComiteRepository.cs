using System.Collections.Generic;
using System.Threading.Tasks;
using SISTEMALEGAL.Models.DTOs;

namespace SISTEMALEGAL.Services.Interfaces
{
    public interface IComiteRepository
    {
        Task<List<ComiteDto>> GetAllAsync();
        Task<ComiteDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ComiteDto dto);
        Task UpdateAsync(ComiteDto dto);
        Task DeleteAsync(int id);
    }
}