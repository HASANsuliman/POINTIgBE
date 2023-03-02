using Microsoft.EntityFrameworkCore;
using PointengBE.Models.Auth;

namespace PointengBE.Models.Context
{
    public class PointingContext: DbContext
    {
        public PointingContext(DbContextOptions<PointingContext> options)
          : base(options)
        {
        }
        public DbSet<Plan>? Plan { get; set; } = default!;
        public DbSet<DirectConfig>? DirectConfigs { get; set; } = default!;
        public DbSet<SubDirectConfigs>? SubDirectConfigs { get; set; } = default!;
        public DbSet<LogHistory>? LogHistories { get; set; } = default!;
        public DbSet<Locations>? Location { get; set; } = default!;
        public DbSet<Sales>? Sales { get; set; } = default!;
        public DbSet<Calculations>? Calculations { get; set; } = default!;


        public DbSet<CustomClaims> CustomClaims { get; internal set; }
        public DbSet<AD> Ads { get; internal set; } = default!;

        public DbSet<VAS> Vas { get; internal set; } = default!;

    }
}
