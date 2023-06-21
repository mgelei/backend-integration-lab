using Lottery.Model.Validations;

namespace Lottery.Model.DTO;

public class DrawPost
{
    [ValidLotteryDraw] public List<int> Numbers { get; set; } = null!;
}