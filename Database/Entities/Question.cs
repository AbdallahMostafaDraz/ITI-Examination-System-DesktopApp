using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Question
{
    public int QId { get; set; }

    public int? CrsId { get; set; }

    public int? QType { get; set; }

    public string? QBody { get; set; }

    public byte? QMarks { get; set; }

    public virtual ICollection<Choice> Choices { get; set; } = new List<Choice>();

    public virtual Course? Crs { get; set; }

    public virtual QuestionType? QTypeNavigation { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
