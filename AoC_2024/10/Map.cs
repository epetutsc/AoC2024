
using System.Drawing;
using System.Linq;
using System.Text;

namespace _10;

public class Map(byte[,] map)
{
    public IEnumerable<Point> FindTrailheads()
    {
        for (var i  = 0; i < map.GetLength(0); i++)
        {
            for (var j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 0)
                {
                    yield return new Point(j, i);
                }
            }
        }
    }

    public object GetRating(IEnumerable<Point> trailheads)
    {
        return trailheads.Sum(GetRating);
    }

    public long GetScore(params IEnumerable<Point> trailheads)
    {
        return trailheads.Sum(GetScore);
    }

    public long GetRating(Point trailhead)
    {
        if (map[trailhead.Y, trailhead.X] != 0)
        {
            return 0;
        }

        var trails = GetTrails(trailhead, 0);
        var distinctTrails = trails.Where(t => t.Count == 10).Select(ToString).Distinct().ToList();
        return distinctTrails.Count;
    }

    private string ToString(IEnumerable<IReadOnlyList<Point>> trails)
    {
        return string.Join("\n\n", trails.Select(ToString));
    }

    private string ToString(IReadOnlyList<Point> trail)
    {
        var clone = new byte[map.GetLength(0), map.GetLength(1)];
        for (var i = 0; i < map.GetLength(0); i++)
        {
            for (var j = 0; j < map.GetLength(1); j++)
            {
                clone[i, j] = map[i, j];
            }
        }

        foreach (var waypoint in trail)
        {
            clone[waypoint.Y, waypoint.X] = 100;
        }

        var sb = new StringBuilder();
        for (var i = 0; i < clone.GetLength(0); i++)
        {
            for (var j = 0; j < clone.GetLength(1); j++)
            {
                var b = clone[i, j];
                sb.Append(b == 100 ? '*' : b.ToString());
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    public long GetScore(Point trailhead)
    {
        if (map[trailhead.Y, trailhead.X] != 0)
        {
            return 0;
        }

        var trails = GetTrails(trailhead, 0);
        var nineHeightPositions = trails.Where(t => t.Count == 10).Select(t => t[^1]).Distinct().ToList();
        return nineHeightPositions.Count;
    }

    private IEnumerable<IReadOnlyList<Point>> GetTrails(Point waypoint, byte height)
    {
        if (waypoint.Y < 0 || waypoint.Y >= map.GetLength(0))
        {
            yield return [];
            yield break;
        }

        if (waypoint.X < 0 || waypoint.X >= map.GetLength(1))
        {
            yield return [];
            yield break;
        }

        var currentHeight = map[waypoint.Y, waypoint.X];
        if (currentHeight != height)
        {
            yield return [];
            yield break;
        }

        byte nextHeight = (byte) (height + 1);

        foreach (var trail in GetTrails(waypoint with { X = waypoint.X + 1 }, nextHeight))
        {
            yield return [waypoint, .. trail];
        }

        foreach (var trail in GetTrails(waypoint with { X = waypoint.X - 1 }, nextHeight))
        {
            yield return [waypoint, .. trail];
        }

        foreach (var trail in GetTrails(waypoint with { Y = waypoint.Y + 1 }, nextHeight))
        {
            yield return [waypoint, .. trail];
        }

        foreach (var trail in GetTrails(waypoint with { Y = waypoint.Y - 1 }, nextHeight))
        {
            yield return [waypoint, .. trail];
        }
    }
}
