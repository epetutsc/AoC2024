
namespace _01;

public class Similarity(IEnumerable<int> values)
{
    public int Calculate(int ofValue)
    {
        return values.Where(values => values == ofValue).Sum();
    }

    public int CalculateTotal(IEnumerable<int> ofValues)
    {
        return ofValues.Sum(Calculate);
    }
}