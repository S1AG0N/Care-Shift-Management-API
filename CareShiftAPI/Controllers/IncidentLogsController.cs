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
    public class IncidentLogsController: ControllerBase
    {
        private readonly AppDbContext _context;
        public IncidentLogsController(AppDbContext context) {  _context = context; }

        //GET /api/incidentlogs?serverity=High
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? severity)
        {
            var query = _context.IncidentLogs
                .Include(i => i.ReportedByWorker)
                .AsQueryable();
            if(!string.IsNullOrEmpty(severity))
                query = query.Where(i => i.Severity == severity);
            return Ok(await query.OrderByDescending(i => i.IncidentDate).ToListAsync());
        }

        //POST /api/incidentlogs - log a new incident
        [HttpPost]
        public async Task<IActionResult> LogIncident(IncidentLog log)
        {
            log.CreatedAt = DateTime.UtcNow;
            _context.IncidentLogs.Add(log);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = log.Id }, log);
        }

        //GET /api/incidentlogs/summary - counts by severity (for reporting)
        [HttpGet("summary")]
        [Authorize(Roles = "Supervisor,Admin")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _context.IncidentLogs
                .GroupBy(i => i.Severity)
                .Select(g => new {Severity = g.Key, Count = g.Count()})
                .ToListAsync();
            return Ok(summary);
        }

    }
}
