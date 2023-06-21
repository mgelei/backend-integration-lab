using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lottery.Model.Validations;

namespace Lottery.Model;

[Table("DrawHistory")]
public class Draw
{
    [Key] public int Id { get; set; }
    [ValidLotteryDraw] public List<int> Numbers { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    [Required] public Guid PublicId { get; set; }
}