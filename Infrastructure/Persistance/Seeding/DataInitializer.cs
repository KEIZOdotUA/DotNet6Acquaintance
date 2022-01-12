using Domain.Enums;
using Newtonsoft.Json;

namespace Infrastructure.Persistance.Seeding;

/// <summary>
/// DB data initializer.
/// </summary>
public class DataInitializer
{
    /// <summary>
    /// Path to default locations JSON.
    /// </summary>
    private static readonly string[] _defaultLocationsFilePath = new[]
    {
        Directory.GetCurrentDirectory(),
        "..",
        Projects.Infrastructure.ToString(),
        "Persistance",
        "Seeding",
        "defaultLocations.json",
    };

    /// <summary>
    /// Adds entries to DB.
    /// </summary>
    /// <param name="context">DB context</param>
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Locations.Any())
            return;
        
        var fullPath = Path.Combine(_defaultLocationsFilePath);
        var locationsJSON = File.ReadAllText(fullPath);

        var locations = JsonConvert.DeserializeObject<Location[]>(locationsJSON);
        
        await context.Locations.AddRangeAsync(locations);
        await context.SaveChangesAsync();
    }
}
