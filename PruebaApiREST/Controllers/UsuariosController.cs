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
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly string cadenaSQL;
        private readonly TodoContext _context;
        public UsuariosController(TodoContext context, IConfiguration config)
        {
            _context = context;
            cadenaSQL = config.GetConnectionString("Conexion");
        }
        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            // var usuarios = _repository.GetUsuarios();
            return await _context.Usuarios
                .Select(x => UsuarioToDTO(x))
                .ToListAsync();
        }
        
        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return UsuarioToDTO(usuario);
        }

        // PUT: api/Usuarios/5     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDTO usuarioDTO)
        {
            if (id != usuarioDTO.idUsuario)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nombre = usuarioDTO.Nombre;
            usuario.Email = usuarioDTO.Email;
            usuario.FNac = usuarioDTO.FNac;
            usuario.Area = usuarioDTO.Area;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UsuarioExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                idUsuario=usuarioDTO.idUsuario,
                Nombre = usuarioDTO.Nombre,
                Email = usuarioDTO.Email,
                Area = usuarioDTO.Area
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUsuario),
                new { id = usuario.idUsuario },
                UsuarioToDTO(usuario));
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.idUsuario == id)).GetValueOrDefault();
        }

        private static UsuarioDTO UsuarioToDTO(Usuario usuario) =>
            new UsuarioDTO
            {
                idUsuario = usuario.idUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                FNac = usuario.FNac,
                Area = usuario.Area
            };
    }
}
