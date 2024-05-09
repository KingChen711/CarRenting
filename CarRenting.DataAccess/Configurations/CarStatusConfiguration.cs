using CarRenting.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRenting.DataAccess.Configurations;

public class CarStatusConfiguration : IEntityTypeConfiguration<CarStatus>
{
    public void Configure(EntityTypeBuilder<CarStatus> builder)
    {
        builder
            .Property(e => e.CarStatusId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.CarStatusId)
            .IsUnique();
    }
}