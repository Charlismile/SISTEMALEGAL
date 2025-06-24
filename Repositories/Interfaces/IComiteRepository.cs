using System.Collections.Generic;
using System.Threading.Tasks;
using SISTEMALEGAL.Models.DTOs;

namespace SistemaLegalBlazor.Repositories.Interfaces
{
    public interface IComiteRepository
    {
        Task<List<ComiteDto>> GetAllComites();
        Task<ComiteDto> GetComiteById(int id);
        Task<int> CreateComite(ComiteDto dto);
        Task UpdateComite(ComiteDto dto);
        Task DeleteComite(int id);
    }
}