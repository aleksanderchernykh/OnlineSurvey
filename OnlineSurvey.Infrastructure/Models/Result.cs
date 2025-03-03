using System;
using System.Collections.Generic;

namespace OnlineSurvey.Infrastructure.Models;

public partial class Result
{
    public Guid Id { get; set; }

    public Guid InterviewId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid? AnswerId { get; set; }

    public virtual Answer? Answer { get; set; }

    public virtual Interview Interview { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
