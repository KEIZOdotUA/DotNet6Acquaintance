var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterDb();
builder.Services.RegisterLocationsServices();

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
app.RegisterLocationsEndpoints();

app.Run();