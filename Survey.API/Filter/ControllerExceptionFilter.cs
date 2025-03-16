using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Survey.API.Filter
{
    [AttributeUsage(AttributeTargets.All)]
    public class ControllerExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var _logger = context.HttpContext.RequestServices.GetService<ILogger<ControllerExceptionFilter>>()!;

            _logger.LogError($"Catched unhandled Exception, Message: {context.Exception.Message}, StackTrace: {context.Exception.StackTrace}");

            if (context.Exception.InnerException != null)
                _logger.LogError("Inner Exception: " + context.Exception.InnerException.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ContentResult
            {
                Content = $"Something went wrong... {context.Exception.Message}"
            };

        }
    }
}
