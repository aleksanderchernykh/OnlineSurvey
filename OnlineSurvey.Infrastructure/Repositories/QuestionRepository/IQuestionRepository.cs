using OnlineSurvey.Infrastructure.Models;

namespace OnlineSurvey.Infrastructure.Repositories.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<Question?> GetQuestionById(Guid id);

        Task<Question?> GetQuestionBySurveyIdAndOrder(Guid surveyId, int order);
    }
}
