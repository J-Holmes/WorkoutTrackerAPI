using Microsoft.EntityFrameworkCore;
using WorkoutTrackerAPI.Models;

namespace WorkoutTrackerAPI.Data
{
    public class WorkoutTrackerContext:DbContext
    {
        public WorkoutTrackerContext(DbContextOptions<WorkoutTrackerContext> options) : base(options) { }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
    }
}
