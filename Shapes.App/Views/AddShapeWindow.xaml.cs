using System.ComponentModel;
using System.Windows;
using Shapes.App.ViewModels;

namespace Shapes.App.Views;

public partial class AddShapeWindow : Window
{
    private readonly AddShapeViewModel _viewModel;

    public AddShapeWindow(AddShapeViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel ?? throw new System.ArgumentNullException(nameof(viewModel));
        DataContext = _viewModel;

        _viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(AddShapeViewModel.DialogResult))
        {
            DialogResult = _viewModel.DialogResult;
        }
    }
}