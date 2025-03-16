using Survey.BL.CRUD.V1.Survey.CreateSurvey;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;

namespace Survey.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/survey")]
    public class SurveyController(IHandler<Result<CreateSurveyResponse>, CreateSurveyRequest> createSurveyHandler) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateSurveyRequest request)
        {
            var response = await createSurveyHandler.HandleAsync(request);
            if (response.StatusCode == 201) return Ok(response.Value);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
