using Shapes.Domain.Consts;

namespace Shapes.Domain.Models;

public class ShapeParameterDefinition
{
    public ShapeParameterDefinition(string name, string displayName)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(ValidationMessages.ParameterNameCannotBeEmpty, nameof(name));
        }

        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException(ValidationMessages.ParameterDisplayNameCannotBeEmpty, nameof(displayName));
        }

        Name = name;
        DisplayName = displayName;
    }

    public string Name { get; }

    public string DisplayName { get; }
}