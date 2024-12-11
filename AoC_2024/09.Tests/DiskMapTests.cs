using FluentAssertions;

namespace _09.Tests;

public class DiskMapTests
{
    [Theory]
    [InlineData("12345", 0, null, null, 1, 1, 1, null, null, null, null, 2, 2, 2, 2, 2)]
    [InlineData("2020", 0, 0, 1, 1)]
    [InlineData("0202", null, null, null, null)]
    [InlineData("1212", 0, null, null, 1, null, null)]
    public void CanExplodeDiskMap(string input, params int?[] expected)
    {
        var diskMap = new DiskMap(input);
        var result = diskMap.Explode();
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("12345", 0, 2, 2, 1, 1, 1, 2, 2, 2, null, null, null, null, null, null)]
    [InlineData("0202", null, null, null, null)]
    [InlineData("2020", 0, 0, 1, 1)]
    [InlineData("1212", 0, 1, null, null, null, null)]
    [InlineData("2333133121414131402", 0, 0, 9, 9, 8, 1, 1, 1, 8, 8, 8, 2, 7, 7, 7, 3, 3, 3, 6, 4, 4, 6, 5, 5 ,5, 5, 6 ,6 , null, null, null, null, null, null, null, null, null, null, null, null, null, null)]
    public void CanCompactDiskMap(string input, params int?[] expected)
    {
        var diskMap = new DiskMap(input);
        var result = diskMap.Compact();
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("12345", 0, null, null, 1, 1, 1, null, null, null, null, 2, 2, 2, 2, 2)]
    [InlineData("2020", 0, 0, 1, 1)]
    [InlineData("0202", null, null, null, null)]
    [InlineData("1212", 0, 1, null, null, null, null)]
    [InlineData("2333133121414131402", 0, 0, 9, 9, 2, 1, 1, 1, 7, 7, 7, null, 4, 4, null, 3, 3, 3, null, null, null, null, 5, 5, 5, 5, null, 6, 6, 6, 6, null, null, null, null, null, 8, 8, 8, 8, null, null)]
    public void CanCompactWithoutFragmentation(string input, params int?[] expected)
    {
        var diskMap = new DiskMap(input);
        var result = diskMap.CompactWithoutFragmentation();
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData("12345", 60)]
    [InlineData("2020", 5)]
    [InlineData("0202", 0)]
    [InlineData("1212", 1)]
    [InlineData("2333133121414131402", 1928)]
    public void CanCalculateChecksum(string input, int expected)
    {
        var diskMap = new DiskMap(input);
        var result = diskMap.Checksum();
        result.Should().Be(expected);
    }
}
