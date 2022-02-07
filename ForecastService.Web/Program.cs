var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(Services.www7timer.ToString(), config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:7timer"]);
});

builder.Services.RegisterForecastServices();

var app = builder.Build();

app.UseExceptionHandler(handler =>
{
    handler.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
        await context.Response.WriteAsJsonAsync(exception.Message);
    });
});

app.UseHttpsRedirection();
app.RegisterForecastEndpoints();

app.Run();