using Survey.BL.CRUD.V1.Question.CreateQuestion;
using Survey.BL.CRUD.V1.Question.ReadQuestion;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;
using Azure;

namespace Survey.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/question")]
    public class QuestionController(IHandler<Result<CreateQuestionResponse>, CreateQuestionRequest> createQuestionHandler,
                                    IHandler<Result<ReadQuestionResponse>, ReadQuestionRequest> readQuestionHandler) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionRequest request)
        {
            var response = await createQuestionHandler.HandleAsync(request);
            if (response.StatusCode == 201) return Ok(response.Value);

            return StatusCode(response.StatusCode, response.Message);
        }
        [HttpGet]
        public async Task<ActionResult<ReadQuestionResponse>> Read([FromQuery] ReadQuestionRequest request)
        {
            var response = await readQuestionHandler.HandleAsync(request);
            if (response.StatusCode == 200) return Ok(response.Value);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
