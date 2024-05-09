namespace Api.net.Middlewears
{
    public class TimeMiddleware
{
	private readonly RequestDelegate _next;

	public TimeMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		await _next(context);
		if (context.Request.Query.Any(x => x.Key == "time"))
		{
			await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());

		}
	}
}

public static class TimeMiddlewareExtensions
{
	public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<TimeMiddleware>();
	}
}
}