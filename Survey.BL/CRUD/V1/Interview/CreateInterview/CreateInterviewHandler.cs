using Microsoft.EntityFrameworkCore;
using Survey.BL.DTO.Question;
using Survey.DAL.Entity;
using Survey.DAL.EF;
using Mapster;
using Survey.BL.ResponseResult;
using Survey.BL.RequestHandler;

namespace Survey.BL.CRUD.V1.Interview.CreateInterview
{
    public class CreateInterviewHandler(PostgreSQLContext context) : IHandler<Result<CreateInterviewResponse>, CreateInterviewRequest>
    {
        public async Task<Result<CreateInterviewResponse>> HandleAsync(CreateInterviewRequest request)
        {
            var survey = await context.Surveys.AsNoTracking().FirstOrDefaultAsync(s => s.Id == request.SurveyId);
            if (survey == null) return Result<CreateInterviewResponse>.NotFound("Survey not found.");

            var interview = request.Adapt<InterviewEntity>();
            await context.Interviews.AddAsync(interview);
            await context.SaveChangesAsync();

            var question = await context.Questions
                .Include(q => q.Answers.OrderBy(a => a.OrdinalNumber))
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.SurveyId == request.SurveyId && q.OrdinalNumber == 0);

            var response = new CreateInterviewResponse()
            {
                InterviewId = interview.Id,
                Question = question.Adapt<QuestionDTO>()
            };

            return Result<CreateInterviewResponse>.Created(response);
        }
    }
}
