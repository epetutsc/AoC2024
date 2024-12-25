using System.IO.Abstractions;
using _13;

const string file = @"C:\Users\ewald\Dropbox\Advent of Code\2024\13\input.txt";

var reader = new InputReader(new FileSystem());
var machines = await reader.ReadFileAsync(file);

var result = machines
    .Select(m => m.MoveToPrize())
    .Where(result => result is not null)
    .Sum(result => result.TotalTokens);

Console.WriteLine(result);
