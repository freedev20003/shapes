using System.Globalization;
using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Shapes;

public class Rectangle : BaseShape, IRectangle
{
    public Rectangle(double width, double height)
    {
        if (width <= 0)
        {
            throw new ArgumentException(ValidationMessages.WidthMustBePositive, nameof(width));
        }

        if (height <= 0)
        {
            throw new ArgumentException(ValidationMessages.HeightMustBePositive, nameof(height));
        }

        Width = width;
        Height = height;
        Type = ShapeType.Rectangle;
    }

    public double Width { get; }

    public double Height { get; }

    public override double GetArea() => Width * Height;

    public override double GetPerimeter() => 2 * (Width + Height);

    public override string GetDescription() => string.Format(
        CultureInfo.InvariantCulture,
        ShapeDescriptions.Rectangle,
        Width,
        Height,
        GetArea(),
        GetPerimeter());
}