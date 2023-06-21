using System.ComponentModel.DataAnnotations;
using Lottery.Model.Validations;

namespace Lottery.Model.DTO;

public class DrawGet
{
    [Required] public Guid PublicId { get; set; }
    [ValidLotteryDraw] public List<int> Numbers { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}