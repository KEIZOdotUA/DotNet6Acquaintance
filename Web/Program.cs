using API.Extensions;
using API.Filters;
using Domain.Constants;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); });
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(Common.DbName));
builder.Services.SeedData();
builder.Services.RegisterLibraries();
builder.Services.RegisterServices();
builder.Services.RegisterSwagger();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();