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
    public class AnswersController : ControllerBase
    {
        private readonly Context _context;

        public AnswersController(Context context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answers>>> GetAnswers()
        {
            return await _context.Answers.ToListAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answers>> GetAnswers(string id)
        {
            var answers = await _context.Answers.FindAsync(id);

            if (answers == null)
            {
                return NotFound();
            }

            return answers;
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswers(string id, Answers answers)
        {
            if (id != answers._id)
            {
                return BadRequest();
            }

            _context.Entry(answers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswersExists(id))
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

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Answers>> PostAnswers(Answers answers)
        {
            _context.Answers.Add(answers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnswersExists(answers._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnswers", new { id = answers._id }, answers);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswers(string id)
        {
            var answers = await _context.Answers.FindAsync(id);
            if (answers == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswersExists(string id)
        {
            return _context.Answers.Any(e => e._id == id);
        }
    }
}
