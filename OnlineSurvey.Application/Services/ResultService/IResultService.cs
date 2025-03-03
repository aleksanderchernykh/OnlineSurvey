using OnlineSurvey.Application.DTO;
using System;
namespace OnlineSurvey.Application.Services.ResultService
{
    public interface IResultService
    {
        Task CreateResult(ResultDTO resultDTO);
    }
}
