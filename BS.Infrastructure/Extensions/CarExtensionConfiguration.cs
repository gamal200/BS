using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class CarExtensionConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.AccessCard);//.WithOne(e=>e.Car).HasForeignKey<Car>(e=>e.AccessCardId);
            builder.HasOne(e => e.Employee);//.WithOne(e => e.Car).HasForeignKey<Car>(e => e.EmployeeId);
            builder.HasIndex(e => e.EmployeeId).IsUnique();
            builder.HasMany(e => e.ExitGates).WithOne(e => e.Car).HasForeignKey(e => e.CarId);
        }
    }
}
