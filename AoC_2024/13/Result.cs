namespace _13;

public record Result(int CountA, int CountB)
{
    public double TotalTokens => CountA * Machine.TokensA + CountB * Machine.TokensB;
}
