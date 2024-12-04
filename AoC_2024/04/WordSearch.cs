using Direction = (int X, int Y);

namespace _04;

public class WordSearch(IReadOnlyList<string> input)
{
    private static readonly Direction Up = (0, -1);
    private static readonly Direction UpRight = (1, -1);
    private static readonly Direction Right = (1, 0);
    private static readonly Direction DownRight = (1, 1);
    private static readonly Direction Down = (0, 1);
    private static readonly Direction DownLeft = (-1, 1);
    private static readonly Direction Left = (-1, 0);
    private static readonly Direction UpLeft = (-1, -1);

    private readonly Direction[] _directions =
    [
        Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft
    ];
        

    public int CountWord(string word)
    {
        var total = 0;
        for (var row = 0; row < input.Count; row++)
        {
            for (var column = 0; column < input[row].Length; column++)
            {
                total += _directions.Sum(direction => Find(word, row, column, direction) ? 1 : 0);
            }
        }

        return total;
    }

    public int CountX(string word)
    {
        var reverse = new string(word.Reverse().ToArray());
        
        var total = 0;
        for (var row = 0; row < input.Count; row++)
        {
            for (var column = 0; column < input[row].Length - 2; column++)
            {
                var first = Find(word, row, column, DownRight)
                            || Find(reverse, row, column, DownRight);

                var second = Find(word, row, column + 2, DownLeft)
                             || Find(reverse, row, column + 2, DownLeft);

                total += first && second ? 1 : 0;
            }
        }

        return total;
    }

    private bool Find(string word, int row, int column, Direction direction)
    {
        for (var i = 0; i < word.Length; i++)
        {
            var y = row + i * direction.Y;
            if (y < 0 || y >= input.Count)
            {
                // out of bounds
                return false;
            }

            var x = column + i * direction.X;
            if (x < 0 || x >= input[y].Length)
            {
                // out of bounds
                return false;
            }

            var expected = word[i];
            var actual = input[y][x];
            if (actual != expected)
            {
                return false;
            }
        }

        return true;
    }
}