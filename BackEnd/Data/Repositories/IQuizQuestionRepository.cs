using BackEnd.Data.Entities.Questions;

namespace BackEnd.Data.Repositories
{
    public interface IQuizQuestionRepository
    {
        public List<QuizQuestion> GetQuizQuestions();
        public List<QuizQuestion> GetQuizAnswers();
    }
}
