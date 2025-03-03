using ElectronicLearningSystem.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineSurvey.Application.DTO;
using OnlineSurvey.Application.Mapper;
using OnlineSurvey.Application.Response;
using OnlineSurvey.Application.Services.QuestionService;
using OnlineSurvey.Application.Services.ResultService;
using OnlineSurvey.Infrastructure.Data;
using OnlineSurvey.Infrastructure.Repositories.QuestionRepository;
using OnlineSurvey.Infrastructure.Repositories.ResultRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();

builder.Services.AddDbContext<OnlineSurveyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapGet("/api/question/{id:guid}", async (IQuestionService questionService, Guid id) =>
{
    var question = await questionService.GetQuestionById(id);
    return Results.Ok(question);
})
.Produces<QuestionResponse>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status500InternalServerError);

app.MapPost("api/result/", async (IResultService resultService, IQuestionService questionService, [FromBody] ResultDTO resultDTO) =>
{
    await resultService.CreateResult(resultDTO);

    var questionId = await questionService.GetNextQuestion(resultDTO.QuestionId);
    return Results.Ok(new { NextQuestionId = questionId });
});

app.Run();