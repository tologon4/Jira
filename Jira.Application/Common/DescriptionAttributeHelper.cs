using System.ComponentModel;

namespace Jira.Application.Common;

/// <summary>
/// Description Attribute extension
/// </summary>
public static class DescriptionAttributeHelper
{
    public static string GetDisplayName<T>(this T source)
    {
        if (source != null)
        {
            var type = source.GetType();
            if (!type.IsEnum) return string.Empty;
            var fi = type.GetField(source.ToString() ?? string.Empty);
            if (fi == null) return string.Empty;
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            
            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
        return string.Empty;
    }
}