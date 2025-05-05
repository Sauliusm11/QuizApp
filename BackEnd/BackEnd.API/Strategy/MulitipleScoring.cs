namespace BackEnd.Strategy
{
    public class MulitipleScoring : IScoring
    {
        public int GetScore(string answer, string correctAnswer)
        {
            string[] answers = answer.Split(",");
            string[] correctAnswers = correctAnswer.Split(",");
            int answeredCorrectly = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                for (int j = 0; j < correctAnswers.Length; j++)
                {
                    if (answers[i].Equals(correctAnswers[j]))
                    {
                        answeredCorrectly++;
                        break;
                    }
                }
            }
            //( 100 / good answers) * correctly checked. No decimal points, rounded up.
            return (int)MathF.Ceiling(((float)100 /correctAnswers.Length)*answeredCorrectly);
        }
    }
}
