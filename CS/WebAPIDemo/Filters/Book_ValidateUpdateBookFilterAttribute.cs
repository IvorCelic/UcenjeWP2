using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Models;

namespace WebAPIDemo.Filters
{
    public class Book_ValidateUpdateBookFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ID = context.ActionArguments["ID"] as int?;
            var book = context.ActionArguments["book"] as Book;

            if (ID.HasValue && book != null && ID != book.BookID)
            {
                context.ModelState.AddModelError("BookID", "BookID is not the same as ID.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
