using OnlineSurvey.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Infrastructure.Repositories.ResultRepository
{
    public interface IResultRepository
    {
        Task CteateResult(Result result);
    }
}
