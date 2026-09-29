
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shapes.Application.Services.Interfaces;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.App.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IShapesService _shapesService;

    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private ObservableCollection<IShape> _shapeItems;

    public MainWindowViewModel(IShapesService shapesService, IDialogService dialogService)
    {
        _shapesService = shapesService ?? throw new ArgumentNullException(nameof(shapesService));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        _shapeItems = new ObservableCollection<IShape>(_shapesService.GetShapes());
    }

    [RelayCommand]
    private void AddShape()
    {
        var shape = _dialogService.ShowAddShapeDialog();

        if (shape is not null)
        {
            _shapesService.AddShape(shape);
            ShapeItems.Add(shape);
        }
    }

    [RelayCommand]
    private void DeleteShape(IShape? shape)
    {
        if (shape is null)
        {
            return;
        }

        if (_shapesService.RemoveShape(shape))
        {
            ShapeItems.Remove(shape);
        }
    }
}