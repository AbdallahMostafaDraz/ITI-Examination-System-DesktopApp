using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class StudentExam
{
    public int StId { get; set; }

    public int ExamId { get; set; }

    public decimal? Degree { get; set; }

    public string? Status { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Student St { get; set; } = null!;
}
