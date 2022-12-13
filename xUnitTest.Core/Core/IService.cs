namespace xUnitTest.Core.Core;

public interface IService<TEntity> where TEntity : class
{
    Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default);
}

public class Service<TEntity> : IService<TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;

    protected Service(IRepository<TEntity> repository)
        => _repository = repository;


    public async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
        => await _repository.FindAsync(keyValues, cancellationToken);
}