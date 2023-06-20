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
        var intListConverter = new ValueConverter<List<int>, string>(
            i => JsonSerializer.Serialize(i, JsonSerializerOptions.Default),
            s => JsonSerializer.Deserialize<List<int>>(s, JsonSerializerOptions.Default)!);
        
        // https://learn.microsoft.com/en-us/ef/core/modeling/value-comparers?tabs=ef5
        var intListComparer = new ValueComparer<List<int>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
        
        // TODO Clarify if there's anything we need to do with these numbers
        // i.e. this is simple, but if we need to aggregate them, it's probably not the best idea
        modelBuilder.Entity<Draw>().Property(x => x.Numbers).HasConversion(intListConverter, intListComparer);
        
    }
}