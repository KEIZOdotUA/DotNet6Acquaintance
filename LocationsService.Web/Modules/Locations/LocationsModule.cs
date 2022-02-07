namespace LocationsService.Web.Modules.Locations;

public static class LocationsModule
{
    public static void RegisterLocationsServices(this IServiceCollection services)
    {
        services.AddTransient<IRepository, Repository>();
        services.AddTransient<IService, Service>();
    }

    public static void RegisterLocationsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/", async (IService service, LocationDetailsDto details) =>
        {
            var result = await service.CreateAsync(details);
            return result;
        });

        endpoints.MapGet("/", async (IService service) => {
            var result = await service.GetAllAsync();
            return result;
        });

        endpoints.MapGet("/{id}", async (IService service, Guid id) => {
            var result = await service.GetAsync(id);
            return result;
        });

        endpoints.MapPut("/{id}", async (IService service, Guid id, LocationDetailsDto details) => {
            await service.UpdateAsync(id, details);
        });

        endpoints.MapDelete("/{id}", async (IService service, Guid id) => {
            await service.DeleteAsync(id);
        });

        endpoints.MapGet("/coordinates/{id}", async (IService service, Guid id) => {
            var result = await service.GetCoordinatesAsync(id);
            return result;
        });
    }
}
