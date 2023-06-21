using Lottery.DataAccess;
using Lottery.Model;
using Lottery.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Lottery.API.Repositories;

public class DrawRepository
{
    private readonly LotteryDbContext _dbContext;

    public DrawRepository(LotteryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<DrawGet>> GetDrawsAsync()
    {
        return await _dbContext.Draws
            .Select(d => new DrawGet
            {
                Numbers = d.Numbers,
                CreatedAt = d.CreatedAt,
                PublicId = d.PublicId
            })
            .ToListAsync();
    }

    public virtual async Task AddDrawAsync(DrawPost draw)
    {
        _dbContext.Draws.Add(new Draw
        {
            Numbers = draw.Numbers,
            CreatedAt = DateTime.Now,
            PublicId = Guid.NewGuid()
        });
        await _dbContext.SaveChangesAsync();
    }
}