using System.Globalization;
using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Shapes;

public class Circle : BaseShape, ICircle
{
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException(ValidationMessages.RadiusMustBePositive, nameof(radius));
        }

        Radius = radius;
        Type = ShapeType.Circle;
    }

    public double Radius { get; }

    public override double GetArea() => Math.PI * Math.Pow(Radius, 2);

    public override double GetPerimeter() => 2 * Math.PI * Radius;

    public override string GetDescription() => string.Format(
        CultureInfo.InvariantCulture,
        ShapeDescriptions.Circle,
        Radius,
        GetArea(),
        GetPerimeter());
}