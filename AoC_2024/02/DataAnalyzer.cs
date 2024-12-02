namespace _02;

public class DataAnalyzer
{
    /// <summary>
    /// Check if the given report is safe. A report is safe if:
    /// * all numbers are in the same direction
    /// * all distances between numbers are 1, 2, or 3
    /// * if the report is not safe, check if it can be made safe by removing one number
    /// </summary>
    public bool IsSafe(IReadOnlyList<int> report)
    {
        if (!IsSafeInternal(report))
        {
            return report
                // remove one item at a time and check if the rest is safe
                .Select((_, i) => report.Take(i).Concat(report.Skip(i + 1)).ToArray())
                .Any(IsSafeInternal);
        }

        return true;
    }

    /// <summary>
    /// Check if the given report is safe. A report is safe if:
    /// * all numbers are in the same direction
    /// * all distances between numbers are 1, 2, or 3
    /// </summary>
    private static bool IsSafeInternal(IReadOnlyList<int> report)
    {
        if (report.Count < 2)
        {
            // a report with less than 2 numbers is always safe
            return true;
        }

        if (!AllSameDirection(report))
        {
            // if the numbers are not in the same direction, the report is not safe
            return false;
        }

        if (!AllDistancesAreOk(report))
        {
            // if the distances between numbers are not 1, 2, or 3, the report is not safe
            return false;
        }

        return true;
    }

    /// <summary>
    /// Check if all distances between numbers are 1, 2, or 3
    /// </summary>
    private static bool AllDistancesAreOk(IReadOnlyList<int> report)
    {
        return report
            // calculate the distance between each number
            .Zip(report.Skip(1), (a, b) => Math.Abs(a - b))
            .All(distance => distance is >= 1 and <= 3);
    }

    /// <summary>
    /// Check if all numbers are in the same direction
    /// </summary>
    private static bool AllSameDirection(IReadOnlyList<int> report)
    {
        var direction = GetDirection(report[0], report[1]);
        return report.Skip(1)
            // calculate the direction between each number
            .Zip(report.Skip(2), GetDirection)
            .All(dir => dir == direction);
    }

    private static int GetDirection(int v1, int v2)
    {
        return v1 - v2 > 0 ? -1 : 1;
    }

    /// <summary>
    /// Count the number of safe reports
    /// </summary>
    public int CountSafe(IReadOnlyList<IReadOnlyList<int>> reports)
    {
        return reports.Count(IsSafe);
    }
}
