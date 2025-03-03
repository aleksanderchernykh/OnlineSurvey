namespace OnlineSurvey.Infrastructure.Models;

public partial class Question
{
    public Guid Id { get; set; }

    public Guid SurveyId { get; set; }

    public string QuestionText { get; set; } = null!;

    public int QuestionOrder { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Survey Survey { get; set; } = null!;
}
