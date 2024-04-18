using WeatherForecast.Infrastructure;
using WeatherForecast.Infrastructure.Interfaces;
using WeatherForecast.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IWeatherInfoProvider, WeatherInfoProvider>();
builder.Services.AddSingleton<ISensorsFactory, SensorsFactory>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<CustomMiddleware>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapGet("task2/nsk/10Days", async context =>
    //{
    //    await context.Response.WriteAsync("Weather for 10 days will be fine. Good luck!");
    //});
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();