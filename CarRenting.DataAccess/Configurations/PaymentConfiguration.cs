﻿using CarRenting.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRenting.DataAccess.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .HasIndex(e => e.ContractId)
            .IsUnique();

        builder.HasOne(r => r.Contract)
            .WithOne(s => s.Payment)
            .HasPrincipalKey<Contract>(p => p.ContractId)
            .HasForeignKey<Payment>(r => r.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}