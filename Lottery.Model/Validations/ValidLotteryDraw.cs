using System.ComponentModel.DataAnnotations;

namespace Lottery.Model.Validations;

public class ValidLotteryDraw : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        var numbers = value as List<int>;
        if (numbers!.Count != 5) return false;

        return numbers.All(number => number >= 1 && number <= 50);
    }
}