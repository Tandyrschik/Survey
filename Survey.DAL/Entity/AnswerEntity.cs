
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.DAL.Entity
{
    [Table("Answer")]
    public class AnswerEntity : EntityBase
    {
        [Column(TypeName = "varchar(255)")]
        public required string Title { get; set; }
        public int OrdinalNumber { get; set; } = 0;

        #region relations
        public required Guid QuestionId { get; set; }
        public required QuestionEntity Question { get; set; }
        public List<ResultEntity>? Results { get; set; }  
        public List<AnswerResultEntity>? AnswerResults { get; set; }
        #endregion
    }
}
