using BackEnd.Domain.Data.Entities.Questions;

namespace BackEnd.Domain.Scoring
{
    public class Scoring
    {

        public static int GetScore(IList<string> answers, IList<QuizQuestion> quizQuestions)
        {
            int score = 0;
            for (int i = 0; i < quizQuestions.Count; i++) 
            {
                if (quizQuestions[i].Type != 1)
                {
                    score += GetScoreSingle(answers[i], quizQuestions[i].CorrectAnswer);
                }
                else
                {
                    score += GetScoreMulti(answers[i], quizQuestions[i].CorrectAnswer);
                }
            }
            return score;
        }
        private static int GetScoreSingle(string answer, string correctAnswer)
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

        private static int GetScoreMulti(string answer, string correctAnswer)
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
            return (int)MathF.Ceiling(((float)100 / correctAnswers.Length) * answeredCorrectly);
        }
    }
}
