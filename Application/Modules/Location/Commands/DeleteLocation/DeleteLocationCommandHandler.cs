namespace Application.Modules.Locations.Commands.DeleteLocation;

/// <summary>
/// Delete location command handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Application.Modules.Locations.Commands.DeleteLocation.DeleteLocationCommandRequest, MediatR.Unit&gt;" />
public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommandRequest, Unit>
{
    private readonly IGenericRepository<Location> _locationsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteLocationCommandHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    public DeleteLocationCommandHandler(IGenericRepository<Location> locationsRepository)
        => _locationsRepository = locationsRepository;

    /// <summary>
    /// Handles delete location command request.
    /// </summary>
    /// <param name="commandRequest">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Default and only value of the MediatR.Unit type.
    /// </returns>
    /// <exception cref="NotFoundException">Location</exception>
    public async Task<Unit> Handle(DeleteLocationCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(commandRequest.Id);
        if (location == null)
            throw new NotFoundException(nameof(Location));

        await _locationsRepository.DeleteAsync(location);

        return Unit.Value;
    }
}
