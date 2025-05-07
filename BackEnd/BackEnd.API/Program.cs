using BackEnd.Domain.Data.Dtos;
using BackEnd.Infrastructure.Repositories;
using BackEnd.Domain.Data.Dtos.Validators;
using FluentValidation;
using FluentValidation.Results;
using BackEnd.Domain.Scoring;

namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adding in memory db repositories
            builder.Services.AddScoped<IQuizQuestionRepository, QuizQuestionRepository>();
            builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Get request handling for receiving questions
            app.MapGet("/quizQuestions", (HttpContext httpContext, IQuizQuestionRepository quizQuestionRepository) =>
            {
                //Pull questions from db without correct answers
                var quizQuestions = quizQuestionRepository.GetQuizQuestions();
                if (quizQuestions == null || quizQuestions.Count == 0)
                {
                    return Results.NoContent();
                }

                return Results.Ok(quizQuestions);
            })
            .WithName("GetQuizQuestions")
            .WithOpenApi();

            //Post request handling for submitting answers
            app.MapPost("/quizSubmit", (HttpContext httpContext, IQuizQuestionRepository quizQuestionRepository, CreateScoreDto createScoreDto, IScoreRepository scoreRepository) =>
            {
                CreateScoreDtoValidator validator = new CreateScoreDtoValidator();
                //Validate if email is valid and answers are not empty
                ValidationResult validationResult = validator.Validate(createScoreDto);
                if (validationResult.IsValid) { 
                    //Pull questions from db, this time with correct answers
                    var quizQuestions = quizQuestionRepository.GetQuizAnswers();
                    //Should never happen realistically 
                    if (quizQuestions == null || quizQuestions.Count == 0)
                    {
                        return Results.NoContent();
                    }
                    string[] answers = createScoreDto.Answers;
                    int score = Scoring.GetScore(answers, quizQuestions);
                    scoreRepository.AddScore(score, createScoreDto.Email);
                    return Results.Ok(score);
                }
                else
                {
                    return Results.BadRequest();
                }
            })
            .WithName("PostQuizAnswers")
            .WithOpenApi();

            //Get request handling for receiving high scores
            app.MapGet("/scores", (HttpContext httpContext, IScoreRepository scoreRepository) =>
            {
                var scores = scoreRepository.GetScores();
                if (scores == null || scores.Count == 0)
                {
                    return Results.NoContent();
                }

                return Results.Ok(scores);
            })
            .WithName("GetScores")
            .WithOpenApi();

            app.Run();
        }
    }
}
