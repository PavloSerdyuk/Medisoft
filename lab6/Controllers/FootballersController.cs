using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab6.Models;

namespace lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballersController : ControllerBase
    {
        private readonly FootballClubDBContext _context;

        public FootballersController(FootballClubDBContext context)
        {
            _context = context;
        }

        // GET: api/Footballers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            return await _context.Footballers.ToListAsync();
        }

        // GET: api/Footballers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> GetFootballer(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);

            if (footballer == null)
            {
                return NotFound();
            }

            return footballer;
        }

        // PUT: api/Footballers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootballer(int id, Footballer footballer)
        {
            if (id != footballer.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(footballer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballerExists(id))
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

        // POST: api/Footballers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Footballer>> PostFootballer(Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFootballer", new { id = footballer.EmployeeId }, footballer);
        }

        // DELETE: api/Footballers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballer(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }

            _context.Footballers.Remove(footballer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FootballerExists(int id)
        {
            return _context.Footballers.Any(e => e.EmployeeId == id);
        }
    }
}
