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
    public class AnswerTypesController : ControllerBase
    {
        private readonly Context _context;

        public AnswerTypesController(Context context)
        {
            _context = context;
        }

        // GET: api/AnswerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerTypes>>> GetAnswerTypes()
        {
            return await _context.AnswerTypes.ToListAsync();
        }

        // GET: api/AnswerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerTypes>> GetAnswerTypes(string id)
        {
            var answerTypes = await _context.AnswerTypes.FindAsync(id);

            if (answerTypes == null)
            {
                return NotFound();
            }

            return answerTypes;
        }

        // PUT: api/AnswerTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerTypes(string id, AnswerTypes answerTypes)
        {
            if (id != answerTypes._id)
            {
                return BadRequest();
            }

            _context.Entry(answerTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerTypesExists(id))
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

        // POST: api/AnswerTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnswerTypes>> PostAnswerTypes(AnswerTypes answerTypes)
        {
            _context.AnswerTypes.Add(answerTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnswerTypesExists(answerTypes._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnswerTypes", new { id = answerTypes._id }, answerTypes);
        }

        // DELETE: api/AnswerTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerTypes(string id)
        {
            var answerTypes = await _context.AnswerTypes.FindAsync(id);
            if (answerTypes == null)
            {
                return NotFound();
            }

            _context.AnswerTypes.Remove(answerTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerTypesExists(string id)
        {
            return _context.AnswerTypes.Any(e => e._id == id);
        }
    }
}
