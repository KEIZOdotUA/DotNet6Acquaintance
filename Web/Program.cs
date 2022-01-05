using Web.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterModules();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();