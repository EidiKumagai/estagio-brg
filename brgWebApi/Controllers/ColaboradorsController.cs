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
    public class ColaboradorsController : ControllerBase
    {
        private readonly brgDatabaseContext _context;

        public ColaboradorsController(brgDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Colaboradors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador()
        {
            return await _context.Colaborador.ToListAsync();
        }

        // GET: api/Colaboradors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(short id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return colaborador;
        }

        // PUT: api/Colaboradors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaborador(short id, Colaborador colaborador)
        {
            if (id != colaborador.IdColaborador)
            {
                return BadRequest();
            }

            _context.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        // POST: api/Colaboradors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
            _context.Colaborador.Add(colaborador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ColaboradorExists(colaborador.IdColaborador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetColaborador", new { id = colaborador.IdColaborador }, colaborador);
        }

        // DELETE: api/Colaboradors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colaborador>> DeleteColaborador(short id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();

            return colaborador;
        }

        private bool ColaboradorExists(short id)
        {
            return _context.Colaborador.Any(e => e.IdColaborador == id);
        }
    }
}
