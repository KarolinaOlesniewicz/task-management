using task_management_api.exceptions;

namespace task_management_api.middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public ErrorHandlingMiddleware()
        {
            
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException e) 
            {
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsync(e.Message);
            }
            catch(BadRequestException e)
            {
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e) 
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong...");
            }
        }
    }
}
