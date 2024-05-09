using CarRenting.DataAccess.Configurations;
using CarRenting.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRenting.DataAccess;

public class CarRentingDbContext : IdentityDbContext<User>
{
    public CarRentingDbContext(DbContextOptions options) : base(options)
    {
    }

    //public DbSet<Company>? Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}