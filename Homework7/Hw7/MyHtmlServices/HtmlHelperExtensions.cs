using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hw7.MyHtmlServices;

public static class HtmlHelperExtensions
{
    public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
    {
        var model = helper.ViewData.Model;
        var properties = helper.ViewData.ModelMetadata.ModelType.GetProperties();
        if (model is null)
            return GetReq(properties);
        return PostReq(properties, model);
    }

    private static IHtmlContent PostReq(PropertyInfo[] properties, object? model)
    {
        var builder = new HtmlContentBuilder();

        foreach (var property in properties)
        {
            var validationAttributes = property.GetCustomAttributes<ValidationAttribute>();
            var propertyValue = property.GetValue(model);

            builder.AppendHtmlLine($"<div>{CreateForm(property)}");

            foreach (var validationAttribute in validationAttributes)
            {
                if (!validationAttribute.IsValid(propertyValue))
                {
                    builder.AppendHtmlLine(
                        $"{CreateLabel($"{property.Name}", string.Empty)}" +
                        $"<span>{validationAttribute.ErrorMessage}</span>");
                }
            }

            builder.AppendHtmlLine("<br></div>");
        }

        return builder;
    }


    private static IHtmlContent GetReq(PropertyInfo[] properties)
    {
        var builder = new HtmlContentBuilder();

        foreach (var property in properties)
            builder.AppendHtmlLine($"<div>{CreateForm(property)}<br></div>");

        return builder;
    }

    private static string CreateForm(PropertyInfo property)
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

    private static string CreateLabel(string attribute, string content) =>
        $"<label for=\"{attribute}\">{content}</label>";

    private static string ChangeLabelContext(string propertyName, DisplayAttribute? attribute)
    {
        if (attribute is null)
            return Regex.Replace(propertyName, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        return attribute.Name;
    }
}
