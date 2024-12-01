using _01;
using System.IO.Abstractions;

const string File = @"C:\Users\ewald\Dropbox\Advent of Code\2024\1a\input.txt";

var reader = new InputReader(new FileSystem());
await reader.ReadFileAsync(File);
var distance = new Distance();
var totalDistaince = distance.CalculateTotal(reader.Column1, reader.Column2);

var similarity = new Similarity(reader.Column2);
var totalSimilarity = similarity.CalculateTotal(reader.Column1);

Console.WriteLine(totalDistaince);
Console.WriteLine(totalSimilarity);
