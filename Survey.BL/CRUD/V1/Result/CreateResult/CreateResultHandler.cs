
using Microsoft.EntityFrameworkCore;
using Survey.DAL.Entity;
using Survey.DAL.EF;
using Mapster;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;
using Survey.BL.CRUD.V1.Question.ReadQuestion;

namespace Survey.BL.CRUD.V1.Result.CreateResult
{
    public class CreateResultHandler(PostgreSQLContext context) : IHandler<Result<CreateResultResponse>, CreateResultRequest>
    {
        public async Task<Result<CreateResultResponse>> HandleAsync(CreateResultRequest request)
        {
            var interview = await context.Interviews
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.InterviewId);
            if (interview == null) return Result<CreateResultResponse>.NotFound("Interview not found.");

            var question = await context.Questions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.QuestionId);
            if (question == null) return Result<CreateResultResponse>.NotFound("Question not found.");

            var result = request.Adapt<ResultEntity>();

            var answerResults = new List<AnswerResultEntity>();
            foreach (var answerId in request.AnswerIds)
            {
                var answer = await context.Answers
                    .FirstOrDefaultAsync(x => x.Id == answerId);
                if (answer == null) return Result<CreateResultResponse>.NotFound($"Answer {answerId} not found.");

                answerResults.Add(new AnswerResultEntity { AnswerId = answerId, ResultId = result.Id });
            }

            result.AnswerResults = answerResults;
            await context.Results.AddAsync(result);
            await context.SaveChangesAsync();

            var nextQuestion = await context.Questions
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.SurveyId == interview.SurveyId && q.OrdinalNumber == question.OrdinalNumber + 1);
            if (nextQuestion != null)
            return Result<CreateResultResponse>.Created(new CreateResultResponse { NextQuestionId = nextQuestion.Id });

            return Result<CreateResultResponse>.NoContent();
        }
    }
}
