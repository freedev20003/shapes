using CommunityToolkit.Mvvm.ComponentModel;
using Shapes.Domain.Models;

namespace Shapes.App.ViewModels;

public partial class ShapeParameterViewModel : ObservableObject
{
    private readonly ShapeParameterDefinition _definition;

    [ObservableProperty]
    private string _value = string.Empty;

    public ShapeParameterViewModel(ShapeParameterDefinition definition)
    {
        _definition = definition ?? throw new ArgumentNullException(nameof(definition));
    }

    public ShapeParameterDefinition Definition => _definition;
}