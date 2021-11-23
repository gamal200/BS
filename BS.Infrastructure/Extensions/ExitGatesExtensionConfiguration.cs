using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class ExitGatesExtensionConfiguration : IEntityTypeConfiguration<ExitGates>
    {
        public void Configure(EntityTypeBuilder<ExitGates> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Car);
            builder.HasOne(e => e.Gate);
        }
    }
}
