using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Instructor
{
    public int InstId { get; set; }

    public string? InstFname { get; set; }

    public string? InstLname { get; set; }

    public string? InstEmail { get; set; }

    public string? InstPhone { get; set; }

    public string? InstPassword { get; set; }

    public DateOnly? InstHiringDate { get; set; }

    public int? DeptId { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Course> Crs { get; set; } = new List<Course>();

    public virtual ICollection<Track> Trks { get; set; } = new List<Track>();
}
