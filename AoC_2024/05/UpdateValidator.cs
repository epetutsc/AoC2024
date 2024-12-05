

namespace _05;

public class UpdateValidator(IReadOnlyList<(int Left, int Right)> rules)
{
    public bool Validate(int[] update)
    {
        for (var i = 0; i < update.Length - 1; i++)
        {
            if (!rules.Contains((update[i], update[i + 1])))
            {
                return false;
            }
        }

        return true;
    }

    public IReadOnlyList<int[]> Correct(IReadOnlyList<int[]> invalidUpdates)
    {
        return invalidUpdates.Select(Correct).ToList();
    }

    public int[] Correct(int[] invalidUpdate)
    {
        var correctedUpdate = invalidUpdate.ToArray();
        var ready = false;
        while (!ready)
        {
            ready = true;
            for (var i = 0; i < correctedUpdate.Length - 1; i++)
            {
                var left = correctedUpdate[i];
                var right = correctedUpdate[i + 1];
                if (rules.Contains((left, right)))
                {
                    continue;
                }

                // swap
                correctedUpdate[i] = right;
                correctedUpdate[i + 1] = left;
                ready = false;
            }
        }

        return [.. correctedUpdate];
    }
}
