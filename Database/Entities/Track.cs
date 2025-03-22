using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Track
{
    public int TrkId { get; set; }

    public string? TrkName { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Course> Crs { get; set; } = new List<Course>();

    public virtual ICollection<Instructor> Insts { get; set; } = new List<Instructor>();
}
