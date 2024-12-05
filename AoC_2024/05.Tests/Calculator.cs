namespace _05.Tests;

public class Calculator(List<int[]> updates)
{
    public int Sum => updates.Sum(update => update.GetMiddleItem());
}