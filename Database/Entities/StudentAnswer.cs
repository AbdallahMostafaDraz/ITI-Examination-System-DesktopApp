using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class StudentAnswer
{
    public int StId { get; set; }

    public int ExamId { get; set; }

    public int QId { get; set; }

    public int StAnswer { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question QIdNavigation { get; set; } = null!;

    public virtual Student St { get; set; } = null!;

    public virtual Choice StAnswerNavigation { get; set; } = null!;
}
