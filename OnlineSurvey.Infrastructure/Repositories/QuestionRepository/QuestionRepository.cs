using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Infrastructure.Data;
using OnlineSurvey.Infrastructure.Models;
using OnlineSurvey.Infrastructure.Repositories.Base;

namespace OnlineSurvey.Infrastructure.Repositories.QuestionRepository
{
    public class QuestionRepository(OnlineSurveyContext context)
        : RepositoryBase<Question>(context), IQuestionRepository
    {
        public async Task<Question?> GetQuestionById(Guid id)
        {
            return await _dbSet
                .Include(q => q.Answers)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Question?> GetQuestionBySurveyIdAndOrder(Guid surveyId, int order)
        {
            return await _dbSet
                .Where(x => x.SurveyId == surveyId && x.QuestionOrder == order)
                .FirstOrDefaultAsync();
        }
    }
}
