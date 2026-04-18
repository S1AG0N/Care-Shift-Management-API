using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareShiftAPI.Data;
using CareShiftAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CareShiftAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CareWorkersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CareWorkersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/careworkers - only Supervisors and Admins can list all workers
        [HttpGet]
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> GetAll()
        {
            var workers = await _context.CareWorkers
                .Where(w => w.IsActive)
                .ToListAsync();

            return Ok(workers);
        }

        // GET: api/careworkers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var worker = await _context.CareWorkers.FindAsync(id);

            if (worker == null)
                return NotFound();

            return Ok(worker);
        }

        // POST: api/careworkers
        [HttpPost]
        public async Task<IActionResult> Create(CareWorker worker)
        {
            _context.CareWorkers.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = worker.Id }, worker);
        }

        // PUT: api/careworkers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CareWorker updated)
        {
            if (id != updated.Id)
                return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/careworkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var worker = await _context.CareWorkers.FindAsync(id);

            if (worker == null)
                return NotFound();

            worker.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}