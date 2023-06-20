using Lottery.Model;
using Microsoft.EntityFrameworkCore;

namespace Lottery.DataAccess;

public class LotteryDbContext : DbContext
{
    public DbSet<Draw> Draws { get; set; } = null!;
}