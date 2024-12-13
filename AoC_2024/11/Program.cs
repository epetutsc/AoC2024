using System.IO.Abstractions;
using _11;

const string file = @"C:\Users\ewald\Dropbox\Advent of Code\2024\11\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
Console.WriteLine(input.Count(25));
Console.WriteLine(input.Count(75));

