using System.Reflection;
using CarRenting.DataAccess.Configurations;
using CarRenting.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CarRenting.DataAccess;

public class CarRentingDbContext : IdentityDbContext<User, Role, int>
{
    public CarRentingDbContext(DbContextOptions options) : base(options)
    {
    }

    public CarRentingDbContext()
    {
    }

    public DbSet<Car>? Cars { get; set; }
    public DbSet<CarStatus>? CarStatuses { get; set; }
    public DbSet<Contract>? Contracts { get; set; }
    public DbSet<ContractStatus>? ContractStatuses { get; set; }
    public DbSet<Feedback>? Feedbacks { get; set; }
    public DbSet<Payment>? Payments { get; set; }
    //không cần tạo DbSet cho User và Role

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(GetBasePath())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("CarRentingDbContextConnection"));
    }

    private string GetBasePath()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
        return Path.Combine(directoryInfo.Parent!.FullName, "CarRenting.Web");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CarStatusConfiguration());
        modelBuilder.ApplyConfiguration(new ContractConfiguration());
        modelBuilder.ApplyConfiguration(new ContractStatusConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}