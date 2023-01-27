using Microsoft.AspNetCore.Http;
using UserReviewsWebsiteAPI.Exceptions;

namespace UserReviewsWebsiteAPI.Middlewere
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (WrongPasswordException wrongPasswordException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(wrongPasswordException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (IncorrectlogindetailsException incorrectlogindetailsException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(incorrectlogindetailsException.Message);
            }
            catch (InaccessibleException inaccessibleException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(inaccessibleException.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
