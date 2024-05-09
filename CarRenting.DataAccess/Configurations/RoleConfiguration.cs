using CarRenting.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRenting.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Name = Role.CUSTOMER,
                NormalizedName = "CUSTOMER"
            },
            new IdentityRole
            {
                Name = Role.EMPLOYEE,
                NormalizedName = "Employee"
            },
            new IdentityRole
            {
                Name = Role.ADMINISTRATOR,
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}