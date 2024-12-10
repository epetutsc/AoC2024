using FluentAssertions;

namespace _09.Tests;

public class DiskMapTests
{
    [Fact]
    public void CanExplodeDiskMap()
    {
        const string input = "12345";
        var expected = new int?[] { 0, null, null, 1, 1, 1, null, null, null, null, 2, 2, 2, 2, 2 };
        var diskMap = new DiskMap(input);
        var result = diskMap.Explode();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CanCompactDiskMap()
    {
        const string input = "12345";
        var expected = new int?[] { 0, 2, 2, 1, 1, 1, 2, 2, 2, null, null, null, null, null, null };
        var diskMap = new DiskMap(input);
        var result = diskMap.Compact();
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CanCalculateChecksum()
    {
        const string input = "2333133121414131402";
        var expected = 1928;
        var diskMap = new DiskMap(input);
        var result = diskMap.Checksum();
        result.Should().Be(expected);
    }
}
