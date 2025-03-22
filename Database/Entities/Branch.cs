using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Branch
{
    public int BrId { get; set; }

    public string? BrName { get; set; }

    public string? BrLocation { get; set; }

    public string? BrPhone { get; set; }

    public int? MngrId { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual Instructor? Mngr { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Department> Depts { get; set; } = new List<Department>();
}
