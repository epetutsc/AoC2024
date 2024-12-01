
namespace _01;

public class Distance
{
    public int Calculate(int first, int second)
    {
        return Math.Abs(first - second);
    }

    public int CalculateTotal(IEnumerable<int> column1, IEnumerable<int> column2)
    {
        var pl1 = new PriorityQueue<int, int>(column1.Select(v => (v, v)));
        var pl2 = new PriorityQueue<int, int>(column2.Select(v => (v, v)));

        var total = 0;
        while (pl1.Count > 0 && pl2.Count > 0)
        {
            var left = pl1.Dequeue();
            var right = pl2.Dequeue();

            total += Calculate(left, right);
        }

        return total;
    }
}