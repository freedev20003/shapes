using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Shapes.App.Consts;
using Shapes.Domain.Shapes.Interfaces;

namespace Shapes.App.Converters;

public class ShapeToVisualConverter : IValueConverter
{
    private const double MaxDisplaySize = 160.0;

    private const double MinDisplaySize = 40.0;

    private const double StrokeWidth =  1;

    private static readonly System.Drawing.Color StrokeColor = System.Drawing.Color.Black;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ICircle circle)
        {
            return CreateCircle(circle);
        }

        if (value is ISquare square)
        {
            return CreateSquare(square);
        }

        if (value is IRectangle rectangle)
        {
            return CreateRectangle(rectangle);
        }

        if (value is ITriangle triangle)
        {
            return CreateTriangle(triangle);
        }

        return new TextBlock();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException(ErrorMessages.BackConvertError);
    }

    private static Ellipse CreateCircle(ICircle circle)
    {
        var size = circle.Radius * 2.0;
        var scale = GetScale(size, size);

        return new Ellipse
        {
            Width = size * scale,
            Height = size * scale,
            Stroke = CreateBrush(StrokeColor),
            StrokeThickness = StrokeWidth,
            Fill = Brushes.Transparent
        };
    }

    private static Rectangle CreateSquare(ISquare square)
    {
        var size = square.Side;
        var scale = GetScale(size, size);

        return new Rectangle
        {
            Width = size * scale,
            Height = size * scale,
            Stroke = CreateBrush(StrokeColor),
            StrokeThickness = StrokeWidth,
            Fill = Brushes.Transparent
        };
    }

    private static Rectangle CreateRectangle(IRectangle rectangle)
    {
        var width = rectangle.Width;
        var height = rectangle.Height;
        var scale = GetScale(width, height);

        return new Rectangle
        {
            Width = width * scale,
            Height = height * scale,
            Stroke = CreateBrush(StrokeColor),
            StrokeThickness = StrokeWidth,
            Fill = Brushes.Transparent
        };
    }

    private static Polygon CreateTriangle(ITriangle triangle)
    {
        var a = triangle.SideA;
        var b = triangle.SideB;
        var c = triangle.SideC;

        var x = (b * b + a * a - c * c) / (2.0 * a);
        var y = Math.Sqrt(Math.Max(0.0, b * b - x * x));

        var minX = Math.Min(0.0, Math.Min(a, x));
        var maxX = Math.Max(0.0, Math.Max(a, x));
        var minY = -y;
        var maxY = 0.0;

        var width = maxX - minX;
        var height = maxY - minY;
        var scale = GetScale(width, height);

        return new Polygon
        {
            Stroke = CreateBrush(StrokeColor),
            StrokeThickness = StrokeWidth,
            Fill = Brushes.Transparent,
            Points = new PointCollection
            {
                new Point((0.0 - minX) * scale, (0.0 - minY) * scale),
                new Point((a - minX) * scale, (0.0 - minY) * scale),
                new Point((x - minX) * scale, (-y - minY) * scale)
            }
        };
    }

    private static double GetScale(double width, double height)
    {
        var maxSide = Math.Max(width, height);

        if (maxSide <= 0.0)
        {
            return 1.0;
        }

        if (maxSide > MaxDisplaySize)
        {
            return MaxDisplaySize / maxSide;
        }

        if (maxSide < MinDisplaySize)
        {
            return MinDisplaySize / maxSide;
        }

        return 1.0;
    }

    private static SolidColorBrush CreateBrush(System.Drawing.Color color) =>
        new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
}