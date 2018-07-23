using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindU.Application.DataAnnotations
{
	public abstract class CustomValidationAttribute : ValidationAttribute
	{
		protected CustomValidationAttribute()
		{

		}

		protected CustomValidationAttribute(string errorMessage)
			: base(errorMessage)
		{
		}

		protected void MergeAttribute(IDictionary<string, string> attributes, string key, string value)
		{
			if (attributes.ContainsKey(key))
			{
				return;
			}

			attributes.Add(key, value);
		}

		protected string GetPropertyName(ClientModelValidationContext context)
		{
			var charIndex = context.Attributes["name"].IndexOf('[');
			var propertyName = charIndex > -1
				? context.Attributes["name"].Substring(0, charIndex)
				: string.Empty;

			return propertyName;
		}
	}
}
