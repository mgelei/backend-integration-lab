using FluentAssertions;
using Lottery.Model;
using TestAPI.Common;

namespace TestAPI;

public class TestDataModel
{
    [Fact]
    public void DrawModel_ShouldCheckIfNumberQuantityIsCorrect()
    {
        var draw = new Draw
        {
            Id = 1,
            Numbers = new List<int> { 1, 2, 3, 4, 5, 6 },
            CreatedAt = DateTime.Now,
            PublicId = Guid.NewGuid()
        };

        var result = ModelValidator.ValidateModel(draw).Any(v => v.MemberNames.Contains("Numbers"));

        result.Should().BeTrue();
    }

    [Fact]
    public void DrawModel_ShouldCheckIfNumberRangeIsCorrect()
    {
        var draw = new Draw
        {
            Id = 1,
            Numbers = new List<int> { 1, 2, 3, 4, 51 },
            CreatedAt = DateTime.Now,
            PublicId = Guid.NewGuid()
        };

        var result = ModelValidator.ValidateModel(draw).Any(v => v.MemberNames.Contains("Numbers"));

        result.Should().BeTrue();
    }

    [Fact]
    public void DrawModel_ShouldCheckIfNumbersAreUnique()
    {
        var draw = new Draw
        {
            Id = 1,
            Numbers = new List<int> { 1, 1, 3, 4, 5 },
            CreatedAt = DateTime.Now,
            PublicId = Guid.NewGuid()
        };

        var result = ModelValidator.ValidateModel(draw).Any(v => v.MemberNames.Contains("Numbers"));

        result.Should().BeTrue();
    }


    [Fact]
    public void DrawModel_ShouldNotRaiseFalseErrors()
    {
        var draw = new Draw
        {
            Id = 1,
            Numbers = new List<int> { 1, 2, 3, 4, 5 },
            CreatedAt = DateTime.Now,
            PublicId = Guid.NewGuid()
        };

        var result = ModelValidator.ValidateModel(draw).Count == 0;

        result.Should().BeTrue();
    }
}