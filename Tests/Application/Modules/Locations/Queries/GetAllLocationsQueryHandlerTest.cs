using Application.Dtos.Locations;
using Application.Modules.Locations.Queries.GetAllLocations;

namespace Tests.Application.Modules.Locations.Queries;

[TestClass]
public class GetAllLocationsQueryHandlerTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    private readonly CancellationToken _cancellationToken = new();
    private readonly GetAllLocationsQueryRequest _queryRequest = new();

    private readonly GetAllLocationsQueryHandler _queryHandler;

    public GetAllLocationsQueryHandlerTest()
        => _queryHandler = new GetAllLocationsQueryHandler(_locationsRepository, _mapper);

    [TestMethod]
    public async Task Handle_HappyPath_ReturnsAllLocations()
    {
        // Arrange
        var mappedLocations = Array.Empty<LocationShortDto>();
        _mapper.Map<LocationShortDto[]>(Arg.Any<IEnumerable<Location>>()).Returns(mappedLocations);

        // Act
        var queryResult = await _queryHandler.Handle(_queryRequest, _cancellationToken);

        // Assert
        queryResult.Data.Should().BeEquivalentTo(mappedLocations);
    }
}