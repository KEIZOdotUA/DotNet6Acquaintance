using Newtonsoft.Json;

namespace Infrastructure.Persistance.Seeding;

/// <summary>
/// DB data initializer.
/// </summary>
public class DataInitializer
{
    /// <summary>
    /// Adds entries to DB.
    /// </summary>
    /// <param name="context">DB context</param>
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Locations.Any())
            return;

        var locations = new Location[]
        {
            new Location
            {
                Id = new Guid("42a8075a-095e-4721-adba-49a022de359a"),
                Name = "Чернівці",
                Lon = 25.937F,
                Lat = 48.286F,
            },
            new Location
            {
                Id = new Guid("a3e8bdde-531e-4d0c-82c7-cf4c227ba68f"),
                Name = "Нижні Станівці",
                Lon = 25.555F,
                Lat = 48.311F,
            },
        };

        await context.Locations.AddRangeAsync(locations);
        await context.SaveChangesAsync();
    }
}
