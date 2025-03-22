using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Student
{
    public int StId { get; set; }

    public string? StFname { get; set; }

    public string? StLname { get; set; }

    public string? StEmail { get; set; }

    public string? StPhone { get; set; }

    public string? StPassword { get; set; }

    public int? DeptId { get; set; }

    public DateOnly? StJoinDate { get; set; }

    public int? TrackId { get; set; }

    public int? BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

    public virtual Department? Dept { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual Track? Track { get; set; }
}
