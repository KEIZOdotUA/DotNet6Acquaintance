using Application.Dtos.Locations;
using Application.Modules.Locations.Queries.GetLocationDetails;

namespace Tests.Application.Modules.Locations.Queries;

[TestClass]
public class GetLocationDetailsQueryHandlerTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    private readonly CancellationToken _cancellationToken = new();
    private readonly GetLocationDetailsQueryRequest _queryRequest = new() { Id = new Guid() };

    private readonly GetLocationDetailsQueryHandler _queryHandler;

    public GetLocationDetailsQueryHandlerTest()
        => _queryHandler = new GetLocationDetailsQueryHandler(_locationsRepository, _mapper);

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task Handle_LocationNotFound_ExpectedException()
    {
        // Arrange
        _locationsRepository.GetByIdAsync(_queryRequest.Id).Returns((Location)null);

        // Act
        _ = await _queryHandler.Handle(_queryRequest, _cancellationToken);
    }

    [TestMethod]
    public async Task Handle_HappyPath_ReturnsLocationDetails()
    {
        // Arrange
        var location = new Location { Id = _queryRequest.Id };
        _locationsRepository.GetByIdAsync(_queryRequest.Id).Returns(location);

        var mappedLocation = new LocationFullDto { Id = _queryRequest.Id };
        _mapper.Map<LocationFullDto>(Arg.Is<Location>(x => x.Id == _queryRequest.Id)).Returns(mappedLocation);

        // Act
        var queryResult = await _queryHandler.Handle(_queryRequest, _cancellationToken);

        // Assert
        queryResult.Data.Should().BeEquivalentTo(mappedLocation);
    }
}
