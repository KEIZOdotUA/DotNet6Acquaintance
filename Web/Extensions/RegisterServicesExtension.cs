using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Modules.Locations;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Www7timer;


namespace API.Extensions;

/// <summary>
/// Register application services extension.
/// </summary>
public static class RegisterServicesExtension
{
    /// <summary>
    /// Registers application services.
    /// </summary>
    /// <param name="services">Application services instance.</param>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddTransient<ILocationsService, LocationsService>();
        services.AddTransient<IWww7timerService, Www7timerService>();
    }
}
