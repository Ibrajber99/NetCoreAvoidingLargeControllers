using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreAvoidingLargeControllers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvoidingLargeControllers.Persistance.Configurations
{
    public class TestInfoConfiguration : IEntityTypeConfiguration<TestInfo>
    {
        public void Configure(EntityTypeBuilder<TestInfo> builder)
        {
            builder.Property(ti => ti.TestName)
                .IsRequired();

            builder.Property(ti => ti.Description)
                .IsRequired();

            builder.Property(ti => ti.TestDate)
                .IsRequired();

            builder.HasKey(ti => ti.ID);
        }
    }
}
