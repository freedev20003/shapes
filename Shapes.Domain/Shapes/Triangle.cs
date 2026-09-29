using System.Globalization;
using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Shapes;

public class Triangle : BaseShape, ITriangle
{
    public Triangle(double sideA, double sideB, double sideC)
    {
        ValidateSide(sideA, nameof(sideA));
        ValidateSide(sideB, nameof(sideB));
        ValidateSide(sideC, nameof(sideC));

        if (!IsValidTriangle(sideA, sideB, sideC))
        {
            throw new ArgumentException(ValidationMessages.TriangleInequalityViolated);
        }

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        Type = ShapeType.Triangle;
    }

    public double SideA { get; }

    public double SideB { get; }

    public double SideC { get; }

    public override double GetArea()
    {
        var semiPerimeter = GetPerimeter() / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }

    public override double GetPerimeter() => SideA + SideB + SideC;

    public override string GetDescription() => string.Format(
        CultureInfo.InvariantCulture,
        ShapeDescriptions.Triangle,
        SideA,
        SideB,
        SideC,
        GetArea(),
        GetPerimeter());

    private static void ValidateSide(double value, string paramName)
    {
        if (value <= 0)
        {
            throw new ArgumentException(ValidationMessages.TriangleSideMustBePositive, paramName);
        }
    }

    private static bool IsValidTriangle(double sideA, double sideB, double sideC) =>
        sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
}