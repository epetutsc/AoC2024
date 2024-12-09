using System.IO.Abstractions;
using _07;

const string file = @"D:\dev\private\AoC2024\7\input.txt";

var reader = new InputReader(new FileSystem());
var lines = await reader.ReadFileAsync(file);

// part 1
var calc = new Calculator(lines, OperatorProvider.OperatorsPart1);
var sum = calc.Sum();
Console.WriteLine(sum);

// part 2
calc = new Calculator(lines, OperatorProvider.OperatorsPart2);
sum = calc.Sum();
Console.WriteLine(sum);
