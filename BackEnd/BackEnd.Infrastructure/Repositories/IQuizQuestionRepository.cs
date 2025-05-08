using BackEnd.Domain.Data.Entities.Questions;

namespace BackEnd.Infrastructure.Repositories
{
    public interface IQuizQuestionRepository
    {
        public List<QuizQuestion> GetQuizQuestions();
        public List<QuizQuestion> GetQuizAnswers();
    }
}
