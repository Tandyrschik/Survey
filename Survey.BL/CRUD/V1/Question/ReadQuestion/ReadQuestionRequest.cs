namespace Survey.BL.CRUD.V1.Question.ReadQuestion
{
    public record ReadQuestionRequest
    {
        public Guid SurveyId { get; set; }
        public int OrdinalNumber { get; set; } = 0;
    }
}
