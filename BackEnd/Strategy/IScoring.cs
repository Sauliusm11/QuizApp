namespace BackEnd.Strategy
{
    public interface IScoring
    {
        public int GetScore(string answer, string correctAnswer);
    }
}
