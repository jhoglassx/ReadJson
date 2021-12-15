using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly Context _context;

        public LevelsController(Context context)
        {
            _context = context;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Levels>>> GetLevels()
        {
            return await _context.Levels.ToListAsync();
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Levels>> GetLevels(string id)
        {
            var levels = await _context.Levels.FindAsync(id);

            if (levels == null)
            {
                return NotFound();
            }

            return levels;
        }

        // PUT: api/Levels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevels(string id, Levels levels)
        {
            if (id != levels._id)
            {
                return BadRequest();
            }

            _context.Entry(levels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelsExists(id))
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

        // POST: api/Levels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Levels>> PostLevels(Levels levels)
        {
            _context.Levels.Add(levels);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LevelsExists(levels._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLevels", new { id = levels._id }, levels);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevels(string id)
        {
            var levels = await _context.Levels.FindAsync(id);
            if (levels == null)
            {
                return NotFound();
            }

            _context.Levels.Remove(levels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LevelsExists(string id)
        {
            return _context.Levels.Any(e => e._id == id);
        }
    }
}
