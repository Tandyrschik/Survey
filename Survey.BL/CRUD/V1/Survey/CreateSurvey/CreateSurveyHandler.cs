using Survey.DAL.Entity;
using Survey.DAL.EF;
using Mapster;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;

namespace Survey.BL.CRUD.V1.Survey.CreateSurvey
{
    public class CreateSurveyHandler(PostgreSQLContext context) : IHandler<Result<CreateSurveyResponse>, CreateSurveyRequest>
    {
        public async Task<Result<CreateSurveyResponse>> HandleAsync(CreateSurveyRequest request)
        {
            var entity = request.Adapt<SurveyEntity>();
            await context.Surveys.AddAsync(entity);
            await context.SaveChangesAsync();

            return Result<CreateSurveyResponse>.Created(new CreateSurveyResponse { SurveyId = entity.Id }); 
        }
    }
}
