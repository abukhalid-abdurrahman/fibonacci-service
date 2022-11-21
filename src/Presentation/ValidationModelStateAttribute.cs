using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation;

public sealed class ValidationModelStateAttribute : ActionFilterAttribute
{
   public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                    .Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToArray();

            var badRequestResponse = Response<object>
                .FailedResponse(ErrorCode.BadRequest, errorMessages: errors);

            context.Result = new JsonResult(badRequestResponse) { StatusCode = 200 };
        }
    } 
}
