
using Survey.BL.DTO.Answer;

namespace Survey.BL.CRUD.V1.Question.CreateQuestion
{
    public record CreateQuestionRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int NumberOfChoices { get; set; } = 1;
        public int OrdinalNumber { get; set; } = 0;
        public required Guid SurveyId { get; set; }
        public required List<AnswerDTO> Answers { get; set; }
    }
}
