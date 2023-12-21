using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Filters.ActionFilters
{
    public class Book_ValidateBookIDFilterAttribute : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var bookID = context.ActionArguments["ID"] as int?;
            if (bookID.HasValue)
            {
                if (bookID.Value <= 0)
                {
                    context.ModelState.AddModelError("BookID", "BookID is invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!BookRepository.BookExists(bookID.Value))
                {
                    context.ModelState.AddModelError("BookID", "Book doesn't exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
