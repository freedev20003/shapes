using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Models;
using Shapes.Domain.Providers.Interfaces;

namespace Shapes.Domain.Providers;

public class ShapeTypeProvider : IShapeTypeProvider
{
    private static readonly Dictionary<ShapeType, IReadOnlyList<ShapeParameterDefinition>> ParametersCache = new()
    {
        [ShapeType.Circle] = new List<ShapeParameterDefinition>
        {
            new(ShapeParameterNames.Radius, "Радиус")
        },
        [ShapeType.Square] = new List<ShapeParameterDefinition>
        {
            new(ShapeParameterNames.Side, "Сторона")
        },
        [ShapeType.Rectangle] = new List<ShapeParameterDefinition>
        {
            new(ShapeParameterNames.Width, "Ширина"),
            new(ShapeParameterNames.Height, "Высота")
        },
        [ShapeType.Triangle] = new List<ShapeParameterDefinition>
        {
            new(ShapeParameterNames.SideA, "Сторона A"),
            new(ShapeParameterNames.SideB, "Сторона B"),
            new(ShapeParameterNames.SideC, "Сторона C")
        }
    };

    public IReadOnlyList<ShapeType> GetAvailableShapes() => Enum.GetValues<ShapeType>();

    public IReadOnlyList<ShapeParameterDefinition> GetParametersForShape(ShapeType shapeType)
    {
        if (!ParametersCache.TryGetValue(shapeType, out var parameters))
        {
            throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, ValidationMessages.ShapeTypeNotSupported);
        }

        return parameters;
    }
}