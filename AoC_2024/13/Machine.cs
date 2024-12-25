using System.Drawing;

namespace _13;

public class Machine
{
    public const double TokensA = 3;
    public const double TokensB = 1;

    public Point A { get; set; } = new();
    public Point B { get; set; } = new();
    public Point Prize { get; set; } = new();

    public Result? MoveToPrize()
    {
        var maxA = Math.Min(Prize.X / A.X + 1, Prize.Y / A.Y + 1);
        var maxB = Math.Min(Prize.X / B.X + 1, Prize.Y / B.Y + 1);

        var results = new List<Result>();
        for (var countA = 0; countA <= maxA; countA++)
        {
            for (var countB = 0; countB <= maxB; countB++)
            {
                var pos = new Point(countA * A.X, countA * A.Y);
                pos += new Size(countB * B.X, countB * B.Y);
                if (pos.X == Prize.X && pos.Y == Prize.Y)
                {
                    results.Add(new Result(countA, countB));
                }
            }
        }

        if (results.Count == 0)
        {
            return null;
        }

        return results.MinBy(r => r.TotalTokens);
    }
}
