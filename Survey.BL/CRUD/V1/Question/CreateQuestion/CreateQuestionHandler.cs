using Survey.DAL.Entity;
using Survey.DAL.EF;
using Mapster;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;
using Microsoft.EntityFrameworkCore;

namespace Survey.BL.CRUD.V1.Question.CreateQuestion
{
    public class CreateQuestionHandler(PostgreSQLContext context) : IHandler<Result<CreateQuestionResponse>, CreateQuestionRequest>
    {
        public async Task<Result<CreateQuestionResponse>> HandleAsync(CreateQuestionRequest request)
        {
            var survey = await context.Surveys.AsNoTracking().FirstOrDefaultAsync(s => s.Id == request.SurveyId);
            if (survey == null) return Result<CreateQuestionResponse>.NotFound("Survey not found.");

            var entity = request.Adapt<QuestionEntity>();
            await context.Questions.AddAsync(entity);
            await context.SaveChangesAsync();

            return Result<CreateQuestionResponse>.Created(new CreateQuestionResponse { QuestionId = entity.Id });
        }
    }
}
