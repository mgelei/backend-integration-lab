using Lottery.Model;
using Microsoft.EntityFrameworkCore;

namespace Lottery.DataAccess;

public class LotteryDbContext : DbContext
{
    public LotteryDbContext(DbContextOptions<LotteryDbContext> options) : base(options)
    {
    }

    public DbSet<Draw> Draws { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO Clarify if there's anything we need to do with these numbers
        // i.e. this is simple, but if we need to aggregate them, it's probably not the best idea
        modelBuilder.Entity<Draw>().Property(d => d.Numbers)
            .HasConversion(LotteryDbUtils.intListConverter, LotteryDbUtils.intListComparer);

        modelBuilder.Entity<Draw>().HasIndex(d => d.CreatedAt).IsDescending();

        modelBuilder.Entity<Draw>().HasIndex(d => d.PublicId).IsUnique();
    }
}