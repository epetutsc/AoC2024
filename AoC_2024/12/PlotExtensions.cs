
namespace _12;

public static class PlotExtensions
{
    public static IReadOnlyCollection<Plot> ConnectPlots(this Plot[,] matrix)
    {
        var result = new List<Plot>();
        for (var y = 0; y < matrix.GetLength(0); y++)
        {
            for (var x = 0; x < matrix.GetLength(1); x++)
            {
                var plot = matrix[y, x];
                Connect(matrix, x, y, plot);
                result.Add(plot);
            }
        }

        return result;
    }

    public static IReadOnlyCollection<Region> CreateRegions(this IEnumerable<Plot> plots)
    {
        return plots
            .Where(plot => plot.Region is null)
            .Select(Region.Create)
            .ToList();
    }

    private static void Connect(Plot[,] matrix, int x, int y, Plot plot)
    {
        if (x - 1 >= 0)
        {
            plot.Left = matrix[y, x - 1];
        }

        if (y - 1 >= 0)
        {
            plot.Top = matrix[y - 1, x];
        }

        if (x + 1 < matrix.GetLength(1))
        {
            plot.Right = matrix[y, x + 1];
        }

        if (y + 1 < matrix.GetLength(0))
        {
            plot.Bottom = matrix[y + 1, x];
        }
    }
}
