using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Repositories.Interfaces;

namespace LegalSystem.Server.Services
{
    public class HistorialService : IHistorialService
    {
        private readonly DbContextLegal _context;

        public HistorialService(DbContextLegal context) => _context = context;

        public async Task<List<TbDetalleRegComiteHistorial>> ObtenerHistorialComite(int comiteId) =>
            await _context.TbDetalleRegComiteHistorial
                .Where(h => h.ComiteId == comiteId)
                .Include(h => h.CoEstadoSolicitud)
                .OrderByDescending(h => h.FechaCambioCo)
                .ToListAsync();

        public async Task<List<TbDetalleRegAsociacionHistorial>> ObtenerHistorialAsociacion(int asociacionId) =>
            await _context.TbDetalleRegAsociacionHistorial
                .Where(h => h.AsociacionId == asociacionId)
                .Include(h => h.AsEstadoSolicitud)
                .OrderByDescending(h => h.FechaCambioAso)
                .ToListAsync();

        public async Task<bool> AgregarHistorialComite(int comiteId, int estadoId, string comentario, string usuarioId)
        {
            var historial = new TbDetalleRegComiteHistorial
            {
                ComiteId = comiteId,
                CoEstadoSolicitudId = estadoId,
                ComentarioCo = comentario,
                UsuarioRevisorCo = usuarioId
            };
            await _context.TbDetalleRegComiteHistorial.AddAsync(historial);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AgregarHistorialAsociacion(int asociacionId, int estadoId, string comentario, string usuarioId)
        {
            var historial = new TbDetalleRegAsociacionHistorial
            {
                AsociacionId = asociacionId,
                AsEstadoSolicitudId = estadoId,
                ComentarioAso = comentario,
                UsuarioRevisorAso = usuarioId
            };
            await _context.TbDetalleRegAsociacionHistorial.AddAsync(historial);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}