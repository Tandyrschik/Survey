
namespace Survey.BL.CRUD.V1.Result.CreateResult
{
    public record CreateResultRequest
    {
        public Guid InterviewId { get; set; }
        public Guid QuestionId { get; set; }
        public required List<Guid> AnswerIds { get; set; }
    }
}
