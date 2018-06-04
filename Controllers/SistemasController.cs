using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2HelpAPICore.Models;
using Microsoft.AspNetCore.Authorization;

namespace P2HelpAPICore.Controllers
{
    [Produces("application/json")]
    [Route("api/Sistemas")]
    [Authorize()]
    public class SistemasController : Controller
    {
        private readonly P2HelpContext _context;

        public SistemasController(P2HelpContext context)
        {
            _context = context;
        }

        // GET: api/Sistemas
        [HttpGet]
        public IEnumerable<Sistema> GetSistema()
        {
            return _context.Sistema;
        }

        // GET: api/Sistemas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSistema([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sistema = await _context.Sistema.SingleOrDefaultAsync(m => m.Id == id);

            if (sistema == null)
            {
                return NotFound();
            }

            return Ok(sistema);
        }

        // PUT: api/Sistemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistema([FromRoute] int id, [FromBody] Sistema sistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sistema.Id)
            {
                return BadRequest();
            }

            _context.Entry(sistema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemaExists(id))
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

        // POST: api/Sistemas
        [HttpPost]
        public async Task<IActionResult> PostSistema([FromBody] Sistema sistema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sistema.Add(sistema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSistema", new { id = sistema.Id }, sistema);
        }

        // DELETE: api/Sistemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistema([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sistema = await _context.Sistema.SingleOrDefaultAsync(m => m.Id == id);
            if (sistema == null)
            {
                return NotFound();
            }

            _context.Sistema.Remove(sistema);
            await _context.SaveChangesAsync();

            return Ok(sistema);
        }

        private bool SistemaExists(int id)
        {
            return _context.Sistema.Any(e => e.Id == id);
        }
    }
}