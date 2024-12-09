namespace _07;

public class OperatorProvider(int operatorCount, Operator[] allOperators)
{
    public static readonly Operator[] OperatorsPart1 =
    [
        Operator.Add,
        Operator.Multiply
    ];

    public static readonly Operator[] OperatorsPart2 =
    [
        Operator.Add,
        Operator.Multiply,
        Operator.Concatenate
    ];

    private int _currentValue;

    public bool TryNext(out IReadOnlyList<Operator> operators)
    {
        if (Math.Pow(allOperators.Length, operatorCount) < _currentValue + 1)
        {
            operators = [];
            return false;
        }

        var list = new List<Operator>();
        var value = _currentValue++;
        for (var i = 0; i < operatorCount; i++)
        {
            list.Add(allOperators[value % allOperators.Length]);
            value /= allOperators.Length;
        }

        operators = list;
        return true;
    }
}