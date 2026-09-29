using System.Globalization;
using System.Windows.Data;
using Shapes.App.Consts;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.App.Converters;

public class ShapeToDescriptionConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is IShape shape)
        {
            return shape.GetDescription();
        }

        return string.Empty;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException(ErrorMessages.BackConvertError);
    }
}