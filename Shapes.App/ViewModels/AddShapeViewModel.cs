using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shapes.App.Consts;
using Shapes.Domain.Consts;
using Shapes.Domain.Enums;
using Shapes.Domain.Factories.Interfaces;
using Shapes.Domain.Providers.Interfaces;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.App.ViewModels;

public partial class AddShapeViewModel : ObservableObject
{
    private readonly IShapeFactory _shapeFactory;

    private readonly IShapeTypeProvider _shapeTypeProvider;

    private readonly ObservableCollection<ShapeType> _availableShapeTypes;

    private readonly ObservableCollection<ShapeParameterViewModel> _parameters;

    [ObservableProperty]
    private ShapeType _selectedShapeType;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    [ObservableProperty]
    private bool? _dialogResult;

    [ObservableProperty]
    private IShape? _resultShape;

    public AddShapeViewModel(IShapeFactory shapeFactory, IShapeTypeProvider shapeTypeProvider)
    {
        _shapeFactory = shapeFactory ?? throw new ArgumentNullException(nameof(shapeFactory));
        _shapeTypeProvider = shapeTypeProvider ?? throw new ArgumentNullException(nameof(shapeTypeProvider));

        _availableShapeTypes = new ObservableCollection<ShapeType>(_shapeTypeProvider.GetAvailableShapes());
        _parameters = new ObservableCollection<ShapeParameterViewModel>();

        if (_availableShapeTypes.Count > 0)
        {
            SelectedShapeType = _availableShapeTypes[0];
        }

        UpdateParameters();
    }

    public ObservableCollection<ShapeType> AvailableShapeTypes => _availableShapeTypes;

    public ObservableCollection<ShapeParameterViewModel> Parameters => _parameters;

    [RelayCommand]
    private void Save()
    {
        ErrorMessage = string.Empty;

        if (!TryValidateParameters(out var values))
        {
            return;
        }

        try
        {
            ResultShape = CreateShape(values);
            DialogResult = true;
        }
        catch (ArgumentException exception)
        {
            ErrorMessage = exception.Message;
        }
    }

    private bool TryValidateParameters(out Dictionary<string, double> values)
    {
        values = new Dictionary<string, double>();

        foreach (var parameter in _parameters)
        {
            if (!double.TryParse(parameter.Value, NumberStyles.Float, CultureInfo.CurrentCulture, out var value))
            {
                ErrorMessage = ErrorMessages.DigitParseError;
                return false;
            }

            if (value <= 0)
            {
                ErrorMessage = ErrorMessages.AddDiginMoreThenZero;
                return false;
            }

            values[parameter.Definition.Name] = value;
        }

        ErrorMessage = string.Empty;

        return true;
    }

    [RelayCommand]
    private void Cancel()
    {
        DialogResult = false;
    }

    partial void OnSelectedShapeTypeChanged(ShapeType value)
    {
        ErrorMessage = string.Empty;
        UpdateParameters();
    }

    private void UpdateParameters()
    {
        _parameters.Clear();

        if (_availableShapeTypes.Count == 0)
        {
            return;
        }

        var definitions = _shapeTypeProvider.GetParametersForShape(SelectedShapeType);

        foreach (var definition in definitions)
        {
            _parameters.Add(new ShapeParameterViewModel(definition));
        }
    }

    private IShape CreateShape(IReadOnlyDictionary<string, double> values) =>
        SelectedShapeType switch
        {
            ShapeType.Circle => _shapeFactory.CreateCircle(values[ShapeParameterNames.Radius]),
            ShapeType.Square => _shapeFactory.CreateSquare(values[ShapeParameterNames.Side]),
            ShapeType.Rectangle => _shapeFactory.CreateRectangle(values[ShapeParameterNames.Width], values[ShapeParameterNames.Height]),
            ShapeType.Triangle => _shapeFactory.CreateTriangle(values[ShapeParameterNames.SideA], values[ShapeParameterNames.SideB], values[ShapeParameterNames.SideC]),
            _ => throw new ArgumentOutOfRangeException(
                nameof(SelectedShapeType),
                SelectedShapeType,
                ValidationMessages.ShapeTypeNotSupported)
        };
}