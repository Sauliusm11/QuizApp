namespace BackEnd.Strategy
{
    public class SimpleScoring : IScoring
    {
        public int GetScore(string answer, string correctAnswer)
        {
            if (answer.Equals(correctAnswer))
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }
    }
}
