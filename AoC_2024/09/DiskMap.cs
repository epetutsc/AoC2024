

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

    public long ChecksumWithoutFragmentation()
    {
        var result = 0L;
        var diskMap = CompactWithoutFragmentation();
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

    public int?[] CompactWithoutFragmentation()
    {
        var diskMap = Explode();

        for (var id = input.Length / 2 + 1; id >= 0; id--)
        {
            var file = FindFile(diskMap, id);
            if (file is null)
            {
                continue;
            }

            var startOfFreeSpace = FindFreeSpace(diskMap, file.Value.Size);
            if (startOfFreeSpace is null)
            {
                continue;
            }

            if (startOfFreeSpace >= file.Value.Start)
            {
                continue;
            }

            for (var i = 0; i < file.Value.Size; i++)
            {
                diskMap[startOfFreeSpace.Value + i] = id;
                diskMap[file.Value.Start + i] = null;
            }
        }

        return diskMap;
    }

    private static int? FindFreeSpace(int?[] diskMap, int size)
    {
        var freeSpace = 0;
        var start = -1;
        while (true)
        {
            start = Array.IndexOf(diskMap, null, start + 1);
            if (start < 0)
            {
                return null;
            }

            var end = Array.FindIndex(diskMap, start, x => x != null);
            freeSpace = end >= 0 ? end - start : diskMap.Length - start - 1;
            if (freeSpace >= size)
            {
                return start;
            }
        }
    }

    private static (int Start, int End, int Size)? FindFile(int?[] diskMap, int id)
    {
        var start = Array.IndexOf(diskMap, id);
        if (start == -1)
        {
            return null;
        }

        var end = Array.LastIndexOf(diskMap, id);
        var size = end - start + 1;
        if (size <= 0)
        {
            return null;
        }

        return (start, end, size);
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
                var items = Enumerable.Repeat<int?>(null, count);
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