namespace Web.Modules
{
    /// <summary>
    /// Module interface.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Registers the modules.
        /// </summary>
        /// <param name="builder">Service collection builder.</param>
        /// <returns></returns>
        IServiceCollection RegisterModules(IServiceCollection builder);

        /// <summary>
        /// Maps the endpoints.
        /// </summary>
        /// <param name="endpoints">The endpoints.</param>
        /// <returns></returns>
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    }
}
