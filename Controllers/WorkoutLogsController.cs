using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackerAPI.Data;
using WorkoutTrackerAPI.Models;

namespace WorkoutTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutLogsController : ControllerBase
    {
        private readonly WorkoutTrackerContext _context;

        public WorkoutLogsController(WorkoutTrackerContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutLog>>> GetWorkoutLogs()
        {
            return await _context.WorkoutLogs.ToListAsync();
        }

        // GET: api/WorkoutLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutLog>> GetWorkoutLog(int id)
        {
            var workoutLog = await _context.WorkoutLogs.FindAsync(id);

            if (workoutLog == null)
            {
                return NotFound();
            }

            return workoutLog;
        }

        // PUT: api/WorkoutLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutLog(int id, WorkoutLog workoutLog)
        {
            if (id != workoutLog.WorkoutLogId)
            {
                return BadRequest();
            }

            _context.Entry(workoutLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutLogExists(id))
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

        // POST: api/WorkoutLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkoutLog>> PostWorkoutLog(WorkoutLog workoutLog)
        {
            _context.WorkoutLogs.Add(workoutLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutLog", new { id = workoutLog.WorkoutLogId }, workoutLog);
        }

        // DELETE: api/WorkoutLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutLog(int id)
        {
            var workoutLog = await _context.WorkoutLogs.FindAsync(id);
            if (workoutLog == null)
            {
                return NotFound();
            }

            _context.WorkoutLogs.Remove(workoutLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutLogExists(int id)
        {
            return _context.WorkoutLogs.Any(e => e.WorkoutLogId == id);
        }
    }
}
