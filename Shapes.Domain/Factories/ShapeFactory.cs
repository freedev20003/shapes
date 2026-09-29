using Shapes.Domain.Factories.Interfaces;
using Shapes.Domain.Shapes;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Domain.Factories;

public class ShapeFactory : IShapeFactory
{
    public ICircle CreateCircle(double radius) => new Circle(radius);

    public ISquare CreateSquare(double side) => new Square(side);

    public IRectangle CreateRectangle(double width, double height) => new Rectangle(width, height);

    public ITriangle CreateTriangle(double sideA, double sideB, double sideC) => new Triangle(sideA, sideB, sideC);
}