using Microsoft.EntityFrameworkCore;
using Travels.Application.Entities;
using Travels.Infrastructure.Data.EntityTypeConfiguration;

namespace Travels.Infrastructure.Data;

public class TravelsContext: DbContext
{
    public TravelsContext(DbContextOptions<TravelsContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TravelEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TripEntityTypeConfiguration());
    }

    public DbSet<Travel> Travels { get; set; }
    public DbSet<Trip> Trips { get; set; }
}
