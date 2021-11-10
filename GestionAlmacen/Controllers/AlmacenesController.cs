using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionAlmacen.Data;
using GestionAlmacen.Models;

namespace GestionAlmacen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlmacenesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Almacenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almacenes>>> GetAlmacen()
        {
            return await _context.Almacen.ToListAsync();
        }

        // GET: api/Almacenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Almacenes>> GetAlmacenes(string id)
        {
            var almacenes = await _context.Almacen.FindAsync(id);

            if (almacenes == null)
            {
                return NotFound();
            }

            return almacenes;
        }

        // PUT: api/Almacenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacenes(string id, Almacenes almacenes)
        {
            if (id != almacenes.producto)
            {
                return BadRequest();
            }

            _context.Entry(almacenes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenesExists(id))
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

        // POST: api/Almacenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Almacenes>> PostAlmacenes(Almacenes almacenes)
        {
            _context.Almacen.Add(almacenes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlmacenesExists(almacenes.producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlmacenes", new { id = almacenes.producto }, almacenes);
        }

        // DELETE: api/Almacenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacenes(string id)
        {
            var almacenes = await _context.Almacen.FindAsync(id);
            if (almacenes == null)
            {
                return NotFound();
            }

            _context.Almacen.Remove(almacenes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlmacenesExists(string id)
        {
            return _context.Almacen.Any(e => e.producto == id);
        }
    }
}
