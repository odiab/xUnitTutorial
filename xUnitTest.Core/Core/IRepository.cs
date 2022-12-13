namespace xUnitTest.Core.Core;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default);

    IQueryable<TEntity> Queryable();
}


public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
        Set = context.Set<TEntity>();
    }

    protected DbSet<TEntity> Set { get; }

    public async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
        => await Set.FindAsync(keyValues, cancellationToken);

    public IQueryable<TEntity> Queryable()
        => Set;
}