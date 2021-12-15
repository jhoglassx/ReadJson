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
    public class SectionsController : ControllerBase
    {
        private readonly Context _context;

        public SectionsController(Context context)
        {
            _context = context;
        }

        // GET: api/Sections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sections>>> GetSections()
        {
            return await _context.Sections.ToListAsync();
        }

        // GET: api/Sections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sections>> GetSections(string id)
        {
            var sections = await _context.Sections.FindAsync(id);

            if (sections == null)
            {
                return NotFound();
            }

            return sections;
        }

        // PUT: api/Sections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSections(string id, Sections sections)
        {
            if (id != sections._id)
            {
                return BadRequest();
            }

            _context.Entry(sections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionsExists(id))
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

        // POST: api/Sections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sections>> PostSections(Sections sections)
        {
            _context.Sections.Add(sections);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SectionsExists(sections._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSections", new { id = sections._id }, sections);
        }

        // DELETE: api/Sections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSections(string id)
        {
            var sections = await _context.Sections.FindAsync(id);
            if (sections == null)
            {
                return NotFound();
            }

            _context.Sections.Remove(sections);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionsExists(string id)
        {
            return _context.Sections.Any(e => e._id == id);
        }
    }
}
