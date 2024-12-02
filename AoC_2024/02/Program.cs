using _02;
using System.IO.Abstractions;

const string File = @"C:\Users\ewald\Dropbox\Advent of Code\2024\2a\input.txt";

var reader = new InputReader(new FileSystem());
await reader.ReadFileAsync(File);
var dataAnalyzer = new DataAnalyzer();

var count = dataAnalyzer.CountSafe(reader.Reports);
Console.WriteLine(count);
