namespace LocationsService.Web.Modules.DB;

public static class DbModule
{
    public static void RegisterDb(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(typeof(DbModule).Assembly.GetName().Name));

        var serviceProvider = services.BuildServiceProvider();
        using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        DataInitializer.SeedData(context).Wait();
    }
}
