using System.Text;

namespace _12;

public class Region
{
    public required string Plant { get; set; }

    public IReadOnlyList<Plot> Plots { get; private set; } = [];

    public int Area => Plots.Count;

    public long Perimeter => Plots.Sum(p => (long)p.Perimeter);

    public long Price => Area * Perimeter;
    public long Price2 => Area * Sides;

    public long Sides
    {
        get
        {
            var x = Plots.SelectMany(p => p.SideX).Distinct().ToList();
            var y = Plots.SelectMany(p => p.SideY).Distinct().ToList();
            return x.Count() + y.Count();
        }
    }

    public static Region Create(Plot start)
    {
        var region = new Region { Plant = start.Plant };
        region.Plots = FindConnectedPlotsWithSamePlant(region, start);
        return region;
    }

    private static List<Plot> FindConnectedPlotsWithSamePlant(Region region, Plot? plot)
    {
        if (plot is null)
        {
            return [];
        }

        if (plot.Plant != region.Plant)
        {
            return [];
        }

        if (plot.Region is not null)
        {
            return [];
        }

        plot.Region = region;

        return
        [
            plot,
            .. FindConnectedPlotsWithSamePlant(region, plot.Left),
            .. FindConnectedPlotsWithSamePlant(region, plot.Top),
            .. FindConnectedPlotsWithSamePlant(region, plot.Right),
            .. FindConnectedPlotsWithSamePlant(region, plot.Bottom)
        ];
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        var rows = Plots.Max(p => p.Position.Y) + 1;
        var columns = Plots.Max(p => p.Position.X) + 1;

        for (var y = 0; y < rows; y++)
        {
            var row = Plots.Where(p => p.Position.Y == y).OrderBy(o => o.Position.X).ToList();
            foreach (var col in row)
            {
                var ch = col.Top?.Plant != Plant ? '-' : ' ';
                sb.Append($"+{ch}+");
            }

            sb.AppendLine();

            foreach (var col in row)
            {
                sb.Append(col.Left?.Plant != Plant ? '|' : ' ');
                sb.Append(col.Plant);
                sb.Append(col.Right?.Plant != Plant ? '|' : ' ');
            }

            sb.AppendLine();

            foreach (var col in row)
            {
                var ch = col.Bottom?.Plant != Plant ? '-' : ' ';
                sb.Append($"+{ch}+");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}
