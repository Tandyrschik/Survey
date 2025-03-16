
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.DAL.Entity
{
    [PrimaryKey(nameof(AnswerId), nameof(ResultId))]
    [Table("AnswerResult")]
    public class AnswerResultEntity
    {
        public Guid AnswerId { get; set; }
        public Guid ResultId { get; set; }
        public AnswerEntity? Answer { get; set; }
        public ResultEntity? Result { get; set; }
    }
}
