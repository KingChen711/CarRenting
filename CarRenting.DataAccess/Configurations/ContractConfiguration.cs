//using CarRenting.Models.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace CarRenting.DataAccess.Configurations;

//public class ContractConfiguration : IEntityTypeConfiguration<Contract>
//{
//    public void Configure(EntityTypeBuilder<Contract> builder)
//    {
//        builder
//            .Property(e => e.ContractId)
//            .HasDefaultValueSql("NEWSEQUENTIALID()")
//            .ValueGeneratedOnAdd();

//        builder
//            .HasIndex(e => e.ContractId)
//            .IsUnique();

//        //builder
//        //    .HasOne(e => e.Car)
//        //    .WithMany(e => e.Contracts)
//        //    .HasForeignKey(e => e.CarId)
//        //    .OnDelete(DeleteBehavior.Restrict);

//        builder
//            .HasOne(e => e.Customer)
//            .WithMany(e => e.Contracts)
//            .HasForeignKey(e => e.CustomerId)
//            .OnDelete(DeleteBehavior.Restrict);

//        builder
//            .HasOne(e => e.ContractStatus)
//            .WithMany(e => e.Contracts)
//            .HasForeignKey(e => e.ContractStatusId)
//            .OnDelete(DeleteBehavior.Restrict);
//    }
//}