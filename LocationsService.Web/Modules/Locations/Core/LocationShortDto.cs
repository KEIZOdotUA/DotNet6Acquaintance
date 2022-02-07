namespace LocationsService.Web.Modules.Locations.Core;

public record LocationShortDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}
