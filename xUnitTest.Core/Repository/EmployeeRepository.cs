namespace xUnitTest.Core.Repository;

public static class EmployeeRepository1
{
    public static Task<Employee> SelectByIdAsync(this IRepository<Employee> repository, Guid? id)
    {
        if (!id.HasValue)
        {
            throw new ArgumentNullException(nameof(id));
        }

        return repository
            .Queryable()
            .FirstOrDefaultAsync(q => q.Id == id);
    }
}