
namespace Survey.BL.CRUD.V1.Survey.CreateSurvey
{
    public record CreateSurveyRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
