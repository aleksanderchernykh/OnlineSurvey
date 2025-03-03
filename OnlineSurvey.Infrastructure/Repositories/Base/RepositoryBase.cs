using Microsoft.EntityFrameworkCore;
using OnlineSurvey.Infrastructure.Data;

namespace OnlineSurvey.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly OnlineSurveyContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(OnlineSurveyContext context)
        {
            _context = context 
                ?? throw new ArgumentNullException(nameof(context));

            _dbSet = _context.Set<T>();
        }
    }
}
