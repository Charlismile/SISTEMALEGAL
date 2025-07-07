using SISTEMALEGAL.Models.DTOs;

public interface IAsociacionRepository
{
    Task<int> CreateAsync(RegistroAsociacionDto dto);
    Task UpdateAsync(RegistroAsociacionDto dto);
    Task DeleteAsync(int id);
    Task<List<RegistroAsociacionDto>> GetAllAsync();
    Task<RegistroAsociacionDto?> GetByIdAsync(int id);
}