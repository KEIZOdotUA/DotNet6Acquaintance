var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(Services.Forecast.ToString(), config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Forecast"]);
});
builder.Services.AddHttpClient(Services.Locations.ToString(), config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Locations"]);
});

builder.Services.RegisterServices();
builder.Services.RegisterSwagger();

var app = builder.Build();
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(
        builder.Configuration["Swagger:Path"],
        builder.Configuration["Swagger:Name"]);
    c.RoutePrefix = String.Empty;
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
