using System.Drawing;

namespace _13;

public class Machine
{
    public const double TokensA = 3;
    public const double TokensB = 1;

    public Point A { get; set; } = new();
    public Point B { get; set; } = new();
    public Point Prize { get; set; } = new();

    public Point? MoveToPrize()
    {
        var stepsPerTokenA = A.X / TokensA + A.Y / TokensA;
        var stepsPerTokenB = B.X / TokensB + B.Y / TokensB;

        var countX = 0;
        var countY = 0;

        if (stepsPerTokenA > stepsPerTokenB)
        {
            countX = Prize.X / A.X;
            for (var i = countX; i >= 0; i--)
            {
                var remainder = Prize.X - A.X * i;
                if (remainder % A.Y == 0)
                {
                    countY = remainder / A.Y;
                    break;
                }
            }

        }
    }
}
