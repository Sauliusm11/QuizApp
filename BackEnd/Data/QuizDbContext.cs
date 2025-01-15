using BackEnd.Data.Entities;
using BackEnd.Data.Entities.Questions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackEnd.Data
{
    public class QuizDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        public DbSet<Score> Scores { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
    }
}
