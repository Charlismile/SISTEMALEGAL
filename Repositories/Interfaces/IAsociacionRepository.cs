using SISTEMALEGAL.Models.DTOs;
using System.Threading.Tasks;

namespace SISTEMALEGAL.Services.Interfaces
{
    public interface IAsociacionRepository
    {
        Task<List<RegistroAsociacionDto>> GetAllAsync();
        Task<RegistroAsociacionDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(RegistroAsociacionDto dto);
        Task UpdateAsync(RegistroAsociacionDto dto);
        Task DeleteAsync(int id);

        // Nuevo método
        Task SubirDocumentoResolucionAsync(DocumentoAdjuntoDto documento);
    }
}