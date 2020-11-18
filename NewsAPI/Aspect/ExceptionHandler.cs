using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Exceptions;

namespace NewsAPI.Aspect
{
    public class ExceptionHandler:ExceptionFilterAttribute
    {
        /* Inherit the ExceptionFilterAttribute */

        /*Override the method OnException uisng ExceptionFilterAttribute to handle the exceptions.
        */
        public override void OnException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            var message = context.Exception.Message;
            if(type==typeof(UserAlreadyExistsException)||type==typeof(NewsAlreadyExistsException)||type==typeof(ReminderAlreadyExistsException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else if (type == typeof(UserNotFoundException) || type == typeof(NewsNotFoundException) || type == typeof(ReminderNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
