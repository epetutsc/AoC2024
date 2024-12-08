namespace _06;

public class Guard
{
    public Position Position { get; private set; }
    public char Direction { get; private set; }

    public Guard(Map map)
    {
        Position = FindMe(map);
        Direction = map.Get(Position)!.Value;
    }
    
    public Guard(Position position, char direction)
    {
        Position = position;
        Direction = direction;
    }

    private static Position FindMe(Map map)
    {
        var position = map.Find('^')
               ?? map.Find('>')
               ?? map.Find('v')
               ?? map.Find('<')
               ?? throw new GuardNotFoundException();
        return new Position(position.Row, position.Column);
    }

    public static Position PeekMove(Position position, char direction)
    {
        return direction switch
        {
            '^' => position.Up(),
            'v' => position.Down(),
            '<' => position.Left(),
            '>' => position.Right(),
            _ => throw new ArgumentException("Invalid guard direction", nameof(direction))
        };
    }

    public Position PeekMove(char? direction = null)
    {
        direction ??= Direction;
        return PeekMove(Position, direction.Value);
    }

    public void Move()
    {
        Position = PeekMove();  
    }
    
    public char PeekTurn()
    {
        return Direction switch
        {
            '^' => '>',
            '>' => 'v',
            'v' => '<',
            '<' => '^',
            _ => throw new ArgumentException("Invalid guard direction", nameof(Direction))
        };
    }

    public void Turn()
    {
        Direction = PeekTurn();
    }
}
