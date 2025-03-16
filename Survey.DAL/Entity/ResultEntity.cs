
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.DAL.Entity
{
    [Table("Result")]
    public class ResultEntity : EntityBase
    {
        public required Guid InterviewId { get; set; }
        public required InterviewEntity Interview { get; set; }
        public required Guid QuestionId { get; set; }
        public required QuestionEntity Question { get; set; }
        public List<AnswerEntity>? Answers { get; set; }
        public List<AnswerResultEntity>? AnswerResults { get; set; }
    }
}
