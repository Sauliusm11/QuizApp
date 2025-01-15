namespace BackEnd.Strategy
{
    public class ScoringContext
    {
        IScoring? scoringStrategy;

        public void SetScoringStrategy(IScoring scoringStrategy)
        {
            this.scoringStrategy = scoringStrategy;
        }

        public int GetScore(string answer, string correctAnswer)
        {
            Console.WriteLine(string.Format("Got {0} expected {1}",answer, correctAnswer));
            if(scoringStrategy == null)
            {
                return 0;
            }
            return scoringStrategy.GetScore(answer, correctAnswer);
        }
    }
}
