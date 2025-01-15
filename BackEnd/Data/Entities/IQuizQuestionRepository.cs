using BackEnd.Data.Entities.Questions;

namespace BackEnd.Data.Entities
{
    public interface IQuizQuestionRepository
    {
       public List<QuizQuestion> GetQuizQuestions();
    }
}
