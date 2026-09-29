namespace Shapes.Domain.Shapes.Interfaces;

public interface ITriangle : IShape
{
    public double SideA { get; }

    public double SideB { get; }

    public double SideC { get; }
}