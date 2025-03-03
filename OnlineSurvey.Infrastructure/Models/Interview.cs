using System;
using System.Collections.Generic;

namespace OnlineSurvey.Infrastructure.Models;

public partial class Interview
{
    public Guid Id { get; set; }

    public Guid SurveyId { get; set; }

    public string Fullname { get; set; } = null!;

    public int? Age { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Survey Survey { get; set; } = null!;
}
