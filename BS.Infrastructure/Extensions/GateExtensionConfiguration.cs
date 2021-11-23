using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class GateExtensionConfiguration : IEntityTypeConfiguration<Gate>
    {
        public void Configure(EntityTypeBuilder<Gate> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.ExitGates).WithOne(e => e.Gate).HasForeignKey(e => e.GateId);

        }
    }
}
