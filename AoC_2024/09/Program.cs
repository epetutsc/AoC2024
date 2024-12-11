using System.IO.Abstractions;
using _09;

const string file = @"D:\dev\private\AoC2024\9\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
var diskMap = new DiskMap(input);
var result1 = diskMap.Checksum();
var result2 = diskMap.ChecksumWithoutFragmentation();
Console.WriteLine(result1);
Console.WriteLine(result2);