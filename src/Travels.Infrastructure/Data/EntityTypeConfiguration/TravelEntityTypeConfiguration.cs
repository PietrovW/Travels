using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Travels.Core.Entities;

namespace Travels.Infrastructure.Data.EntityTypeConfiguration
{
    public class TravelEntityTypeConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(p => p.Trips)
             .WithOne();
        }
    }
}
