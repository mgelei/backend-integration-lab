using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lottery.DataAccess;
using Lottery.Model;
using Lottery.Model.DTO;

namespace Lottery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly LotteryDbContext _dbContext;

        public DrawController(LotteryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Draw
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Draw>>> GetDraws()
        {
            if (!_dbContext.Draws.Any())
            {
                return NotFound();
            }

            return await _dbContext.Draws.ToListAsync();
        }

        // POST: api/Draw
        [HttpPost]
        public async Task<ActionResult<DrawPost>> PostDraw(DrawPost draw)
        {
            _dbContext.Draws.Add(new Draw
            {
                Numbers = draw.Numbers,
                CreatedAt = DateTime.Now
            });
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetDraws", new { }, draw);
        }
    }
}