using Survey.BL.CRUD.V1.Interview.CreateInterview;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;

namespace Survey.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/interview")]
    public class InterviewController(IHandler<Result<CreateInterviewResponse>, CreateInterviewRequest> createInterviewHandler) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateInterviewRequest request)
        {
            var response = await createInterviewHandler.HandleAsync(request);
            if(response.StatusCode == 201) return Created(string.Empty, response.Value);

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
