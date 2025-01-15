using BackEnd.Data.Entities;
using BackEnd.Data.Entities.Questions;

namespace BackEnd.Data.Repositories
{
    public interface IScoreRepository
    {
        public void AddScore(int score, string email);
        public List<Score> GetScores();
    }
}
