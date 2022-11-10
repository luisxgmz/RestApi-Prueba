using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApiREST.Models;

namespace PruebaApiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly TodoContext _context;
        public SolicitudesController(TodoContext context)
        {
            _context = context;
        }
        [HttpGet] // Obtener listado de solicitudes
        public async Task<ActionResult<List<SolicitudDTO>>> GetSolicitudes()
        {
            return await _context.Solicitudes
                .Select(x => SolicitudToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")] // Obtener solicitud mediante Id
        public async Task<ActionResult<SolicitudDTO>> GetSolicitud(int? id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return SolicitudToDTO(solicitud);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int? id, Solicitud solicitud)
        {
            if (id != solicitud.idSolicitud)
            {
                return BadRequest();
            }
            _context.Entry(solicitud).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            if (_context.Solicitudes == null)
            {
                return Problem("Entity set 'TodoContext.Solicitudes'  is null.");
            }
            _context.Solicitudes.Add(solicitud);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolicitudExists(solicitud.idSolicitud))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetSolicitud", new { id = solicitud.idSolicitud }, solicitud);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int? id)
        {
            if (_context.Solicitudes == null)
            {
                return NotFound();
            }
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SolicitudExists(int? id)
        {
            return (_context.Solicitudes?.Any(e => e.idSolicitud == id)).GetValueOrDefault();
        }
        private static SolicitudDTO SolicitudToDTO(Solicitud _solicitud) =>
            new SolicitudDTO
            {
                idSolicitud = _solicitud.idSolicitud,
                Descripcion = _solicitud.Descripcion,
                Importancia = _solicitud.Importancia,
                Fecha = _solicitud.Fecha,
                Status = _solicitud.Status
            };
    }
}
