using System.Globalization;
using System.Windows.Data;
using Shapes.App.Consts;
using Shapes.Domain.Enums;

namespace Shapes.App.Converters;

public class ShapeTypeToStringConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ShapeType shapeType)
        {
            return shapeType switch
            {
                ShapeType.Circle => "Круг",
                ShapeType.Square => "Квадрат",
                ShapeType.Rectangle => "Прямоугольник",
                ShapeType.Triangle => "Треугольник",
                _ => shapeType.ToString()
            };
        }

        return string.Empty;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException(ErrorMessages.BackConvertError);
    }
}