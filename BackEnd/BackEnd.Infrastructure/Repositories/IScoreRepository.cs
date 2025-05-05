using BackEnd.Data.Entities;

namespace BackEnd.Data.Repositories
{
    public interface IScoreRepository
    {
        public void AddScore(int score, string email);
        public List<Score> GetScores();
    }
}
