using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.Application.Services.Interfaces;

public interface IDialogService
{
    public IShape? ShowAddShapeDialog();
}