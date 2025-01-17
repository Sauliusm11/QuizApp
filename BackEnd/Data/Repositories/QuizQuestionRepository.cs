using BackEnd.Data.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEnd.Data.Repositories
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        private static QuizQuestionRepository instance;
        private static object threadLock = new object();

        public QuizQuestionRepository()
        {
            GetInstance();
        }
        public static QuizQuestionRepository GetInstance()
        {
            if (instance == null)
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new QuizQuestionRepository(false);
                    }
                }
            }
            return instance;
        }
        QuizQuestionRepository(bool bad)
        {
            using (var context = new QuizDbContext())
            {
                List<QuizQuestion> questions = new List<QuizQuestion>
                {
                    new QuizQuestion()
                    {
                        Id = 0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
                        Type = 0,
                        Question ="Mimic Logic: one of the answers is lying and the others are telling the truth. The lying one is the mimic - select the mimic",
                        CorrectAnswer ="1",
                        Answers = new List<string>()
                        {
                            "These questions are inspired by the game Mimic Logic",
                            "All answers are strictly related to finding the mimic",
                            "There is a mimic next to me",
                            "I am not a mimic"
                        }
                    },
                    new QuizQuestion()
                    {
                        Id=0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
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
                        Id=0,//0 makes it automatic
                        Type = 2,
                        Question ="Did I spend too much time coming up with these mimic logic questions? \n " +
                        "Please capitalize the first letter of your answer",
                        CorrectAnswer ="Probably",
                        Answers = new List<string>()
                    },
                    new QuizQuestion()
                    {
                        Id=0,//0 makes it automatic
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

        public List<QuizQuestion> GetQuizAnswers()
        {

            using (var context = new QuizDbContext())
            {
                var list = context.QuizQuestions
                    .Select(question => new QuizQuestion()
                    {
                        Id = question.Id,
                        Type = question.Type,
                        Question = question.Question,
                        Answers = question.Answers,
                        CorrectAnswer = question.CorrectAnswer
                    })
                    .ToList();

                return list;
            }
        }

        public List<QuizQuestion> GetQuizQuestions()
        {
            using (var context = new QuizDbContext())
            {
                var list = context.QuizQuestions
                    .Select(question => new QuizQuestion()
                    {
                        Id = question.Id,
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
