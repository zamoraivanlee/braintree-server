using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BraintreeServer.Exceptions;

namespace BraintreeServer.Filters;

public class HttpExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order { get; set; } = int.MaxValue - 10;

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpException exception)
        {
            context.ExceptionHandled = true;
            context.Result = new ObjectResult(exception.Value)
            {
                StatusCode = exception.StatusCode
            };
        }
    }

    public void OnActionExecuting(ActionExecutingContext context) { }
}
