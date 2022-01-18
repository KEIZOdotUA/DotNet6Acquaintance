using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System.Reflection;

namespace API.Extensions;

/// <summary>
/// Register Swagger extension.
/// </summary>
public static class RegisterSwaggerExtension
{
    /// <summary>
    /// Registers Swagger in application services..
    /// </summary>
    /// <param name="services">Application services instance.</param>
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Weather API",
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        services.AddSwaggerGenNewtonsoftSupport();
    }
}
