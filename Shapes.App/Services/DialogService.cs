using Shapes.Application.Services.Interfaces;
using Shapes.Domain.Factories.Interfaces;
using Shapes.Domain.Providers.Interfaces;
using Shapes.Domain.Shapes.Interfaces;
using Shapes.App.ViewModels;
using Shapes.App.Views;

namespace Shapes.App.Services;

public class DialogService : IDialogService
{
    private readonly IShapeFactory _shapeFactory;

    private readonly IShapeTypeProvider _shapeTypeProvider;

    public DialogService(IShapeFactory shapeFactory, IShapeTypeProvider shapeTypeProvider)
    {
        _shapeFactory = shapeFactory ?? throw new ArgumentNullException(nameof(shapeFactory));
        _shapeTypeProvider = shapeTypeProvider ?? throw new ArgumentNullException(nameof(shapeTypeProvider));
    }

    public IShape? ShowAddShapeDialog()
    {
        var viewModel = new AddShapeViewModel(_shapeFactory, _shapeTypeProvider);

        var window = new AddShapeWindow(viewModel)
        {
            Owner = System.Windows.Application.Current.MainWindow
        };

        window.ShowDialog();

        return viewModel.DialogResult == true ? viewModel.ResultShape : null;
    }
}