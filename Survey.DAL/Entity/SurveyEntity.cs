
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.DAL.Entity
{
    [Table("Survey")]
    [Index(nameof(Title), IsUnique = true)]
    public class SurveyEntity : EntityBase
    {
        [Column(TypeName = "varchar(255)")]
        public required string Title { get; set; }
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        #region relations
        public List<QuestionEntity>? Questions { get; set; }
        public List<InterviewEntity>? Interviews { get; set; }
        #endregion
    }
}
