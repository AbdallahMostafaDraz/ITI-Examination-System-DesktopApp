using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Choice
{
    public int ChoiceId { get; set; }

    public int? QId { get; set; }

    public string? ChoiceText { get; set; }

    public bool? IsCorrect { get; set; }

    public virtual Question? QIdNavigation { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
}
