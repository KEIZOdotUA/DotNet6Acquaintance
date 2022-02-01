using Application.Dtos.Locations;
using Application.Modules.Locations.Commands.CreateLocation;

namespace Tests.Application.Modules.Locations.Commands;

[TestClass]
public class CreateLocationCommandHandlerTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();
    private readonly ILocationsService _locationsService = Substitute.For<ILocationsService>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    private readonly CancellationToken _cancellationToken = new();
    private readonly CreateLocationCommandRequest _commandRequest = new() { Details = new LocationDetailsDto() };

    private readonly CreateLocationCommandHandler _commandHandler;

    public CreateLocationCommandHandlerTest() 
        => _commandHandler = new CreateLocationCommandHandler(_locationsRepository, _locationsService, _mapper);

    [TestMethod]
    [ExpectedException(typeof(ExistsException))]
    public async Task Handle_LocationExists_ExpectedException()
    {
        // Arrange
        var sameLocations = new Location[] { new Location() };
        _locationsService.GetSameLocations(_commandRequest.Details).Returns(sameLocations);

        // Act
        _ = await _commandHandler.Handle(_commandRequest, _cancellationToken);
    }

    [TestMethod]
    public async Task Handle_HappyPath_ReturnsCreatedLocationId()
    {
        // Arrange
        var sameLocations = Array.Empty<Location>();
        _locationsService.GetSameLocations(_commandRequest.Details).Returns(sameLocations);

        _mapper.Map<Location>(_commandRequest.Details).Returns(new Location());

        // Act
        var commandResult = await _commandHandler.Handle(_commandRequest, _cancellationToken);

        // Assert
        commandResult.Data.Should().NotBeEmpty();
    }
}
