using Newtonsoft.Json.Converters;

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
        services.AddSwaggerGen();
        services.AddSwaggerGenNewtonsoftSupport();
    }
}
