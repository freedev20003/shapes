using System.Globalization;
using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Shapes;

public class Square : BaseShape, ISquare
{
    public Square(double side)
    {
        if (side <= 0)
        {
            throw new ArgumentException(ValidationMessages.SideMustBePositive, nameof(side));
        }

        Side = side;
        Type = ShapeType.Square;
    }

    public double Side { get; }

    public override double GetArea() => Math.Pow(Side, 2);

    public override double GetPerimeter() => 4 * Side;

    public override string GetDescription() => string.Format(
        CultureInfo.InvariantCulture,
        ShapeDescriptions.Square,
        Side,
        GetArea(),
        GetPerimeter());
}