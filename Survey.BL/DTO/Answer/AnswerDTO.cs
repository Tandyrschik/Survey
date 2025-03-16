
namespace Survey.BL.DTO.Answer
{
    public class AnswerDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public int OrdinalNumber { get; set; } = 0;
    }
}
