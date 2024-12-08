namespace _06;

public record Position(int Row, int Column)
{
    public Position Up() => this with { Row = Row - 1 };
    
    public Position Down() => this with { Row = Row + 1 };

    public Position Left() => this with { Column = Column - 1 };
    
    public Position Right() => this with { Column = Column + 1 };
}