using System;
using System.Collections.Generic;

namespace WorkoutTrackerAPI.Models;

public partial class WorkoutLog
{
    public int WorkoutLogId { get; set; }

    public int? ExerciseId { get; set; }

    public int UserId { get; set; }

    public DateOnly Date { get; set; }

    public int Sets { get; set; }

    public int Repetitions { get; set; }

    public int WeightLbs { get; set; }

    public virtual Exercise? Exercise { get; set; }
}
