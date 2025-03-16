
using Survey.BL.DTO.Question;

namespace Survey.BL.CRUD.V1.Interview.CreateInterview
{
    public record CreateInterviewResponse
    {
        public Guid InterviewId { get; set; }
        public required QuestionDTO Question { get; set; }
    }
}
