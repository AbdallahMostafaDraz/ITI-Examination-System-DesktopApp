using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class CourseStudent
{
    public int CrsId { get; set; }

    public int StId { get; set; }

    public byte? Degree { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Student St { get; set; } = null!;
}
