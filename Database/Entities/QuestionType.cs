using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class QuestionType
{
    public int TId { get; set; }

    public string? QType { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
