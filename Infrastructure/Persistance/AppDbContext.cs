namespace Infrastructure.Persistance;

/// <summary>
/// Application DB context.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkApplication.DbContext" />
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    /// <summary>
    /// Gets or sets the locations.
    /// </summary>
    /// <value>
    /// The apis.
    /// </value>
    public DbSet<Location> Locations { get; set; }

    /// <summary>
    /// Called when [model creating].
    /// </summary>
    /// <param name="builder">The builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
