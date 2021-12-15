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
    public class CheckListsController : ControllerBase
    {
        private readonly Context _context;

        public CheckListsController(Context context)
        {
            _context = context;
        }

        // GET: api/CheckLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckList>>> GetCheckList()
        {
            return await _context.CheckList.ToListAsync();
        }

        // GET: api/CheckLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckList>> GetCheckList(string id)
        {
            var checkList = await _context.CheckList.FindAsync(id);

            if (checkList == null)
            {
                return NotFound();
            }

            return checkList;
        }

        // PUT: api/CheckLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckList(string id, CheckList checkList)
        {
            if (id != checkList._id)
            {
                return BadRequest();
            }

            _context.Entry(checkList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckListExists(id))
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

        // POST: api/CheckLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckList>> PostCheckList(CheckList checkList)
        {
            _context.CheckList.Add(checkList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CheckListExists(checkList._id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCheckList", new { id = checkList._id }, checkList);
        }

        // DELETE: api/CheckLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckList(string id)
        {
            var checkList = await _context.CheckList.FindAsync(id);
            if (checkList == null)
            {
                return NotFound();
            }

            _context.CheckList.Remove(checkList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckListExists(string id)
        {
            return _context.CheckList.Any(e => e._id == id);
        }
    }
}
