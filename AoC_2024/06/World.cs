namespace _06;

public class World
{
    public Map Map { get; }
    public Guard Guard { get; }

    private readonly HashSet<(Position Position, char Direction)> _trace = new();
    private readonly HashSet<Position> _obstructions = new();
    private readonly (Position Position, char Direction) _start;

    public World(string input)
    {
        Map = Map.FromString(input);
        Guard = new Guard(Map);
        _start = (Guard.Position, Guard.Direction);
    }

    private World(string input, Position guardPosition, char direction)
    {
        Map = Map.FromString(input);
        Guard = new Guard(guardPosition, direction);
    }

    public StepResult Step()
    {
        if (!_trace.Add((Guard.Position, Guard.Direction)))
        {
            return StepResult.LoopDetected;
        }
        
        var nextField = Guard.PeekMove();
        var ch = Map.Get(nextField);
        if (ch is '#')
        {
            Guard.Turn();
            return StepResult.TurnRight;
        }

        Guard.Move();
        if (Map.IsOutOfBounds(Guard.Position))
        {
            return StepResult.Finished;
        }

        Map.Set(Guard.Position, Guard.Direction);
        return IsVisited(ch)
            ? StepResult.VisitedAlready
            : StepResult.Success;
    }

    private void AddObstruction()
    {
        var clone = new World(Map.ToString(), _start.Position, _start.Direction);
        var nextField = Guard.PeekMove();
        if (clone.Map.IsOutOfBounds(nextField))
        {
            return;
        }
        
        clone.Map.Set(nextField, '#');
        if (clone.RunScout())
        {
            _obstructions.Add(nextField);
        }
    }
    
    private static bool IsVisited(char? ch)
    {
        return new char?[] { '^', '>', 'v', '<' }.Contains(ch);
    }

    public (int Steps, int ObstructionPositions)? Run()
    {
        var counter = 0;
        while (true)
        {
            AddObstruction();
            var result = Step();
            //Console.WriteLine(Map.ToString());
            //Console.WriteLine(counter);
            //Console.WriteLine(_obstructions.Count);
            
            if (result == StepResult.LoopDetected)
            {
                return null;
            }

            if (result != StepResult.VisitedAlready && result != StepResult.TurnRight)
            {
                counter++;
            }

            if (result == StepResult.Finished)
            {
                return (counter, _obstructions.Count);
            }
        }
    }
    
    public bool RunScout()
    {
        while (true)
        {
            var result = Step();
            if (result == StepResult.LoopDetected)
            {
                return true;
            }

            if (result == StepResult.Finished)
            {
                return false;
            }
        }
    }
}
