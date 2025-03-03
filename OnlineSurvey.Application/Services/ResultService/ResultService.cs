using AutoMapper;
using OnlineSurvey.Application.DTO;
using OnlineSurvey.Infrastructure.Models;
using OnlineSurvey.Infrastructure.Repositories.ResultRepository;

namespace OnlineSurvey.Application.Services.ResultService
{
    public class ResultService(IMapper mapper, IResultRepository resultRepository) : IResultService
    {
        protected IMapper _mapper = mapper 
            ?? throw new ArgumentNullException(nameof(mapper));

        protected IResultRepository _resultRepository = resultRepository 
            ?? throw new ArgumentNullException(nameof(resultRepository));

        public virtual async Task CreateResult(ResultDTO resultDTO)
        {
            var result = _mapper.Map<Result>(resultDTO);
            await _resultRepository.CteateResult(result);
        }
    }
}
