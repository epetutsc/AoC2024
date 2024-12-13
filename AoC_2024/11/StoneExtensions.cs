using System.Collections.Concurrent;

using Key = (long Number, long Level);

namespace _11;

public static class StoneExtensions
{
    private static readonly ConcurrentDictionary<Key, IReadOnlyList<long>> cache = new();
    private static readonly ConcurrentDictionary<Key, long> counterCache = new();

    public static long Count(this IEnumerable<long> stones, int depth = 1)
    {
        return stones.Sum(stone => stone.Count(depth));
    }

    public static long Count(this long number, int depth)
    {
        if (counterCache.TryGetValue((number, depth), out var sum))
        {
            return sum;
        }

        var value = number.Blink();

        if (depth is 1)
        {
            counterCache.TryAdd((number, 1), value.Count);
            return value.Count;
        }

        var result = Count(value, depth - 1);
        counterCache.TryAdd((number, depth), result);
        return result;
    }

    public static IReadOnlyList<long> Blink(this IEnumerable<long> stones, int depth = 1)
    {
        var result = new List<long>();
        foreach (var stone in stones)
        {
            result.AddRange(stone.Blink(depth));
        }

        return result;
    }

    public static IReadOnlyList<long> Blink(this long number, int depth)
    {
        if (cache.TryGetValue((number, depth), out var cached))
        {
            return cached;
        }

        var value = number.Blink();

        if (depth is 1)
        {
            cache.TryAdd((number, 1), value);
            return value;
        }

        var result = Blink(value, depth - 1);
        cache.TryAdd((number, depth), result);
        return result;
    }

    public static IReadOnlyList<long> Blink(this long number)
    {
        if (number is 0)
        {
            return [1L];
        }

        var length = (int)Math.Log10(number) + 1;
        if (length % 2 is 0)
        {
            long left = (long) (number / Math.Pow(10, length / 2));
            long right = (long) (number % Math.Pow(10, length / 2));
            return [left, right];
        }

        return [number * 2024];
    }
}
