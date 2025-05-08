using BackEnd.Domain.Data.Entities.Questions;

namespace BackEnd.Domain.Scoring
{
    public class Scoring
    {
        private const int maxScoreAnswer = 100;
        private const int incorrectScoreAnswer = 0;//only for single choice and text

        /// <summary>
        /// Gets the total score of a submission
        /// </summary>
        /// <param name="answers"> List of answers provided by the user </param>
        /// <param name="quizQuestions"> List of quiz questions with the correct answers</param>
        /// <returns>The total score of a submission</returns>
        public static int GetScore(IList<string> answers, IList<QuizQuestion> quizQuestions)
        {
            int score = 0;
            for (int i = 0; i < quizQuestions.Count; i++) 
            {
                if (quizQuestions[i].Type != QuestionType.Multiple)
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
        /// <summary>
        /// Calculates the score for questions where there is one exact answer
        /// </summary>
        /// <param name="answer">Answer submitted by the user</param>
        /// <param name="correctAnswer">Expected answer to the question</param>
        /// <returns>The score given for the answer</returns>
        private static int GetScoreSingle(string answer, string correctAnswer)
        {
            if (answer.Equals(correctAnswer))
            {
                return maxScoreAnswer;
            }
            else
            {
                return incorrectScoreAnswer;
            }
        }
        /// Calculates the score for questions where there is more than one answer
        /// </summary>
        /// <param name="answer">Comma separated answers submitted by the user</param>
        /// <param name="correctAnswer">Comma separated expected answers to the question</param>
        /// <returns>The score given for the answers</returns>
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
            return (int)MathF.Ceiling(((float)maxScoreAnswer / correctAnswers.Length) * answeredCorrectly);
        }
    }
}
