using Shapes.Application.Services.Interfaces;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Application.Services;

public class ShapesService : IShapesService
{
    private readonly List<IShape> _shapes = new();

    public IReadOnlyList<IShape> GetShapes() => _shapes.AsReadOnly();

    public void AddShape(IShape shape)
    {
        if (shape is null)
        {
            throw new ArgumentNullException(nameof(shape));
        }

        _shapes.Add(shape);
    }

    public bool RemoveShape(IShape shape)
    {
        if (shape is null)
        {
            throw new ArgumentNullException(nameof(shape));
        }

        return _shapes.Remove(shape);
    }

    public void ClearShapes()
    {
        _shapes.Clear();
    }
}