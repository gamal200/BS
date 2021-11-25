using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class AccessCardExtensionConfiguration : IEntityTypeConfiguration<AccessCard>
    {
        public void Configure(EntityTypeBuilder<AccessCard> builder)
        {
            builder.HasKey(e => e.Id);
            //builder.HasOne(e => e.Car).WithOne(e => e.AccessCard).HasForeignKey<AccessCard>(e => e.CarId);
            //builder.HasIndex(e => e.CarId).IsUnique();
            builder.HasMany(e => e.AccessCardCredit).WithOne(e => e.AccessCard).HasForeignKey(e => e.AccessCardId);
        }
    }
}
