using Lottery.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Common;

public static class MemoryContext
{
    public static LotteryDbContext GetMemoryContext()
    {
        var options = new DbContextOptionsBuilder<LotteryDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;
        return new LotteryDbContext(options);
    }
}