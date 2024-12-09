using System.Text;

namespace _06;

public class Map(char[][] input)
{
    public static Map FromString(string input)
    {
        var lines = new List<char[]>();

        using (var reader = new StringReader(input))
        {
            while (reader.ReadLine() is { } line)
            {
                var chars = new List<char>();
                foreach (var ch in line)
                {
                    if (ch != ' ') // Leerzeichen überspringen
                        chars.Add(ch);
                }
                lines.Add(chars.ToArray());
            }
        }

        return new Map(lines.ToArray());
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
        var sb = new StringBuilder();
        foreach (var line in input)
        {
            sb.Append(line); // char[] direkt anhängen
            sb.Append("\r\n"); // Zeilenumbruch anhängen
        }
        if (sb.Length >= 2)
        {
            sb.Length -= 2; // Entfernt das letzte "\r\n" (optional, je nach Anforderung)
        }

        return sb.ToString();
    }
}