using System.IO.Abstractions;
using _04;

const string file = @"D:\dev\private\AoC2024\4\input.txt";

var reader = new InputReader(new FileSystem());
await reader.ReadFileAsync(file);
var search = new WordSearch(reader.Input);

var count1 = search.CountWord("XMAS");
var count2 = search.CountX("MAS");
Console.WriteLine(count1);
Console.WriteLine(count2);
