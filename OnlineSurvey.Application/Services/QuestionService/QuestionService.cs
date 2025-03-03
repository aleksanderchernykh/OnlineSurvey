using AutoMapper;
using OnlineSurvey.Application.Response;
using OnlineSurvey.Infrastructure.Repositories.QuestionRepository;

namespace OnlineSurvey.Application.Services.QuestionService
{
    public class QuestionService(IQuestionRepository questionRepository, IMapper mapper) : IQuestionService
    {
        protected IQuestionRepository _questionRepository = questionRepository 
            ?? throw new ArgumentNullException(nameof(questionRepository));

        protected IMapper _mapper = mapper 
            ?? throw new ArgumentNullException(nameof(mapper));

        public virtual async Task<QuestionResponse?> GetQuestionById(Guid id)
        {
            var question = await _questionRepository.GetQuestionById(id);

            if (question == null)
                return null;

            return _mapper.Map<QuestionResponse>(question);
        }

        public async Task<Guid?> GetNextQuestion(Guid questionid)
        {
            var question = await _questionRepository.GetQuestionById(questionid) 
                ?? throw new ArgumentNullException(nameof(questionid), "An incorrect question ID was passed");

            var nextQuestion = await _questionRepository.GetQuestionBySurveyIdAndOrder(question.SurveyId, ++question.QuestionOrder);
            if (nextQuestion == null)
                return null;

            return nextQuestion.Id;
        }
    }
}
