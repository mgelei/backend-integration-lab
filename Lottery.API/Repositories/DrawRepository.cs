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
    
    public virtual async Task<List<Draw>> GetDrawsAsync()
    {
        return await _dbContext.Draws.ToListAsync();
    }

    public virtual async Task AddDrawAsync(DrawPost draw)
    {
        _dbContext.Draws.Add(new Draw
        {
            Numbers = draw.Numbers,
            CreatedAt = DateTime.Now
        });
        await _dbContext.SaveChangesAsync();
    }
}