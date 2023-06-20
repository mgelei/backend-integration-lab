using Lottery.Model.Validations;

namespace Lottery.Model;

public class Draw
{
    public int Id { get; set; }
    [ValidLotteryDraw] public int[] Numbers { get; set; }
    public DateTime CreatedAt { get; set; }
}