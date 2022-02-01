using Application.Dtos.Locations;
using Application.Modules.Locations;
using System.Linq.Expressions;

namespace Tests.Application.Modules.Locations;

[TestClass]
public class LocationsServiceTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();

    private readonly LocationsService _locationsService;

    public LocationsServiceTest()
        => _locationsService = new LocationsService(_locationsRepository);

    [TestMethod]
    public async Task GetSameLocations_HappyPath_ReturnsSameLocations()
    {
        // Arrange
        var sameLocation = new Location
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            Lon = GetRandomFloat(),
            Lat = GetRandomFloat(),
        };

        var parameter = new LocationDetailsDto
        {
            Name = sameLocation.Name,
            Lon = sameLocation.Lon,
            Lat = sameLocation.Lat,
        };

        var foundLocations = new Location[]
        {
            sameLocation,
            new Location { Name = sameLocation.Name },
            new Location { Lon = sameLocation.Lon, Lat = sameLocation.Lat },
        };

        _locationsRepository
            .GetWhereAsync(Arg.Any<Expression<Func<Location, bool>>>())
            .Returns(foundLocations);

        // Act
        var result = await _locationsService.GetSameLocations(parameter);

        // Assert
        result
            .Where(x => x.Name == parameter.Name || x.Lat == parameter.Lat && x.Lon == parameter.Lon)
            .Should()
            .BeEquivalentTo(foundLocations);
    }

    private static float GetRandomFloat()
    {
        var random = new Random();
        double mantissa = (random.NextDouble() * 2.0) - 1.0;
        double exponent = Math.Pow(2.0, random.Next(-126, 128));

        var retValue = (float)(mantissa * exponent);

        return retValue;
    }
}
