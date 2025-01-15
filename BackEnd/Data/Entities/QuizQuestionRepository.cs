
using BackEnd.Data.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEnd.Data.Entities
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        public QuizQuestionRepository() 
        {
            using (var context = new QuizDbContext())
            {
                List<QuizQuestion> questions = new List<QuizQuestion>
                {
                    new QuizQuestion()
                    {
                        id = 0,//0 makes it automatic
                        Type = 0,
                        Question ="Mimic Logic: one of the answers is lying and the others are telling the truth. The lying one is the mimic - select the mimic",
                        CorrectAnswer ="0",
                        Answers = new List<string>()
                        {
                            "I am not the mimic",
                            "The answer above me is the mimic",
                            "The first answer is the mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 0,
                        Question ="Mimic Logic: one of the answers is lying and the others are telling the truth. The lying one is the mimic - select the mimic",
                        CorrectAnswer ="0",
                        Answers = new List<string>()
                        {
                            "The last answer is the mimic",
                            "I am next to a mimic",
                            "There are four options in this question",
                            "The first answer is the mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 0,
                        Question ="Mimic Logic: one of the answers is lying and the others are telling the truth. The lying one is the mimic - select the mimic",
                        CorrectAnswer ="1",
                        Answers = new List<string>()
                        {
                            "These questions are inspired by the game Mimic Logic",
                            "All answers are helpful to finding the mimic",
                            "There is a mimic next to me",
                            "I am not a mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 0,
                        Question ="Mimic Logic: one of the answers is lying and the others are telling the truth. The lying one is the mimic - select the mimic",
                        CorrectAnswer ="3",
                        Answers = new List<string>()
                        {
                            "This is the final single answer question",
                            "Randomizing the order of answers would break the question",
                            "There is a mimic next to me",
                            "The order of answers is randomized"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 1,
                        Question ="Mimic Logic hard mode: one(or more) of the answers is lying and the others are telling the truth. The lying answers are the mimic - select all mimics",
                        CorrectAnswer ="0,2",
                        Answers = new List<string>()
                        {
                            "There are no mimics",
                            "There are two mimics",
                            "I am surrounded by mimics",
                            "The answer above me is a mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 1,
                        Question ="Mimic Logic hard mode: one(or more) of the answers is lying and the others are telling the truth. The lying answers are the mimic - select all mimics",
                        CorrectAnswer ="0,1,3",
                        Answers = new List<string>()
                        {
                            "There are no mimics",
                            "There are less than three mimics",
                            "I am surrounded by mimics",
                            "There is only one mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 1,
                        Question ="Mimic Logic hard mode: one(or more) of the answers is lying and the others are telling the truth. The lying answers are the mimic - select all mimics",
                        CorrectAnswer ="2",
                        Answers = new List<string>()
                        {
                            "There is only one mimic",
                            "There is a mimic next to me",
                            "There are exactly two mimics",
                            "There is only one mimic",
                            "The answer above me is not a mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 1,
                        Question ="Mimic Logic hard mode: one(or more) of the answers is lying and the others are telling the truth. The lying answers are the mimic - select all mimics",
                        CorrectAnswer ="0,3,4",
                        Answers = new List<string>()
                        {
                            "Everyone is a mimic",
                            "There is a mimic next to me",
                            "There is more than one mimic",
                            "There is only one mimic",
                            "The answer above me is not a mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 2,
                        Question ="Did I spend too much time coming up with these mimic logic questions? \n " +
                        "Please capitalize the first letter of your answer",
                        CorrectAnswer ="Probably",
                        Answers = new List<string>()
                    },
                    new QuizQuestion()
                    {
                        id=0,//0 makes it automatic
                        Type = 2,
                        Question ="But was it fun? \n " +
                        "Please capitalize the first letter of your answer",
                        CorrectAnswer ="Yes",
                        Answers = new List<string>()
                    }
                };
                context.QuizQuestions.AddRange(questions);
                context.SaveChanges();
            }
        }

        public List<QuizQuestion> GetQuizQuestions()
        {
            using (var context = new QuizDbContext())
            {
                var list = context.QuizQuestions
                    .Select(question => new QuizQuestion()
                    {
                        id = question.id,
                        Type = question.Type,
                        Question = question.Question,
                        Answers = question.Answers,
                        CorrectAnswer = ""
                    })
                    .ToList();

                return list;
            }
        }
    }
}
