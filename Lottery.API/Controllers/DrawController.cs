using Lottery.API.Repositories;
using Lottery.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lottery.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrawController : ControllerBase
{
    private readonly DrawRepository _repo;

    public DrawController(DrawRepository drawRepo)
    {
        _repo = drawRepo;
    }

    // GET: api/Draw
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DrawGet>>> GetDraws()
    {
        var draws = await _repo.GetDrawsAsync();
        if (!draws.Any()) return NoContent();

        return draws;
    }

    // POST: api/Draw
    [HttpPost]
    public async Task<ActionResult<DrawPost>> PostDraw(DrawPost draw)
    {
        await _repo.AddDrawAsync(draw);

        return CreatedAtAction("GetDraws", new { }, draw);
    }
}