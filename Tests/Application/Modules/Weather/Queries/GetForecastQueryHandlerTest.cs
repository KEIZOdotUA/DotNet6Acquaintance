using Application.Dtos.Weather;
using Application.Models.Www7timer;
using Application.Modules.Weather.Queries.GetForecast;
using Domain.Enums.Www7timer;
using Newtonsoft.Json;
using RestSharp;

namespace Tests.Application.Modules.Weather.Queries;

[TestClass]
public class GetForecastQueryHandlerTest
{
    private readonly IGenericRepository<Location> _locationsRepository = Substitute.For<IGenericRepository<Location>>();
    private readonly IWww7timerService _www7TimerService = Substitute.For<IWww7timerService>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    private readonly CancellationToken _cancellationToken = new();

    private readonly GetForecastQueryHandler _queryHandler;
    private readonly Dictionary<Products, string> _defaultResponses = new();

    public GetForecastQueryHandlerTest()
    {
        _queryHandler = new GetForecastQueryHandler(_locationsRepository, _www7TimerService, _mapper);

        var civilForecast = new Www7timerResponse<CivilForecast>
        {
            DataSeries = new[]
            {
                new CivilForecast { Wind10m = new Wind() },
                new CivilForecast { },
                new CivilForecast { },
            },
        };
        _defaultResponses.Add(Products.Civil, JsonConvert.SerializeObject(civilForecast));

        var civilLightForecast = new Www7timerResponse<CivilLightForecast>
        {
            DataSeries = new[]
            {
                new CivilLightForecast { Temp2m = new Temperature() },
                new CivilLightForecast { },
                new CivilLightForecast { },
            },
        };
        _defaultResponses.Add(Products.Civillight, JsonConvert.SerializeObject(civilLightForecast));

        var twoWeakForecast = new Www7timerResponse<TwoWeakForecast>
        {
            DataSeries = new[]
            {
                new TwoWeakForecast { },
                new TwoWeakForecast { },
                new TwoWeakForecast { },
            },
        };
        _defaultResponses.Add(Products.Two, JsonConvert.SerializeObject(twoWeakForecast));
    }

    [TestMethod]
    [ExpectedException(typeof(NotFoundException))]
    public async Task Handle_LocationNotFound_ExpectedException()
    {
        // Arrange
         var queryRequest = new GetForecastQueryRequest() { LocationId = Guid.NewGuid() };

        _locationsRepository.GetByIdAsync(queryRequest.LocationId).Returns((Location)null);

        // Act
        _ = await _queryHandler.Handle(queryRequest, _cancellationToken);
    }

    [TestMethod]
    [ExpectedException(typeof(ExternalServiceException))]
    public async Task Handle_ExternalError_ExpectedException()
    {
        // Arrange
        var queryRequest = new GetForecastQueryRequest() { LocationId = Guid.NewGuid() };

        var location = new Location { Id = queryRequest.LocationId };
        _locationsRepository.GetByIdAsync(queryRequest.LocationId).Returns(location);

        var fakeWww7timersResponse = new RestResponse { IsSuccessful = false, Content = "Some text error" };
        _www7TimerService.
            GetForecastAsync(location.Lon, location.Lat, queryRequest.Type)
            .Returns(fakeWww7timersResponse);

        // Act
        _ = await _queryHandler.Handle(queryRequest, _cancellationToken);
    }

    [DataRow(Products.Civil)]
    [DataRow(Products.Civillight)]
    [DataRow(Products.Two)]
    [TestMethod]
    public async Task Handle_HappyPath_ReturnsForecast(Products type)
    {
        // Arrange
        var queryRequest = new GetForecastQueryRequest() { LocationId = Guid.NewGuid(), Type = type };

        var location = new Location { Id = queryRequest.LocationId };
        _locationsRepository.GetByIdAsync(queryRequest.LocationId).Returns(location);

        var fakeWww7timersResponse = new RestResponse { IsSuccessful = true, Content = _defaultResponses[type] };
        _www7TimerService.
            GetForecastAsync(location.Lon, location.Lat, queryRequest.Type)
            .Returns(fakeWww7timersResponse);

        var fakeHumanizedCivilForecast = new HumanizedCivilForecastDto[]
        {
            new HumanizedCivilForecastDto(),
            new HumanizedCivilForecastDto(),
            new HumanizedCivilForecastDto(),
        };
        _mapper.Map<HumanizedCivilForecastDto[]>(Arg.Any<CivilForecast[]>()).Returns(fakeHumanizedCivilForecast);

        var fakeHumanizedCivilLightForecastDto = new HumanizedCivilLightForecastDto[]
        {
            new HumanizedCivilLightForecastDto(),
            new HumanizedCivilLightForecastDto(),
            new HumanizedCivilLightForecastDto(),
        };
        _mapper.Map<HumanizedCivilLightForecastDto[]>(Arg.Any<CivilLightForecast[]>()).Returns(fakeHumanizedCivilLightForecastDto);

        var fakeHumanizedTwoWeakForecastDto = new HumanizedTwoWeakForecastDto[]
        {
            new HumanizedTwoWeakForecastDto(),
            new HumanizedTwoWeakForecastDto(),
            new HumanizedTwoWeakForecastDto(),
        };
        _mapper.Map<HumanizedTwoWeakForecastDto[]>(Arg.Any<TwoWeakForecast[]>()).Returns(fakeHumanizedTwoWeakForecastDto);

        // Act
        var queryResult = await _queryHandler.Handle(queryRequest, _cancellationToken);

        // Assert
        queryResult.Data.Count().Should().Be(3);
    }
}
