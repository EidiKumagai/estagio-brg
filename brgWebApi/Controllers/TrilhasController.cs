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
    public class TrilhasController : ControllerBase
    {
        private readonly brgDatabaseContext _context;

        public TrilhasController(brgDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Trilhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trilha>>> GetTrilha()
        {
            return await _context.Trilha.ToListAsync();
        }

        // GET: api/Trilhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trilha>> GetTrilha(short id)
        {
            var trilha = await _context.Trilha.FindAsync(id);

            if (trilha == null)
            {
                return NotFound();
            }

            return trilha;
        }

        // PUT: api/Trilhas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrilha(short id, Trilha trilha)
        {
            if (id != trilha.IdTrilha)
            {
                return BadRequest();
            }

            _context.Entry(trilha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrilhaExists(id))
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

        // POST: api/Trilhas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trilha>> PostTrilha(Trilha trilha)
        {
            _context.Trilha.Add(trilha);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrilhaExists(trilha.IdTrilha))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrilha", new { id = trilha.IdTrilha }, trilha);
        }

        // DELETE: api/Trilhas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trilha>> DeleteTrilha(short id)
        {
            var trilha = await _context.Trilha.FindAsync(id);
            if (trilha == null)
            {
                return NotFound();
            }

            _context.Trilha.Remove(trilha);
            await _context.SaveChangesAsync();

            return trilha;
        }

        private bool TrilhaExists(short id)
        {
            return _context.Trilha.Any(e => e.IdTrilha == id);
        }
    }
}
