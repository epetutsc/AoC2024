using System.IO.Abstractions;
using _12;

const string file = @"D:\dev\private\AoC2024\12\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
var plots = input.ConnectPlots();
var regions = plots.CreateRegions();

var total = regions.Sum(r => r.Price);
Console.WriteLine(total);

var total2 = regions.Sum(r => r.Price2);
Console.WriteLine(total2);

