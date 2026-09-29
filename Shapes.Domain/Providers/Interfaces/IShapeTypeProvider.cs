using Shapes.Domain.Enums;
using Shapes.Domain.Models;

namespace Shapes.Domain.Providers.Interfaces;

public interface IShapeTypeProvider
{
    IReadOnlyList<ShapeType> GetAvailableShapes();

    IReadOnlyList<ShapeParameterDefinition> GetParametersForShape(ShapeType shapeType);
}