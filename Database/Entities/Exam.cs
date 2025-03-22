using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Exam
{
    public int ExamId { get; set; }

    public int? InstId { get; set; }

    public int? ExamType { get; set; }

    public int? CrsId { get; set; }

    public int? BrId { get; set; }

    public int? TrkId { get; set; }

    public DateOnly? ExamDate { get; set; }

    public int? ExamDuration { get; set; }

    public virtual Branch? Br { get; set; }

    public virtual Course? Crs { get; set; }

    public virtual ExamType? ExamTypeNavigation { get; set; }

    public virtual Instructor? Inst { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual Track? Trk { get; set; }

    public virtual ICollection<Question> QIds { get; set; } = new List<Question>();
}
