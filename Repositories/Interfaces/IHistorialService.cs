using SISTEMALEGAL.Models.Entities.BdSisLegal;

namespace SISTEMALEGAL.Repositories.Interfaces;

public interface IHistorialService
{
    Task<bool> AgregarHistorialComite(int comiteId, int estadoId, string comentario, string usuarioId);
    Task<bool> AgregarHistorialAsociacion(int asociacionId, int estadoId, string comentario, string usuarioId);
    Task<List<TbDetalleRegComiteHistorial>> ObtenerHistorialComite(int comiteId);
    Task<List<TbDetalleRegAsociacionHistorial>> ObtenerHistorialAsociacion(int asociacionId);
}