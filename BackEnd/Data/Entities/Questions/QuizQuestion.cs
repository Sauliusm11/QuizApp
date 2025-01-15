using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Entities.Questions
{
    public class QuizQuestion
    {
        public required int id { get; set; }
        public required int Type { get; set; }
        public required string Question { get; set; }
        public required string CorrectAnswer { get; set; }
        public required List<string> Answers { get; set; }
    }
}
