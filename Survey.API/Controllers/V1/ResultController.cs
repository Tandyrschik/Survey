using Survey.BL.CRUD.V1.Result.CreateResult;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Survey.BL.RequestHandler;
using Survey.BL.ResponseResult;

namespace Survey.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/result")]
    public class ResultController(IHandler<Result<CreateResultResponse>, CreateResultRequest> createResultHandler) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateResultRequest request)
        {
            var response = await createResultHandler.HandleAsync(request);
            if (response.StatusCode == 201) return Created(string.Empty, response.Value);
            if (response.StatusCode == 204) return NoContent();

            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
