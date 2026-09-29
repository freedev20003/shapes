using Shapes.Domain.Enums;

namespace Shapes.Domain.Shapes.Interfaces;

public interface IShape
{
    public ShapeType Type { get; }

    public double GetArea();

    public double GetPerimeter();

    public string GetDescription();
}