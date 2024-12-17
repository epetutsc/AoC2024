using System.IO.Abstractions;
using _13;

const string file = @"D:\dev\private\AoC2024\13\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
Console.WriteLine();

