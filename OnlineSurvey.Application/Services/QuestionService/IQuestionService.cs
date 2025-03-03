using OnlineSurvey.Application.Response;

namespace OnlineSurvey.Application.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<Guid?> GetNextQuestion(Guid questionid);
        Task<QuestionResponse?> GetQuestionById(Guid id);
    }
}
