namespace xUnitTest.Core.Data.Mapping;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employees");

        builder
            .HasKey(pk => pk.Id);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Name)
            .HasMaxLength(1024)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(p => p.PhoneNumber)
            .HasMaxLength(16)
            .IsRequired();

        builder
            .Property(p => p.Address)
            .HasMaxLength(2048)
            .IsRequired(false);

        builder
            .Property(p => p.City)
            .HasMaxLength(64)
            .IsRequired(false);

        builder
            .Property(p => p.Region)
            .HasMaxLength(64)
            .IsRequired(false);

        builder
            .Property(p => p.PostalCode)
            .HasMaxLength(11)
            .IsRequired(false);

        builder
            .Property(p => p.Country)
            .HasMaxLength(64)
            .IsRequired(false);


    }
}