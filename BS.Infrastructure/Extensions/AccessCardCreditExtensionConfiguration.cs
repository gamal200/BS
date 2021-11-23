using BS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class AccessCardCreditExtensionConfiguration : IEntityTypeConfiguration<AccessCardCredit>
    {
        public void Configure(EntityTypeBuilder<AccessCardCredit> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.AccessCard);
        }
    }
}
