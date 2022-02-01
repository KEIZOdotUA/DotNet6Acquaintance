using Application.Modules.Locations.Commands.DeleteLocation;

namespace Tests.Application.Modules.Locations.Commands;

[TestClass]
public class DeleteLocationCommandHandlerTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();

    private readonly CancellationToken _cancellationToken = new();
    private readonly DeleteLocationCommandRequest _commandRequest = new() { Id = new Guid() };

    private readonly DeleteLocationCommandHandler _commandHandler;

    public DeleteLocationCommandHandlerTest()
        => _commandHandler = new DeleteLocationCommandHandler(_locationsRepository);

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
    public async Task Handle_HappyPath_ExpectedDeletedLocation()
    {
        // Arrange
        var location = new Location { Id = _commandRequest.Id };
        _locationsRepository.GetByIdAsync(_commandRequest.Id).Returns(location);

        // Act
        _ = await _commandHandler.Handle(_commandRequest, _cancellationToken);

        // Assert
        await _locationsRepository.Received(1).DeleteAsync(Arg.Is<Location>(x => x.Id == _commandRequest.Id));
    }
}
