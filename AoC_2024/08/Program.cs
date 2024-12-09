using System.IO.Abstractions;
using _08;

const string file = @"D:\dev\private\AoC2024\8\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
var antinodes = new Antinodes(input);
var result = antinodes.Find().ToList();
Console.WriteLine(result.Count);