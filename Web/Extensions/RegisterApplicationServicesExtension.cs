using API.Filters;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Modules.Locations;
using Domain.Constants;
using Domain.Enums;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

/// <summary>
/// Register application services extension.
/// </summary>
public static class RegisterApplicationServicesExtension
{
    /// <summary>
    /// Registers application services.
    /// </summary>
    /// <param name="services">Application services instance.</param>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        });

        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(Common.DbName));
        services.SeedData();

        var assembly = AppDomain.CurrentDomain.Load(Projects.Application.ToString());
        services.AddMediatR(assembly);
        services.AddAutoMapper(assembly);

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddTransient<ILocationsService, LocationsService>();
    }
}
