namespace WorkoutTrackerAPI.Models
{
    public class WorkoutLog
    {
        public int WorkoutLogId { get; set; }
        public int ExerciseId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public int WeightLbs { get; set; }
        public Exercise Exercise { get; set; }
    }
}
