using System.Text.Json;
using Lottery.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lottery.DataAccess;

public class LotteryDbContext : DbContext
{
    public DbSet<Draw> Draws { get; set; } = null!;

    public LotteryDbContext(DbContextOptions<LotteryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO Clarify if there's anything we need to do with these numbers
        // i.e. this is simple, but if we need to aggregate them, it's probably not the best idea
        modelBuilder.Entity<Draw>().Property(d => d.Numbers)
            .HasConversion(LotteryDbUtils.intListConverter, LotteryDbUtils.intListComparer);
        
        modelBuilder.Entity<Draw>().HasIndex(d => d.CreatedAt).IsDescending();
    }
}