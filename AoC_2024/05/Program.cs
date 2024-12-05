using System.ComponentModel.DataAnnotations;
using System.IO.Abstractions;
using _05;

const string file = @"C:\Users\ewald\Dropbox\Advent of Code\2024\5\input.txt";

var reader = new InputReader(new FileSystem());
await reader.ReadFileAsync(file);
var validator = new UpdateValidator(reader.Rules);
var validUpdates = reader.Updates.Where(validator.Validate).ToList();
var invalidUpdates = reader.Updates.Except(validUpdates).ToList();

var correctedUpdates = validator.Correct(invalidUpdates);

var calculatorValidUpdates = new Calculator(validUpdates);
var calculatorCorrectedUpdates = new Calculator(correctedUpdates);

Console.WriteLine(calculatorValidUpdates.Sum);
Console.WriteLine(calculatorCorrectedUpdates.Sum);
