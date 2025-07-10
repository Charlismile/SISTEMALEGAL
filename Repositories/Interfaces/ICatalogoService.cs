using SISTEMALEGAL.Models.Entities.BdSisLegal;

namespace SISTEMALEGAL.Repositories.Interfaces;

public interface ICatalogoService
{
    Task<List<TbCargosMiembrosComite>> ObtenerCargos();
    Task<List<TbTipoTramite>> ObtenerTiposDeTramite();
    Task<List<TbEstadoSolicitud>> ObtenerEstadosSolicitud();
}