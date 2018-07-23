using FindU.Application.Components;
using System;
using System.Collections.Generic;

namespace FindU.Application.DataAnnotations
{
	[AttributeUsage(AttributeTargets.Property)]
	public class MinCheckedAttribute : CustomValidationAttribute
	{
		public int MinCheckedFields { get; set; }

		public MinCheckedAttribute(int minCheckedFields)
		{
			MinCheckedFields = minCheckedFields;
		}

		public override bool IsValid(object value)
		{
			if (value == null) return true;
			if (!(value is IEnumerable<CheckBoxListItem>)) return false;

			var checkBoxList = (IList<CheckBoxListItem>)value;

			return checkBoxList.Count >= MinCheckedFields;
		}
	}
}
