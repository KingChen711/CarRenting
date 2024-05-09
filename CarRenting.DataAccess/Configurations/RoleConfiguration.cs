using CarRenting.Models.Entities;
using CarRenting.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRenting.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .Property(e => e.RoleId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.RoleId)
            .IsUnique();

        builder.HasData(
            new Role
            {
                Id = 1,
                // RoleId = new Guid(), thêm cái này vào cũng ko giải quyết được cái lỗi migration Role
                Name = RoleAccount.CUSTOMER,
                NormalizedName = "CUSTOMER"
            },
            new Role
            {
                Id = 2,
                // RoleId = new Guid(),
                Name = RoleAccount.EMPLOYEE,
                NormalizedName = "Employee"
            },
            new Role
            {
                Id = 3,
                // RoleId = new Guid(),
                Name = RoleAccount.ADMINISTRATOR,
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}