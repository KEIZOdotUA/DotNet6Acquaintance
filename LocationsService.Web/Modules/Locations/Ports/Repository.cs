namespace LocationsService.Web.Modules.Locations.Ports;

public class Repository : IRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Location> _dbSet;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = appDbContext.Set<Location>();
    }

    public async Task<Location> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity;
    }

    public async Task CreateAsync(Location location)
    {
        _dbSet.Add(location);

        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Location location)
    {
        _dbSet.Attach(location);
        _appDbContext.Entry(location).State = EntityState.Modified;

        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Location location)
    {
        if (_appDbContext.Entry(location).State == EntityState.Detached)
            _dbSet.Attach(location);

        _dbSet.Remove(location);

        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<Location>> GetSameAsync(string name, float lon, float lat)
    {
        return await _dbSet.Where(x => x.Name == name || x.Lat == lat && x.Lon == lon).ToListAsync();
    }
}
