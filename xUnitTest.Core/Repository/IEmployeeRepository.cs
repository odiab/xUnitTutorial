namespace xUnitTest.Core.Repository;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> SelectByIdAsync(Guid? id);
}

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DbContext context)
        : base(context)
    {
    }

    public Task<Employee> SelectByIdAsync(Guid? id)
    {
        if (!id.HasValue)
        {
            throw new ArgumentNullException(nameof(id));
        }

        return Queryable()
            .FirstOrDefaultAsync(q => q.Id == id);

    }
}