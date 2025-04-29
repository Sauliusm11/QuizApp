namespace BackEnd.Data.Entities.Questions
{
    public class QuizQuestion
    {
        public required int Id { get; set; }
        //Different questions types are only different in how their answers are handled,
        //probably not worth having different classes for that
        public required int Type { get; set; }
        public required string Question { get; set; }
        public required string CorrectAnswer { get; set; }
        public required List<string> Answers { get; set; }
    }
}
