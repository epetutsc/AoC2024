using System.Drawing;
using System.IO.Abstractions;
using _10;

const string file = @"D:\dev\private\AoC2024\10\input.txt";

var reader = new InputReader(new FileSystem());
var input = await reader.ReadFileAsync(file);
var map = new Map(input);
IEnumerable<Point> trailheads = map.FindTrailheads().ToList();
var score = map.GetScore(trailheads);
var rating = map.GetRating(trailheads);
Console.WriteLine(score);
Console.WriteLine(rating);
