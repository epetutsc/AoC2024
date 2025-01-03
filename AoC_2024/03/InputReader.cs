﻿using System.IO.Abstractions;
using System.Text.RegularExpressions;

namespace _03;

public partial class InputReader(IFileSystem fileSystem)
{
    [GeneratedRegex(@"mul\((\d?\d?\d),(\d?\d?\d)\)")]
    private static partial Regex Mul();

    [GeneratedRegex(@"do\(\)")]
    private static partial Regex Do();

    [GeneratedRegex(@"don't\(\)")]
    private static partial Regex Dont();

    public async Task<IReadOnlyList<(int, int)>> GetMultiplicationsAsync(string file)
    {
        var content = await fileSystem.File.ReadAllTextAsync(file);

        var donts = Dont().Matches(content).Select(m => m.Index).ToList();
        var dos = Do().Matches(content).Select(m => m.Index).ToList();

        return Mul()
            .Matches(content)
            .Where(m => IsEnabled(m, dos, donts))
            .Select(match => (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)))
            .ToList();
    }

    private static bool IsEnabled(Match match, List<int> dos, List<int> donts)
    {
        var indexOfDont = donts.Where(i => i < match.Index).OrderByDescending(o => o).FirstOrDefault();
        if (indexOfDont == 0)
        {
            return true;
        }
        
        var indexOfDo = dos.Where(i => i < match.Index).OrderByDescending(o => o).FirstOrDefault();
        return indexOfDo > indexOfDont;
    }
}
