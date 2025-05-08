using BackEnd.Domain.Data.Entities;

namespace BackEnd.Infrastructure.Repositories
{
    public interface IScoreRepository
    {
        public void AddScore(int score, string email);
        public List<Score> GetScores();
    }
}
