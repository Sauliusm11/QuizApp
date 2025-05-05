using BackEnd.Data.Entities;

namespace BackEnd.Data.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        public ScoreRepository() 
        {
        
        }
        /// <summary>
        /// Add a score to the repository
        /// </summary>
        /// <param name="score">Total score(calculated internaly)</param>
        /// <param name="email">Email (provided by user)</param>
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
                    .Take(10)
                    .ToList();

                return list;
            }
        }
    }
}
