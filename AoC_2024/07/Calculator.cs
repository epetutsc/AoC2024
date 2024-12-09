namespace _07;

public class Calculator(IEnumerable<Line> lines, Operator[] allOperators)
{
    public long Sum()
    {
        return lines.Where(EquationIsTrue).Sum(x => x.Result);
    }

    private bool EquationIsTrue(Line line)
    {
        var provider = new OperatorProvider(line.Numbers.Length - 1, allOperators);
        while (provider.TryNext(out var operators))
        {
            long result = line.Numbers[0];
            for (var i = 1; i < line.Numbers.Length; i++)
            {
                result = operators[i - 1] switch
                {
                    Operator.Add => result + line.Numbers[i],
                    Operator.Multiply => result * line.Numbers[i],
                    Operator.Concatenate => long.Parse($"{result}{line.Numbers[i]}"),
                    _ => throw new NotImplementedException()
                };

                if (result == line.Result)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
