namespace Shapes.Domain.Consts;

public static class ValidationMessages
{
    public const string RadiusMustBePositive = "Радиус должен быть > 0";

    public const string SideMustBePositive = "Сторона должна быть > 0";

    public const string WidthMustBePositive = "Ширина должна быть > 0";

    public const string HeightMustBePositive = "Высота должна быть > 0";

    public const string TriangleSideMustBePositive = "Сторона  должна быть > 0";

    public const string TriangleInequalityViolated = "Сумма двух сторон треугольника должна быть больше третьей стороны";

    public const string ParameterNameCannotBeEmpty = "Имя параметра не может быть пустым";

    public const string ParameterDisplayNameCannotBeEmpty = "Отображаемое имя параметра не может быть пустым";

    public const string ShapeTypeNotSupported = "Тип фигуры не поддерживается";
}