using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Topic
{
    public int TopicId { get; set; }

    public string? TopicName { get; set; }

    public int? CrsId { get; set; }

    public virtual Course? Crs { get; set; }
}
