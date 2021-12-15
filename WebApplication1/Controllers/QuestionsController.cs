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
    public class QuestionsController : ControllerBase
    {
        private readonly Context _context;

        public QuestionsController(Context context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questions>> GetQuestions(string id)
        {
            var questions = await _context.Questions.FindAsync(id);

            if (questions == null)
            {
                return NotFound();
            }

            return questions;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestions(string id, Questions questions)
        {
            if (id != questions._id)
            {
                return BadRequest();
            }

            _context.Entry(questions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionsExists(id))
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Questions>> PostQuestions(Questions questions)
        {
            _context.Questions.Add(questions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionsExists(questions._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestions", new { id = questions._id }, questions);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestions(string id)
        {
            var questions = await _context.Questions.FindAsync(id);
            if (questions == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(questions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionsExists(string id)
        {
            return _context.Questions.Any(e => e._id == id);
        }
    }
}
