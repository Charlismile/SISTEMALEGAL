
using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Repositories.Interfaces;

public class CatalogoService : ICatalogoService
{
    private readonly DbContextLegal _context;

    public CatalogoService(DbContextLegal context) => _context = context;

    public async Task<List<TbCargosMiembrosComite>> ObtenerCargos() =>
        await _context.TbCargosMiembrosComite.Where(c => c.IsActivo).ToListAsync();

    public async Task<List<TbTipoTramite>> ObtenerTiposDeTramite() =>
        await _context.TbTipoTramite.Where(t => t.IsActivo).ToListAsync();

    public async Task<List<TbEstadoSolicitud>> ObtenerEstadosSolicitud() =>
        await _context.TbEstadoSolicitud.ToListAsync();
}