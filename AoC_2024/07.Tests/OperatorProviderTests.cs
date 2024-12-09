using FluentAssertions;

namespace _07.Tests;

public class OperatorProviderTests
{
    [Fact]
    public void OperatorProvider_iterates_for_3_operators()
    {
        List<IReadOnlyList<Operator>> expected =
        [
            [Operator.Add, Operator.Add, Operator.Add],
            [Operator.Add, Operator.Add, Operator.Multiply],
            [Operator.Add, Operator.Multiply, Operator.Add],
            [Operator.Add, Operator.Multiply, Operator.Multiply],
            [Operator.Multiply, Operator.Add, Operator.Add],
            [Operator.Multiply, Operator.Add, Operator.Multiply],
            [Operator.Multiply, Operator.Multiply, Operator.Add],
            [Operator.Multiply, Operator.Multiply, Operator.Multiply],
            []
        ];

        var provider = new OperatorProvider(3, OperatorProvider.OperatorsPart1);
        var operators = Enumerable
            .Range(1, 9)
            .Select(_ => provider.TryNext(out var op) ? op : [])
            .ToList();

        operators.Should().BeEquivalentTo(expected);
    }
}