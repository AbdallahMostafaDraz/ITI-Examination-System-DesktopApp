using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class ExamType
{
    public int TId { get; set; }

    public string? TypeText { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
