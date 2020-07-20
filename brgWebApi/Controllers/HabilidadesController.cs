using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using brgWebApi.Models;

namespace brgWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private readonly brgDatabaseContext _context;

        public HabilidadesController(brgDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Habilidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habilidades>>> GetHabilidades()
        {
            return await _context.Habilidades.ToListAsync();
        }

        // GET: api/Habilidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Habilidades>> GetHabilidades(short id)
        {
            var habilidades = await _context.Habilidades.FindAsync(id);

            if (habilidades == null)
            {
                return NotFound();
            }

            return habilidades;
        }

        // PUT: api/Habilidades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabilidades(short id, Habilidades habilidades)
        {
            if (id != habilidades.IdHabilidades)
            {
                return BadRequest();
            }

            _context.Entry(habilidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilidadesExists(id))
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

        // POST: api/Habilidades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Habilidades>> PostHabilidades(Habilidades habilidades)
        {
            _context.Habilidades.Add(habilidades);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HabilidadesExists(habilidades.IdHabilidades))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHabilidades", new { id = habilidades.IdHabilidades }, habilidades);
        }

        // DELETE: api/Habilidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Habilidades>> DeleteHabilidades(short id)
        {
            var habilidades = await _context.Habilidades.FindAsync(id);
            if (habilidades == null)
            {
                return NotFound();
            }

            _context.Habilidades.Remove(habilidades);
            await _context.SaveChangesAsync();

            return habilidades;
        }

        private bool HabilidadesExists(short id)
        {
            return _context.Habilidades.Any(e => e.IdHabilidades == id);
        }
    }
}
