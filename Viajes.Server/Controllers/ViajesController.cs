using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajes.Server.Models;
using Viajes.Server.Clima;
using System.Security.Claims;

namespace Viajes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly DbviajesContext _context;
        private readonly HttpClient _httpCliente; 

        public ViajesController(DbviajesContext context, HttpClient httpCliente)
        {
            _context = context;
            _httpCliente = httpCliente;
        }

        // GET: api/Viajes
        [HttpGet]
        [Route("listaViajes")]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetViajes()
        {
            var listViajes = await _context.Viajes.ToListAsync();
            return Ok(listViajes);
        }

        // GET: api/Viajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viaje>> GetViaje(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return viaje;
        }

        // PUT: api/Viajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViaje(int id, Viaje viaje)
        {
            if (id != viaje.IdViaje)
            {
                return BadRequest();
            }

            _context.Entry(viaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeExists(id))
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

        // POST: api/Viajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viaje>> PostViaje(Viaje viaje)
        {
            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViaje", new { id = viaje.IdViaje }, viaje);
        }

        // DELETE: api/Viajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViaje(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }

            _context.Viajes.Remove(viaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeExists(int id)
        {
            return _context.Viajes.Any(e => e.IdViaje == id);
        }

        [HttpGet("{idCiudad}")]  /* Obtiene por medio de id de ciudad el clima */
        public async Task<IActionResult> ObtenerDatosClima(int idCiudad)
        {
            var Ciudad = await _context.Ciudades.FirstAsync(c => c.IdCiudad == idCiudad);
            geoClima clima = new geoClima(_httpCliente);
            var dato = clima.ObtenerClima(Ciudad.Nombre);
            return Ok(dato);
        }

    }
}
