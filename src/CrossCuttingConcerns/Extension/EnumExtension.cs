using System.ComponentModel;
using System.Reflection;

namespace CrossCuttingConcerns.Extension;

public static class EnumExtension
{
    /// <summary>
    /// Returns a value of DescriptionAttribute.
    /// </summary>
    public static string? GetDescription(this Enum value)
    {
        return value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DescriptionAttribute>()
            ?.Description;
    }
}