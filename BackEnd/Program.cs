
using BackEnd.Data.Entities;
using System.Security.Cryptography.X509Certificates;

namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IQuizQuestionRepository, QuizQuestionRepository>();
            // Add services to the container.
            builder.Services.AddAuthorization();

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

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapGet("/quizQuestions", (HttpContext httpContext, IQuizQuestionRepository quizQuestionRepository) =>
            {
                var quizQuestions = quizQuestionRepository.GetQuizQuestions();
                if (quizQuestions == null || !quizQuestions.Any())
                {
                    return Results.NoContent();
                }

                return Results.Ok(quizQuestions);
            })
            .WithName("GetQuizQuestions")
            .WithOpenApi();

            app.MapPost("/quizSubmit", (HttpContext httpContext, IQuizQuestionRepository quizQuestionRepository) =>
            {
                var quizQuestions = quizQuestionRepository.GetQuizQuestions();
                if (quizQuestions == null || !quizQuestions.Any())
                {
                    return Results.NoContent();
                }

                return Results.Ok(quizQuestions);
            })
            .WithName("PostQuizAnswers")
            .WithOpenApi();

            app.Run();
        }
    }
}
