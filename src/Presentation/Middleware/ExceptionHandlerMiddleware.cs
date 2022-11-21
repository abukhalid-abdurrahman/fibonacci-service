using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Presentation.Middleware;

public sealed class ExceptionHandlerMiddleware : ExceptionFilterAttribute
{
    public override Task OnExceptionAsync(ExceptionContext context)
    {
        var loggerService = context.HttpContext.RequestServices.GetService(typeof(ILogger<ExceptionHandlerMiddleware>)) as ILogger<ExceptionHandlerMiddleware>;
        if(loggerService != null)
            loggerService.LogError(context.Exception, "Some unhandled exception was detected. See exception message for more details.");

        var exceptionResponse = Response<object>.FailedResponse(ErrorCode.InternalError, "Some unhandled exception was detected.");
        context.Result = new JsonResult(exceptionResponse) { StatusCode = 200 };
        return Task.CompletedTask;
    }
}
