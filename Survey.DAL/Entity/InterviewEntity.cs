
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.DAL.Entity
{
    [Table("Interview")]
    public class InterviewEntity : EntityBase
    {
        public required Guid SurveyId { get; set; }
        public required SurveyEntity Survey { get; set; }
        public required List<ResultEntity> Results { get; set; }
    }
}
