namespace Web.Modules;

/// <summary>
/// Module interface.
/// </summary>
public interface IModule
{
    /// <summary>
    /// Registers the services.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <returns>
    /// Services collection with new services.
    /// </returns>
    IServiceCollection RegisterServices(IServiceCollection services);

    /// <summary>
    /// Maps the endpoints.
    /// </summary>
    /// <param name="endpoints">Endpoints builder.</param>
    /// <returns>
    /// Mapped endpoints.
    /// </returns>
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
