using BackEnd.Data.Entities.Questions;
using BackEnd;
namespace BackEnd.Infrastructure.Repositories
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        //GetInstance ensures that the instance is never null when exiting constructor
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static QuizQuestionRepository instance;
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static object threadLock = new object();

        /// <summary>
        /// Public constructor, used by builder.Services.AddScoped
        /// </summary>
        public QuizQuestionRepository()
        {
            GetInstance();
        }
        /// <summary>
        /// The intended way of getting the repository, prevents duplication of entries
        /// </summary>
        /// <returns></returns>
        public QuizQuestionRepository GetInstance()
        {
            if (instance == null)
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = this;
                        using var context = new QuizDbContext();
                        context.SeedQuestions();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Get quiz questions with answers
        /// </summary>
        /// <returns>Quiz questions with answers</returns>
        public List<QuizQuestion> GetQuizAnswers()
        {
            using var context = new QuizDbContext();
            var list = context.QuizQuestions
                .Select(question => new QuizQuestion()
                {
                    Id = question.Id,
                    Type = question.Type,
                    Question = question.Question,
                    Answers = question.Answers,
                    CorrectAnswer = question.CorrectAnswer
                })
                .ToList();

            return list;
        }
        /// <summary>
        /// Get quiz questions without answers
        /// </summary>
        /// <returns>Quiz questions without answers</returns>
        public List<QuizQuestion> GetQuizQuestions()
        {
            using var context = new QuizDbContext();
            var list = context.QuizQuestions
                .Select(question => new QuizQuestion()
                {
                    Id = question.Id,
                    Type = question.Type,
                    Question = question.Question,
                    Answers = question.Answers,
                    CorrectAnswer = ""
                })
                .ToList();

            return list;
        }
    }
}
