using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Application.Services.Interfaces;

public interface IShapesService
{
    public IReadOnlyList<IShape> GetShapes();

    public void AddShape(IShape shape);

    public bool RemoveShape(IShape shape);

    public void ClearShapes();
}