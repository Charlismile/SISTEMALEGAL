using System.Collections.Generic;
using System.Threading.Tasks;
using SISTEMALEGAL.Models.DTOs;

namespace SISTEMALEGAL.Services.Interfaces
{
    public interface IComiteRepository
    {
        Task<int> CreateAsync(ComiteDto dto);
        Task UpdateAsync(ComiteDto dto);
        Task DeleteAsync(int id);
        Task<List<ComiteDto>> GetAllAsync();
        Task<ComiteDto?> GetByIdAsync(int id);
        Task SubirDocumentoResolucionAsync(DocumentoAdjuntoDto documento);

    }
}