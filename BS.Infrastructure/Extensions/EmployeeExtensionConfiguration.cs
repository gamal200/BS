using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class EmployeeExtensionConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            //builder.HasIndex(e => e.CarId).IsUnique();
            //builder.HasOne(e => e.Car).WithOne(e => e.Employee).HasForeignKey<Employee>(e => e.CarId);
        }
    }
}
