using System.ComponentModel.DataAnnotations.Schema;
using Lottery.Model.Validations;

namespace Lottery.Model;

[Table("DrawHistory")]
public class Draw
{
    public int Id { get; set; }
    [ValidLotteryDraw] public int[] Numbers { get; set; }
    public DateTime CreatedAt { get; set; }
}