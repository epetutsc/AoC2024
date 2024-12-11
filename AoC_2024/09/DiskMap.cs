

namespace _09;

public class DiskMap(string input)
{
    public long Checksum()
    {
        var result = 0L;
        var diskMap = Compact();
        for (var i = 0; i < diskMap.Length; i++)
        {
            result += i * (diskMap[i] ?? 0);
        }

        return result;
    }

    public int?[] Compact()
    {
        var diskMap = Explode();
        var left = 0;
        var right = diskMap.Length - 1;
        while (left < right)
        {
            while (diskMap[left] != null && left < right)
            {
                left++;
            }

            if (left == right)
            {
                break;
            }

            while (diskMap[right] == null && left < right)
            {
                right--;
            }

            if (left == right)
            {
                break;
            }

            diskMap[left] = diskMap[right];
            diskMap[right] = null;
        }
        
        return diskMap;
    }

    public int?[] Explode()
    {
        var result = new List<int?>();
        var isFreeSpace = false;
        int? index = 0;
        foreach (var n in input)
        {
            var count = n - '0';
            if (isFreeSpace)
            {
                var items = Enumerable.Repeat((int?)null, count);
                result.AddRange(items);
            }
            else
            {
                var items = Enumerable.Repeat(index, count);
                result.AddRange(items);
                index++;
            }

            isFreeSpace = !isFreeSpace;
        }

        return [.. result];
    }
}