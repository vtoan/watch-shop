using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Application.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var ex = context.Exception;
                var problem = new ProblemDetails()
                {
                    Detail = ex.Message,
                    Status = 500,
                    Title = "Error",
                    Instance = context.HttpContext.Request.Path
                };
                context.Result = new JsonResult(problem);
                context.ExceptionHandled = true;
            }
        }
    }
}