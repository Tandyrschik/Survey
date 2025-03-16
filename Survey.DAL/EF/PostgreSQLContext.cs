
using Microsoft.EntityFrameworkCore;
using Survey.DAL.Entity;

namespace Survey.DAL.EF
{
    public class PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerEntity>()
                .HasMany(e => e.Results)
                .WithMany(e => e.Answers)
                .UsingEntity<AnswerResultEntity>();
        }
        public DbSet<SurveyEntity> Surveys { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }
        public DbSet<InterviewEntity> Interviews { get; set; }
        public DbSet<ResultEntity> Results { get; set; }
    }
}
