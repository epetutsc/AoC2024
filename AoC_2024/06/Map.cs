namespace _06;

public class Map(char[][] input)
{
    public static Map FromString(string input)
    {
        var lines = input.Replace(" ", "").Split("\n");
        return new Map(lines.Select(line => line.ToCharArray()).ToArray());
    }

    public Position? Find(char ch)
    {
        for (var row = 0; row < input.Length; row++)
        {
            for (var column = 0; column < input[row].Length; column++)
            {
                if (input[row][column] == ch)
                {
                    return new Position(row, column);
                }
            }
        }

        return null;
    }

    public void Set(Position position, char c)
    {
        input[position.Row][position.Column] = c;
    }

    public char? Get(Position position)
    {
        if (position.Row < 0 || position.Row > input.Length - 1)
        {
            return null;
        }

        if (position.Column < 0 || position.Column > input[position.Row].Length - 1)
        {
            return null;
        }
        
        return input[position.Row][position.Column];
    }

    public bool IsOutOfBounds(Position position)
    {
        return Get(position) is null;
    }

    public override string ToString()
    {
        var lines = input.Select(line => string.Join("", line.Select(ch => ch.ToString())));
        return string.Join("\r\n", lines);
    }
}