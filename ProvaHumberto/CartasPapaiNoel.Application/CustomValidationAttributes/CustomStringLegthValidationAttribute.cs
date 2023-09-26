using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.CustomValidationAttributes
{
	public class CustomStringLegthValidationAttribute : ValidationAttribute
	{
		int max;
		int min;
		public CustomStringLegthValidationAttribute(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		public override bool IsValid(object? value)
		{
			string v = (string)value;

			return v.Length <= max && v.Length >= min;
		}
	}
}
