using _03;
using System.IO.Abstractions;

const string file = @"D:\dev\private\AoC2024\3a\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.GetMultiplicationsAsync(file);
var calculator = new Calculator(input);

Console.WriteLine(calculator.AddMultiplications());
