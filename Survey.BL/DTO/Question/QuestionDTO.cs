
using Survey.BL.DTO.Answer;

namespace Survey.BL.DTO.Question
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int OrdinalNumber { get; set; } = 1;
        public int NumberOfChoices { get; set; } = 0;
        public List<AnswerDTO>? Answers { get; set; }
    }
}
