using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lottery.DataAccess;

public class LotteryDbContextFactory : IDesignTimeDbContextFactory<LotteryDbContext>
{
    public LotteryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LotteryDbContext>();
        optionsBuilder.UseInMemoryDatabase("lottery");

        return new LotteryDbContext(optionsBuilder.Options);
    }
}