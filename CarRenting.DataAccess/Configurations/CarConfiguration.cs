using CarRenting.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRenting.DataAccess.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .Property(e => e.CarId)
            .HasDefaultValueSql("NEWSEQUENTIALID()")
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(e => e.CarId)
            .IsUnique();

        builder
            .HasOne(e => e.CarStatus)
            .WithMany(e => e.Cars)
            .HasForeignKey(e => e.CarStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}