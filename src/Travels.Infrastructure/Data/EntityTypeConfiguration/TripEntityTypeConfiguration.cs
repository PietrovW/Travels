using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travels.Application.Entities;

namespace Travels.Infrastructure.Data.EntityTypeConfiguration;

public class TripEntityTypeConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Destination).HasMaxLength(100).IsRequired();
        builder.HasOne(p => p.Travel).WithMany(b => b.Trips)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
