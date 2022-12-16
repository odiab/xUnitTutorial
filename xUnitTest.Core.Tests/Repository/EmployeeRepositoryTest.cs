using Moq;
using xUnitTest.Core.Models;
using xUnitTest.Core.Repository;

namespace xUnitTest.Core.Tests.Repository;

public class EmployeeRepositoryTest
{
    [Fact]
    public void SelectByIdAsync_WithNullId_ThrowArgumentNullException()
    {
        // Arrange
        var employeeMock = new Mock<IEmployeeRepository>();

        // Act
        Func<Guid?, Task<Employee>> func = id => employeeMock.Object.SelectByIdAsync(id);

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => func(null));
    }

    [Fact]
    public async Task SelectByIdAsync_WithIdValue_ReturnsListOfEmployees()
    {
        // Arrange
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = "Osama Abdel Latif Diab",
            Country = "Egypt",
            City = "Cairo",
            Email = "o.diab@outlook.com",
            Address = "14 Hosni el Ashmawi, St.",
            Region = "Heliopolis",
            PhoneNumber = "01223321356",
            PostalCode = "00000"
        };

        var employeeMock = new Mock<IEmployeeRepository>();
        employeeMock.Setup(repository => repository.SelectByIdAsync(It.IsAny<Guid?>())).ReturnsAsync(() => employee);

        // Act
        var actual = await employeeMock.Object.SelectByIdAsync(It.IsAny<Guid?>());

        // Assert
        Assert.Equal(employee, actual);
    }
}