using FluentAssertions;

namespace _05.Tests;

public class UpdateValidatorTests
{
    private List<(int Left, int Right)> _rules = new List<(int Left, int Right)>
    {
        (47, 53),
        (97, 13),
        (97, 61),
        (97, 47),
        (75, 29),
        (61, 13),
        (75, 53),
        (29, 13),
        (97, 29),
        (53, 29),
        (61, 53),
        (97, 53),
        (61, 29),
        (47, 13),
        (75, 47),
        (97, 75),
        (47, 61),
        (75, 61),
        (47, 29),
        (75, 13),
        (53, 13)
    };

    [Theory]
    [InlineData(new[] { 75, 47, 61, 53, 29 }, true)]
    [InlineData(new[] { 97, 61, 53, 29, 13 }, true)]
    [InlineData(new[] { 75, 29, 13 }, true)]
    [InlineData(new[] { 75, 97, 47, 61, 53 }, false)]
    [InlineData(new[] { 61, 13, 29 }, false)]
    [InlineData(new[] { 97, 13, 75, 29, 47 }, false)]
    public void CanValidateUpdates(int[] update, bool correct)
    {
        var validator = new UpdateValidator(_rules);
        validator.Validate(update).Should().Be(correct);
    }

    [Theory]
    [InlineData(new[] { 75, 97, 47, 61, 53 })]
    [InlineData(new[] { 61, 13, 29 })]
    [InlineData(new[] { 97, 13, 75, 29, 47 })]
    public void CanCorrect(int[] update)
    {
        var validator = new UpdateValidator(_rules);
        var result = validator.Correct(update);
        validator.Validate(result).Should().BeTrue();
    }
}
