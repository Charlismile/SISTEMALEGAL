using SISTEMALEGAL.Models.Entities.BdSisLegal;

namespace SISTEMALEGAL.Repositories.Interfaces;

public interface IArchivoService
{
    Task<string> GuardarArchivo(IFormFile archivo, string carpetaDestino);
    Task<bool> RegistrarArchivoEnBD(string categoria, string nombreOriginal, string nombreGuardado, string url, int? detRegComiteId = null, int? detRegAsociacionId = null);
    Task<List<TbArchivos>> ObtenerArchivosPorComite(int comiteId);
    Task<List<TbArchivos>> ObtenerArchivosPorAsociacion(int asociacionId);
}