
using Microsoft.EntityFrameworkCore;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;
using Survey.DAL.EF;
using Mapster;

namespace Survey.BL.CRUD.V1.Question.ReadQuestion
{
    public class ReadQuestionHandler(PostgreSQLContext context) : IHandler<Result<ReadQuestionResponse>, ReadQuestionRequest>
    {
        public async Task<Result<ReadQuestionResponse>> HandleAsync(ReadQuestionRequest request)
        {
            var question = await context.Questions
                .Include(q => q.Answers.OrderBy(a => a.OrdinalNumber))
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.SurveyId == request.SurveyId && q.OrdinalNumber == request.OrdinalNumber);
            if (question == null) return Result<ReadQuestionResponse>.NotFound("Question not found.");

            return Result<ReadQuestionResponse>.Created(question.Adapt<ReadQuestionResponse>());
        }
    }
}
