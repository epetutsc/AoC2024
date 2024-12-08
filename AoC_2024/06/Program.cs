using System.IO.Abstractions;
using _06;

const string file = @"D:\dev\private\AoC2024\6\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
var world = new World(input);
var count = world.Run();
Console.WriteLine(count);
