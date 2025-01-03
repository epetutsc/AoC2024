using System.Drawing;
using System.Text;

namespace _08;

public class Antinodes(char[,] input, bool isPart2)
{
    private const char NoFrequency = '.';

    public IEnumerable<Point> Find()
    {
        HashSet<Point> antinodes = [];
        for (var row = 0; row < input.GetLength(0); row++)
        {
            for (var column = 0; column < input.GetLength(1); column++)
            {
                var frequency = input[column, row];
                if (frequency == NoFrequency)
                {
                    continue;
                }

                var antenna1 = new Point(column, row);
                if (isPart2)
                {
                    antinodes.Add(antenna1);
                }

                var antenna2 = FindNextAntenna(frequency, antenna1);
                while (antenna2 is not null)
                {
                    if (isPart2)
                    {
                        antinodes.Add(antenna2.Value);
                    }
                    
                    var vector1 = new Point(antenna1.X - antenna2.Value.X, antenna1.Y - antenna2.Value.Y);
                    var vector2 = new Point(antenna2.Value.X - antenna1.X, antenna2.Value.Y - antenna1.Y);

                    var antinode1 = new Point(antenna1.X + vector1.X, antenna1.Y + vector1.Y);
                    var antinode2 = new Point(antenna2.Value.X + vector2.X, antenna2.Value.Y + vector2.Y);

                    var added1 = true;
                    var added2 = true;
                    while (added1 || added2)
                    {
                        if (antinode1.X >= 0 && antinode1.X < input.GetLength(0) &&
                            antinode1.Y >= 0 && antinode1.Y < input.GetLength(1))
                        {
                            antinodes.Add(antinode1);
                            added1 = isPart2;
                        }
                        else
                        {
                            added1 = false;
                        }

                        if (antinode2.X >= 0 && antinode2.X < input.GetLength(0) &&
                            antinode2.Y >= 0 && antinode2.Y < input.GetLength(1))
                        {
                            antinodes.Add(antinode2);
                            added2 = isPart2;
                        }
                        else
                        {
                            added2 = false;
                        }

                        antinode1 = new Point(antinode1.X + vector1.X, antinode1.Y + vector1.Y);
                        antinode2 = new Point(antinode2.X + vector2.X, antinode2.Y + vector2.Y);
                    }

                    antenna2 = FindNextAntenna(frequency, antenna2.Value);
                }
            }
        }

        return antinodes;
    }

    private Point? FindNextAntenna(char frequency, Point antenna1)
    {
        var firstColumn = antenna1.X + 1;
        for (var row = antenna1.Y; row < input.GetLength(0); row++)
        {
            for (var column = firstColumn; column < input.GetLength(1); column++)
            {
                if (input[column, row] != frequency)
                {
                    continue;
                }

                return new Point(column, row);
            }

            firstColumn = 0;
        }

        return null;
    }

    public string Plot(IEnumerable<Point> antinodes)
    {
        var result = new char[input.GetLength(0), input.GetLength(1)];
        for (var i = 0; i < input.GetLength(0); i++)
        {
            for (var j = 0; j < input.GetLength(1); j++)
            {
                result[i, j] = input[i, j];
            }
        }

        foreach (var antinode in antinodes)
        {
            result[antinode.X, antinode.Y] = '#';
        }

        var sb = new StringBuilder();
        for (var i = 0; i < input.GetLength(0); i++)
        {
            for (var j = 0; j < input.GetLength(1); j++)
            {
                sb.Append(result[j, i]);
            }

            sb.AppendLine();
        }
        
        return sb.ToString();
    }
}
