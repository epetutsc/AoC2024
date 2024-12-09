namespace _07;

public class Line
{
    public long Result { get; private set; }
    public int[] Numbers { get; private set; } = [];

    public static Line Parse(string line)
    {
        var result = new Line();
        var parts = line.Split(':', 2);
        result.Result = long.Parse(parts[0].Trim());
        result.Numbers = parts[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        
        return result;
    }
}