namespace Web.Modules;

/// <summary>
/// Module extension.
/// </summary>
public static class ModuleExtension
{
    static readonly List<IModule> registeredModules = new();

    /// <summary>
    /// Registers application modules.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>
    /// Updated service collection.
    /// </returns>
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        var modules = DiscoverModules();

        foreach (var module in modules)
        {
            module.RegisterServices(services);
            registeredModules.Add(module);
        }

        return services;
    }

    /// <summary>
    /// Maps the endpoints.
    /// </summary>
    /// <param name="app">Web application instance.</param>
    /// <returns>
    /// Update web application instance
    /// </returns>
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
            module.MapEndpoints(app);

        return app;
    }

    /// <summary>
    /// Discovers the modules.
    /// </summary>
    /// <returns>
    /// List of application modules.
    /// </returns>
    private static IEnumerable<IModule> DiscoverModules()
    {
        return typeof(IModule).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }
}
