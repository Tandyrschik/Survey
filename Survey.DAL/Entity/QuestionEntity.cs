
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.DAL.Entity
{
    [Table("Question")]
    public class QuestionEntity : EntityBase
    {
        [Column(TypeName = "varchar(255)")]
        public required string Title { get; set; }
        [Column(TypeName = "text")]
        public string? Description { get; set; }
        public int NumberOfChoices { get; set; } = 1;
        public int OrdinalNumber { get; set; } = 0;

        #region relations
        public required Guid SurveyId { get; set; }
        public required SurveyEntity Survey { get; set; }
        public required List<AnswerEntity> Answers { get; set; }
        #endregion
    }
}
