namespace LocationsService.Web.Modules.DB;

internal class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
        => builder.HasKey(_ => _.Id);
}