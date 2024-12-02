




namespace _02
{
    public class DataAnalyzer
    {
        public bool IsSafe(IReadOnlyList<int> report)
        {
            if (!IsSafeInternal(report))
            {
                return report
                    .Select((_, i) => report.Take(i).Concat(report.Skip(i + 1)).ToArray())
                    .Any(IsSafeInternal);
            }

            return true;
        }

        private static bool IsSafeInternal(IReadOnlyList<int> report)
        {
            if (report.Count < 2)
            {
                return true;
            }

            if (!AllSameDirection(report))
            {
                return false;
            }

            if (!AllDistancesAreOk(report))
            {
                return false;
            }

            return true;
        }

        private static bool AllDistancesAreOk(IReadOnlyList<int> report)
        {
            for (var i = 0; i < report.Count - 1; i++)
            {
                var distance = Math.Abs(report[i] - report[i + 1]);
                if (distance is not (>= 1 and <= 3))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AllSameDirection(IReadOnlyList<int> report)
        {
            var direction = GetDirection(report[0], report[1]);
            for (var i = 1; i < report.Count - 1; i++)
            {
                var dir = GetDirection(report[i], report[i + 1]);
                if (dir != direction)
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetDirection(int v1, int v2)
        {
            return v1 - v2 > 0 ? -1 : 1;
        }

        public int CountSafe(IReadOnlyList<IReadOnlyList<int>> reports)
        {
            return reports.Count(report => IsSafe(report));
        }
    }
}
