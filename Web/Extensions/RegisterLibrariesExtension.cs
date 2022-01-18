namespace API.Extensions;

/// <summary>
/// Register application libraries extension.
/// </summary>
public static class RegisterLibrariesExtension
{
    /// <summary>
    /// Registers application libraries.
    /// </summary>
    /// <param name="services">Application services instance.</param>
    public static void RegisterLibraries(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load(Projects.Application.ToString());
        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);
    }
}
