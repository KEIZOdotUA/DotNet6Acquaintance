using Application.Dtos.Locations;
using Application.Modules.Locations.Commands.UpdateLocation;

namespace Tests.Application.Modules.Locations.Commands;

[TestClass]
public class UpdateLocationCommandHandlerTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();
    private readonly ILocationsService _locationsService = Substitute.For<ILocationsService>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    private readonly CancellationToken _cancellationToken = new();
    private readonly UpdateLocationCommandRequest _commandRequest = new()
    {
        Id = Guid.NewGuid(),
        Details = new LocationDetailsDto(),
    };

    private readonly UpdateLocationCommandHandler _commandHandler;

    public UpdateLocationCommandHandlerTest()
        => _commandHandler = new UpdateLocationCommandHandler(_locationsRepository, _locationsService, _mapper);

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task Handle_LocationNotFound_ExpectedException()
    {
        // Arrange
        _locationsRepository.GetByIdAsync(_commandRequest.Id).Returns((Location)null);

        // Act
        _ = await _commandHandler.Handle(_commandRequest, _cancellationToken);
    }

    [TestMethod]
    [ExpectedException(typeof(ExistsException))]
    public async Task Handle_LocationExists_ExpectedException()
    {
        // Arrange
        var location = new Location { Id = _commandRequest.Id };
        _locationsRepository.GetByIdAsync(_commandRequest.Id).Returns(location);

        var sameLocations = new Location[] { new Location() };
        _locationsService.GetSameLocations(_commandRequest.Details).Returns(sameLocations);

        // Act
        _ = await _commandHandler.Handle(_commandRequest, _cancellationToken);
    }

    [TestMethod]
    public async Task Handle_HappyPath_ExpectedUpdatedLocation()
    {
        // Arrange
        var location = new Location { Id = _commandRequest.Id };
        _locationsRepository.GetByIdAsync(_commandRequest.Id).Returns(location);

        var sameLocations = Array.Empty<Location>();
        _locationsService.GetSameLocations(_commandRequest.Details).Returns(sameLocations);

        var updateLocation = new Location { Id = _commandRequest.Id };
        _mapper.Map<Location>(_commandRequest.Details).Returns(updateLocation);

        // Act
        _ = await _commandHandler.Handle(_commandRequest, _cancellationToken);

        // Assert
        await _locationsRepository
            .Received(1)
            .UpdateAsync(Arg.Is<Location>(x =>
                x.Id == updateLocation.Id
                && x.Lat == updateLocation.Lat 
                && x.Lon == updateLocation.Lon
                && x.Name == updateLocation.Name));
    }
}
