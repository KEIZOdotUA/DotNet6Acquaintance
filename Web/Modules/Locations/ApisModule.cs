using Core.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Web.Modules.Locations;

public class ApisModule : IModule
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("MemoryDB"));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/locations", () => Array.Empty<string>())
        .WithName("Locations");

        return endpoints;
    }
}
