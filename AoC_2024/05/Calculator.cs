namespace _05;

public class Calculator(IReadOnlyList<int[]> updates)
{
    public int Sum => updates.Sum(update => update.GetMiddleItem());
}