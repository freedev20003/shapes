using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Factories.Interfaces;

public interface IShapeFactory
{
    ICircle CreateCircle(double radius);

    ISquare CreateSquare(double side);

    IRectangle CreateRectangle(double width, double height);

    ITriangle CreateTriangle(double sideA, double sideB, double sideC);
}