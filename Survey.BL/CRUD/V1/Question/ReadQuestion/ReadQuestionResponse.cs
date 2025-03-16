using Survey.BL.DTO.Answer;

namespace Survey.BL.CRUD.V1.Question.ReadQuestion
{
    public record ReadQuestionResponse
    {
        public Guid Id { get; set; }
        public required string Title { get; set; } 
        public string? Description { get; set; }
        public int OrdinalNumber { get; set; }
        public int NumberOfChoices { get; set; }
        public List<AnswerDTO>? Answers { get; set; }
    }
}