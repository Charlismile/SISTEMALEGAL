using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Repositories.Interfaces;

namespace SISTEMALEGAL.Repositories.Services
{
    public class ArchivoService : IArchivoService
    {
        private readonly DbContextLegal _context;
        private readonly IWebHostEnvironment _env;

        public ArchivoService(DbContextLegal context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<string> GuardarArchivo(IFormFile archivo, string carpetaDestino)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, carpetaDestino);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(archivo.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<bool> RegistrarArchivoEnBD(string categoria, string nombreOriginal, string nombreGuardado, string url, int? detRegComiteId = null, int? detRegAsociacionId = null)
        {
            var archivo = new TbArchivos
            {
                Categoria = categoria,
                NombreOriginal = nombreOriginal,
                NombreArchivoGuardado = nombreGuardado,
                Url = url,
                DetRegComiteId = detRegComiteId,
                DetRegAsociacionId = detRegAsociacionId
            };

            await _context.TbArchivos.AddAsync(archivo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TbArchivos>> ObtenerArchivosPorComite(int comiteId) =>
            await _context.TbArchivos
                .Where(a => a.DetRegComiteId == comiteId)
                .ToListAsync();

        public async Task<List<TbArchivos>> ObtenerArchivosPorAsociacion(int asociacionId) =>
            await _context.TbArchivos
                .Where(a => a.DetRegAsociacionId == asociacionId)
                .ToListAsync();
    }
}