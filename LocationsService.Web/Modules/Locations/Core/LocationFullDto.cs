namespace LocationsService.Web.Modules.Locations.Core;

public record LocationFullDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public float Lon { get; set; }

    public float Lat { get; set; }
}
