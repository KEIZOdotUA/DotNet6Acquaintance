namespace LocationsService.Web.Modules.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Location> Locations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
        => base.OnModelCreating(builder);
}
