using BackEnd.Data.Entities;
using BackEnd.Data.Entities.Questions;

namespace BackEnd.Data.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        public ScoreRepository() 
        {
        
        }

        public void AddScore(int score, string email)
        {
            using (var context = new QuizDbContext())
            {
                Score scoreToAdd = new Score
                {
                    Id = 0,
                    DateTime = DateTime.Now,
                    Email = email,
                    Points = score
                };
                context.Scores.Add(scoreToAdd);
                context.SaveChanges();
            }
        }

        public List<Score> GetScores()
        {
            using (var context = new QuizDbContext())
            {
                var list = context.Scores
                    .Select(score => new Score()
                    {
                        Id = score.Id,
                        Points = score.Points,
                        DateTime = score.DateTime,
                        Email = score.Email
                    }).OrderBy(score => score.Points).Reverse()
                    .ToList();

                return list;
            }
        }
    }
}
