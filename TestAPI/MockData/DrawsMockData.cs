using Lottery.Model;

namespace TestAPI.MockData;

public class DrawsMockData
{
    public List<Draw> Draws { get; set; }

    public DrawsMockData()
    {
        Draws = new List<Draw>
        {
            new Draw
            {
                Id = 1,
                Numbers = new List<int> {1, 2, 3, 4, 5},
                CreatedAt = DateTime.Now
            },
            new Draw
            {
                Id = 2,
                Numbers = new List<int> {10, 11, 12, 13, 14},
                CreatedAt = DateTime.Now
            },
            new Draw
            {
                Id = 3,
                Numbers = new List<int> {45, 46, 47, 48, 49},
                CreatedAt = DateTime.Now
            }
        };
    }
    
    public List<Draw> GetDraws()
    {
        return Draws;
    }
    
    public void CreateDraw(Draw draw)
    {
        Draws.Add(draw);
    }
}