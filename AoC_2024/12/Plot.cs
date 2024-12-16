using System.Drawing;

namespace _12;

public class Plot(string plant, Point point = default)
{
    public Region? Region { get; set; }
    public string Plant => plant;
    public Point Position => point;

    public IEnumerable<string> SideX
    {
        get
        {
            var left = this;
            while (!IsSide(left.Left) && IsSide(left.Left!.Top))
            {
                left = left.Left;
            }

            var right = this;
            while (!IsSide(right.Right) && IsSide(right.Right!.Top))
            {
                right = right.Right;
            }

            if (IsSide(Top) && IsSide(left.Top) && IsSide(right.Top))
            {
                yield return $"XT_{left.Position.Y}_{left.Position.X}-XT_{right.Position.Y}_{right.Position.X}";
            }

            left = this;
            while (!IsSide(left.Left) && IsSide(left.Left!.Bottom))
            {
                left = left.Left;
            }

            right = this;
            while (!IsSide(right.Right) && IsSide(right.Right!.Bottom))
            {
                right = right.Right;
            }

            if (IsSide(Bottom) && IsSide(left.Bottom) && IsSide(right.Bottom))
            {
                yield return $"XB_{left.Position.Y}_{left.Position.X}-XB_{right.Position.Y}_{right.Position.X}";
            }
        }
    }

    public IEnumerable<string> SideY
    {
        get
        {
            var top = this;
            while (!IsSide(top.Top) && IsSide(top.Top!.Left))
            {
                top = top.Top;
            }

            var bottom = this;
            while (!IsSide(bottom.Bottom) && IsSide(bottom.Bottom!.Left))
            {
                bottom = bottom.Bottom;
            }

            if (IsSide(Left) && IsSide(top.Left) && IsSide(bottom.Left))
            {
                yield return $"YL_{top.Position.Y}_{top.Position.X}-YL_{bottom.Position.Y}_{bottom.Position.X}";
            }

            top = this;
            while (!IsSide(top.Top) && IsSide(top.Top!.Right))
            {
                top = top.Top;
            }

            bottom = this;
            while (!IsSide(bottom.Bottom) && IsSide(bottom.Bottom!.Right))
            {
                bottom = bottom.Bottom;
            }

            if (IsSide(Right) && IsSide(top.Right) && IsSide(bottom.Right))
            {
                yield return $"YR_{top.Position.Y}_{top.Position.X}-YR_{bottom.Position.Y}_{bottom.Position.X}";
            }
        }
    }

    public Plot? Left { get; set; }
    public Plot? Top { get; set; }
    public Plot? Right { get; set; }
    public Plot? Bottom { get; set; }
    public int Perimeter => new[] { IsSide(Left), IsSide(Top), IsSide(Right), IsSide(Bottom)}.Count(o => o);

    private bool IsSide(Plot? neighbor)
    {
        return neighbor is null || neighbor.Plant != Plant;
    }

    public override string ToString()
    {
        return Plant;
    }
}
