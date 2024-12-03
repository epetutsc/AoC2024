namespace _03;

public class Calculator(IEnumerable<(int, int)> input)
{
    public int AddMultiplications()
    {
        return input.Sum(t => t.Item1 * t.Item2);
    }
}