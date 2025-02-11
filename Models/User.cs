using System;
using System.Collections.Generic;

namespace WorkoutTrackerAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Hashpass { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
}
