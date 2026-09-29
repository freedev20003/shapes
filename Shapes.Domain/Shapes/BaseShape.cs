using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Shapes;

public abstract class BaseShape : IShape
{
    public ShapeType Type { get; protected set; }

    public abstract double GetArea();

    public abstract double GetPerimeter();

    public virtual string GetDescription() => ShapeDescriptions.Shape;
}