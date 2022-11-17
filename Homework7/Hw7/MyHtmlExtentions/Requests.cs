using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hw7.MyHtmlExtentions
{
    public static class Requests
    {
        public static IHtmlContent GetReq(PropertyInfo[] properties)
        {
            var builder = new HtmlContentBuilder();

            foreach (var property in properties)
                builder.AppendHtmlLine($"<div>{HTMLBuilder.CreateForm(property)}<br></div>");

            return builder;
        }

        public static IHtmlContent PostReq(PropertyInfo[] properties, object? model)
        {
            var builder = new HtmlContentBuilder();

            foreach (var property in properties)
            {
                var validationAttributes = property.GetCustomAttributes<ValidationAttribute>();
                var propertyValue = property.GetValue(model);

                builder.AppendHtmlLine($"<div>{HTMLBuilder.CreateForm(property)}");

                foreach (var validationAttribute in validationAttributes)
                {
                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        builder.AppendHtmlLine(
                            $"{HTMLBuilder.CreateLabel($"{property.Name}", string.Empty)}" +
                            $"<span>{validationAttribute.ErrorMessage}</span>");
                    }
                }

                builder.AppendHtmlLine("<br></div>");
            }

            return builder;
        }


        
    }
}
