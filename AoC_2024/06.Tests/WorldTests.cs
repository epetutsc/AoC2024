using FluentAssertions;

namespace _06.Tests;

public class WorldTests
{
    [Theory]
    [InlineData('^')]
    [InlineData('>')]
    [InlineData('v')]
    [InlineData('<')]
    public void Guard_can_move(char direction)
    {
        var input = $"""
                     .     .     .
                     .{direction}.
                     .     .     .
                     """;

        var world = new World(input);
        var result = world.Step();
        result.Should().Be(StepResult.Success);
    }

    [Theory]
    [InlineData('^')]
    [InlineData('>')]
    [InlineData('v')]
    [InlineData('<')]
    public void Guard_can_move_twice(char direction)
    {
        var input = $"""
                     ..     .     ..
                     ..     .     ..
                     ..{direction}..
                     ..     .     ..
                     ..     .     ..
                     """;

        var world = new World(input);
        world.Step();
        var result = world.Step();
        result.Should().Be(StepResult.Success);
    }

    [Theory]
    [InlineData('^')]
    [InlineData('>')]
    [InlineData('v')]
    [InlineData('<')]
    public void Guard_can_not_move_twice(char direction)
    {
        var input = $"""
                     ..    #      ..
                     ..    .      ..
                     #.{direction}.#
                     ..    .      ..
                     ..    #      ..
                     """;

        var world = new World(input);
        world.Step();
        var result = world.Step();
        result.Should().Be(StepResult.TurnRight);
    }

    [Theory]
    [InlineData('^')]
    [InlineData('>')]
    [InlineData('v')]
    [InlineData('<')]
    public void Guard_turns_right(char direction)
    {
        var input = $"""
                     .     #     .
                     #{direction}#
                     .     #     .
                     """;

        var world = new World(input);
        var result = world.Step();
        result.Should().Be(StepResult.TurnRight);
    }
    
    [Theory]
    [InlineData('^')]
    [InlineData('>')]
    [InlineData('v')]
    [InlineData('<')]
    public void World_can_detect_visited_positions(char direction)
    {
        var input = $"""
                     .     .     .
                     .{direction}.
                     .     .     .
                     """;

        var world = new World(input);
        var position = world.Guard.PeekMove();
        world.Map.Set(position, direction);
        var result = world.Step();
        result.Should().Be(StepResult.VisitedAlready);
    }

    [Fact]
    public void Guards_position_must_be_updated_in_the_map()
    {
        const string input = """
                             ...
                             .^.
                             ...
                             """;

        var world = new World(input);
        world.Step();
        world.Map.Get(new Position(0, 1)).Should().Be('^');
    }

    [Fact]
    public void World_can_count_steps_to_finish__simple_direct_way()
    {
        const string input = """
                             ...
                             .^.
                             ...
                             """;

        var world = new World(input);
        var count = world.Run();
        count.HasValue.Should().BeTrue();
        count!.Value.Steps.Should().Be(2);
    }
    
    [Fact]
    public void World_can_count_steps()
    {
        const string input = """
            ....#.....
            .........#
            ..........
            ..#.......
            .......#..
            ..........
            .#..^.....
            ........#.
            #.........
            ......#...
            """;

        var world = new World(input);
        var count = world.Run();
        count.HasValue.Should().BeTrue();
        count!.Value.Steps.Should().Be(41);
    }
    
    [Fact]
    public void World_can_count_possible_loops()
    {
        const string input = """
                             ....#.....
                             .........#
                             ..........
                             ..#.......
                             .......#..
                             ..........
                             .#..^.....
                             ........#.
                             #.........
                             ......#...
                             """;

        var world = new World(input);
        var count = world.Run();
        count.HasValue.Should().BeTrue();
        count!.Value.ObstructionPositions.Should().Be(6);
    }
}
