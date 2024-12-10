using System.IO.Abstractions;
using _09;

const string file = @"C:\Users\ewald\Dropbox\Advent of Code\2024\9\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
var diskMap = new DiskMap(input);
var result = diskMap.Checksum();
Console.WriteLine(result);