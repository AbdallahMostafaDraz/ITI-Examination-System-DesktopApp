using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Course
{
    public int CrsId { get; set; }

    public string? CrsName { get; set; }

    public string? CrsDescription { get; set; }

    public int? CrsHours { get; set; }

    public virtual ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual ICollection<Instructor> Insts { get; set; } = new List<Instructor>();

    public virtual ICollection<Track> Trks { get; set; } = new List<Track>();
}
