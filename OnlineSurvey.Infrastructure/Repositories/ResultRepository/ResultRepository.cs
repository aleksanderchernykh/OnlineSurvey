using OnlineSurvey.Infrastructure.Data;
using OnlineSurvey.Infrastructure.Models;
using OnlineSurvey.Infrastructure.Repositories.Base;

namespace OnlineSurvey.Infrastructure.Repositories.ResultRepository
{
    public class ResultRepository(OnlineSurveyContext context)
        : RepositoryBase<Result>(context), IResultRepository
    {
        public async Task CteateResult(Result result)
        {
            await _dbSet.AddAsync(result);
            await _context.SaveChangesAsync();
        }
    }
}
