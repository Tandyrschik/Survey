
using Survey.BL.CRUD.V1.Interview.CreateInterview;
using Survey.BL.CRUD.V1.Question.CreateQuestion;
using Survey.BL.CRUD.V1.Question.ReadQuestion;
using Survey.BL.CRUD.V1.Result.CreateResult;
using Survey.BL.CRUD.V1.Survey.CreateSurvey;
using Microsoft.EntityFrameworkCore;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;
using Asp.Versioning;
using Survey.DAL.EF;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Survey.API
{
    public static class ProgramExtentions
    {
        public static void AddAppHandlers(this IServiceCollection services)
        {
            #region Question
            services.AddScoped<IHandler<Result<CreateQuestionResponse>, CreateQuestionRequest>, CreateQuestionHandler>();
            services.AddScoped<IHandler<Result<ReadQuestionResponse>, ReadQuestionRequest>, ReadQuestionHandler>();
            #endregion


            #region Interview
            services.AddScoped<IHandler<Result<CreateInterviewResponse>, CreateInterviewRequest>, CreateInterviewHandler>();
            #endregion


            #region Result
            services.AddScoped<IHandler<Result<CreateResultResponse>, CreateResultRequest>, CreateResultHandler>();
            #endregion

            #region Survey
            services.AddScoped<IHandler<Result<CreateSurveyResponse>, CreateSurveyRequest>, CreateSurveyHandler>();
            #endregion
        }

        public static void AddAppVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void MigrateDatabase(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PostgreSQLContext>();
                context.Database.Migrate();
            }
        }
    }
}
