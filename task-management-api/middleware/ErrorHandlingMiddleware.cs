using task_management_api.exceptions;

namespace task_management_api.middleware
{
    /// <summary>
    /// ASP.NET Core middleware component that handles exceptions thrown during request processing.
    /// </summary>
    public class ErrorHandlingMiddleware : IMiddleware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlingMiddleware"/> class.
        /// </summary>
        public ErrorHandlingMiddleware()
        {
            
        }

        /// <summary>
        /// Processes an incoming HTTP request and applies error handling logic.
        /// </summary>
        /// <param name="context">The current HTTP context.</param>
        /// <param name="next">The next delegate in the middleware pipeline.</param>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                /// <remarks>
                /// Invokes the next delegate in the middleware pipeline, which typically represents the actual request processing logic.
                /// </remarks>
                await next.Invoke(context);
            }
            catch(NotFoundException e) 
            {
                /// <summary>
                /// Catches instances of the <see cref="NotFoundException"/> and sets the response status code and message accordingly.
                /// </summary>
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsync(e.Message);
            }
            catch(BadRequestException e)
            {
                /// <summary>
                /// Catches instances of the <see cref="BadRequestException"/> and sets the response status code and message accordingly.
                /// </summary>
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e) 
            {
                /// <summary>
                /// Catches any other unhandled exceptions and sets a generic error message with a 500 Internal Server Error status code.
                /// </summary>
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong...");
            }
        }
    }
}
