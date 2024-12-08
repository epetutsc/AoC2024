namespace _06;

public class World
{
    public Map Map { get; }
    public Guard Guard { get; }

    private readonly List<(Position Position, char Direction)> _trace = new();
    
    public World(string input)
    {
        Map = Map.FromString(input);
        Guard = new Guard(Map);
    }
    
    public World(string input, Position guardPosition, char direction)
    {
        Map = Map.FromString(input);
        Guard = new Guard(guardPosition, direction);
    }

    public StepResult Step()
    {
        var nextField = Guard.PeekMove();
        if (Map.IsOutOfBounds(nextField))
        {
            return StepResult.Finished;
        }

        if (_trace.Contains((nextField, Guard.Direction)))
        {
            return StepResult.LoopDetected;
        }
        
        var ch = Map.Get(nextField);
        if (ch is '#')
        {
            Guard.Turn();
            return StepResult.TurnRight;
        }

        Guard.Move();
        Map.Set(nextField, Guard.Direction);
        _trace.Add((nextField, Guard.Direction));
        
        return IsVisited(ch)
            ? StepResult.VisitedAlready
            : StepResult.Success;
    }

    private bool CouldCreateLoop()
    {
        var clone = new World(Map.ToString(), Guard.Position, Guard.Direction);
        var nextField = clone.Guard.PeekMove();
        if (clone.Map.IsOutOfBounds(nextField))
        {
            return false;
        }
        
        clone.Map.Set(nextField, '#');
        return clone.RunScout();
    }
    
    private static bool IsVisited(char? ch)
    {
        return new char?[] { '^', '>', 'v', '<' }.Contains(ch);
    }

    public (int Steps, int ObstructionPositions)? Run()
    {
        var obstructions = 0;
        var counter = 0;
        while (true)
        {
            if (CouldCreateLoop())
            {
                obstructions++;
            }
            
            var result = Step();
            //Console.WriteLine(Map.ToString());
            Console.WriteLine(counter);
            Console.WriteLine(obstructions);
            
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
                return (counter, obstructions);
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