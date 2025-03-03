using System;
using System.Collections.Generic;

namespace OnlineSurvey.Infrastructure.Models;

public partial class Answer
{
    public Guid Id { get; set; }

    public Guid QuestionId { get; set; }

    public string AnswerText { get; set; } = null!;

    public int AnswerOrder { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
