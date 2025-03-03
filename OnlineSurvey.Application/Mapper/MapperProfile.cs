using AutoMapper;
using OnlineSurvey.Application.DTO;
using OnlineSurvey.Application.Response;
using OnlineSurvey.Infrastructure.Models;

namespace OnlineSurvey.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionResponse>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));

            CreateMap<Answer, AnswerResponse>();

            CreateMap<ResultDTO, Result>();
        }
    }
}
