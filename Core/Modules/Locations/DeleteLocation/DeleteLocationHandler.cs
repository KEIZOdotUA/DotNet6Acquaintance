namespace Core.Modules.Locations.DeleteLocation;

/// <summary>
/// Delete location handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Core.Modules.Locations.DeleteLocation.DeleteLocationRequest, MediatR.Unit&gt;" />
public class DeleteLocationHandler : IRequestHandler<DeleteLocationRequest, Unit>
{
    private readonly IGenericRepository<Location> _locationsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteLocationHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    public DeleteLocationHandler(IGenericRepository<Location> locationsRepository)
        => _locationsRepository = locationsRepository;

    /// <summary>
    /// Handles delete location request
    /// </summary>
    /// <param name="request">Delete request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Default and only value of the MediatR.Unit type.
    /// </returns>
    /// <exception cref="Core.Extensions.Exceptions.NotFoundException"></exception>
    public async Task<Unit> Handle(DeleteLocationRequest request, CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(request.Id);
        if (location == null)
            throw new NotFoundException();

        await _locationsRepository.DeleteAsync(location);

        return Unit.Value;
    }
}
