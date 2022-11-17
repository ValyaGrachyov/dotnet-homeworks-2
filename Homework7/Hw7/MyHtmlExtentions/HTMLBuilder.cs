using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hw7.MyHtmlExtentions
{
    public static class HTMLBuilder
    {
        public static string CreateForm(PropertyInfo property)
        {
            var name = property.Name;
            var type = property.PropertyType;
            var displayAttribute = property.GetCustomAttribute<DisplayAttribute>();
            var labelContent = ChangeLabelContext(property.Name, displayAttribute);

            if (type.IsEnum)
            {
                var enumNames = type.GetEnumNames();
                var selectTag = $"<select>{string.Join("", enumNames.Select(el => $"<option value=\"{el}\">{el}</option>").ToArray())}</select>";

                return $"{CreateLabel($"{name}", labelContent)}<br>{selectTag}<br>";
            }

            var contentType = type == typeof(string) ? "text" : "number";

            return $"{CreateLabel($"{name}", labelContent)}<br>" +
                       $"<input id=\"{name}\" name=\"{name}\" type=\"{contentType}\">";
        }

        public static string CreateLabel(string attribute, string content) =>
        $"<label for=\"{attribute}\">{content}</label>";

        public static string ChangeLabelContext(string propertyName, DisplayAttribute? attribute)
        {
            if (attribute is null)
                return Regex.Replace(propertyName, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
            return attribute.Name;
        }
    }
}
