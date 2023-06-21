using Lottery.Model;
using Lottery.Model.DTO;

namespace TestAPI.MockData;

public class DrawsMockData
{
    public DrawsMockData()
    {
        Draws = new List<Draw>
        {
            new()
            {
                Id = 1,
                Numbers = new List<int> { 1, 2, 3, 4, 5 },
                CreatedAt = DateTime.Now,
                PublicId = Guid.NewGuid()
            },
            new()
            {
                Id = 2,
                Numbers = new List<int> { 10, 11, 12, 13, 14 },
                CreatedAt = DateTime.Now,
                PublicId = Guid.NewGuid()
            },
            new()
            {
                Id = 3,
                Numbers = new List<int> { 45, 46, 47, 48, 49 },
                CreatedAt = DateTime.Now,
                PublicId = Guid.NewGuid()
            }
        };
    }

    private List<Draw> Draws { get; }

    public List<DrawGet> GetDraws()
    {
        return Draws.Select(draw => new DrawGet
        {
            Numbers = draw.Numbers,
            CreatedAt = draw.CreatedAt,
            PublicId = draw.PublicId
        }).ToList();
    }

    public void CreateDraw(Draw draw)
    {
        Draws.Add(draw);
    }
}