using System;
using System.Collections.Generic;

namespace OnlineSurvey.Infrastructure.Models;

public partial class Survey
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
