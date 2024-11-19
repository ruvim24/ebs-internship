namespace API;

public class RedirectIfUnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectIfUnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 401 || context.Response.StatusCode == 403 || context.Response.StatusCode == 405 )
        {
            context.Response.Redirect("https://localhost:7277/login");
        }
    }
}
 