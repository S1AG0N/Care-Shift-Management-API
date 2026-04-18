using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareShiftAPI.Data;
using CareShiftAPI.Models;

namespace CareShiftAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShiftsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShiftsController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/shifts?date=2025-03-15
        [HttpGet]
        public async Task<IActionResult> GetShifts([FromQuery] DateTime? date)
        {
            var query = _context.Shifts
                .Include(s => s.CareWorker)
                .AsQueryable();

            if (date.HasValue)
                query = query.Where(s => s.ShiftDate == date.Value.Date);

            return Ok(await query.ToListAsync());
        }

        // POST /api/shifts
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> CreateShift(Shift shift)
        {
            // Conflict check
            bool conflict = await _context.Shifts.AnyAsync(s =>
                s.CareWorkerId == shift.CareWorkerId &&
                s.ShiftDate.Date == shift.ShiftDate.Date &&
                s.Status != "Cancelled"
            );

            if (conflict)
                return Conflict("This worker already has a shift on that date.");

            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShifts), new { id = shift.Id }, shift);
        }

        // PATCH /api/shifts/5/complete
        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> CompleteShift(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);

            if (shift == null)
                return NotFound();

            shift.Status = "Completed";
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}