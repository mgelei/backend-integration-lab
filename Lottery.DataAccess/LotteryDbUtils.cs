using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lottery.DataAccess;

public static class LotteryDbUtils
{
    public static readonly ValueConverter intListConverter = new ValueConverter<List<int>, string>(
        i => JsonSerializer.Serialize(i, JsonSerializerOptions.Default),
        s => JsonSerializer.Deserialize<List<int>>(s, JsonSerializerOptions.Default)!);

    public static readonly ValueComparer intListComparer = new ValueComparer<List<int>>(
        (c1, c2) => c1!.SequenceEqual(c2!),
        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        c => c.ToList());
}