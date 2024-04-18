namespace WeatherForecast.Middlewares;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var rootParts = httpContext.Request.Path.Value?.Split('/');
        var controller = rootParts?.Length > 3 ? rootParts[1] : null;
        var method = rootParts?.Length > 3 ? rootParts[3] : null;

        if (controller == "task2" &&
            httpContext.Request.Query.ContainsKey("days") &&
            httpContext.Request.Query["days"] == "10")
            httpContext.Response.Redirect($"/{controller}/nsk/10Days");

        await _next(httpContext);

        if (method == "extendedDaily")
        {
            var promocode = Guid.NewGuid().ToString()[..10];
            await httpContext.Response.WriteAsync(string.Join(' ', Constants.Constants.CoffeeMessage, promocode));
        }
    }
}