namespace SISTEMALEGAL.Repositories.Interfaces;

public interface IUsuarioService
{
    Task<string> ObtenerUsuarioActualId();
    Task<bool> TienePermiso(string usuarioId, string permiso);
}