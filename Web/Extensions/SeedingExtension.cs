using Infrastructure.Persistance;
using Infrastructure.Persistance.Seeding;

namespace API.Extensions;

/// <summary>
/// Data seeding extension.
/// </summary>
public static class SeedingExtension
{
    /// <summary>
    /// Seeds the data.
    /// </summary>
    /// <param name="services">Application services collection.</param>
    public static void SeedData(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        DataInitializer.SeedData(context).Wait();
    }
}
