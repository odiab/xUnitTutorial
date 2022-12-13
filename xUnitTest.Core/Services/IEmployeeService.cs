namespace xUnitTest.Core.Services;

public interface IEmployeeService : IService<Employee>
{
    Task<Employee> SelectByIdAsync(Guid id);
}

public class EmployeeService : Service<Employee>, IEmployeeService
{
    private readonly IRepository<Employee> _repository;

    protected EmployeeService(IRepository<Employee> repository)
        : base(repository)
    {
        _repository = repository;
    }

    public async Task<Employee> SelectByIdAsync(Guid id)
    {
        return await _repository.SelectByIdAsync(id);
    }
}