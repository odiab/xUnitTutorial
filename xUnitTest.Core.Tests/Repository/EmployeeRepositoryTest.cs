using Moq;
using xUnitTest.Core.Core;
using xUnitTest.Core.Data;
using xUnitTest.Core.Models;
using xUnitTest.Core.Repository;

namespace xUnitTest.Core.Tests.Repository;

public class EmployeeRepositoryTest
{
    [Fact]
    public void SelectByIdAsync_WithNullId_ThrowArgumentNullException()
    {
        // Arrange
        var dbContext = new Mock<AppDbContext>();
        var repository = new Mock<IRepository<Employee>>();

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

        // Act
        Func<Guid?, Employee> func = id => repository.Setup(async m => await m.SelectByIdAsync(id)).Returns(employee);
        var actual = repository.Setup(m => m.SelectByIdAsync(null)).ReturnsAsync(employee);


        // Assert
        Assert.Throws<ArgumentNullException>(() => func(null));
    }

    [Fact]
    public void SelectByIdAsync_WithIdValue_ReturnsListOfEmployees()
    {
        // Arrange

        // Act

        // Assert
    }
}