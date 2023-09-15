using System.ComponentModel.DataAnnotations;
namespace Revisao1.Attributes
{
	public class CustomStringLengthAttribute : ValidationAttribute
	{
		private int _maxLength {  get; set; }
		private int _minLength {  get; set; }
		public CustomStringLengthAttribute(int minLength, int maxLength, string errorMessage = "Tamanho da string fora do padrão.") 
		{
			_maxLength = maxLength;
			_minLength = minLength;
			ErrorMessage = errorMessage;
		}

		public override bool IsValid(object? value)
		{
			string str = value as string;

			if (str == null) return false;

			if (str.Length < _minLength || str.Length > _maxLength) return false;

			return true;

			
		}
	}
}
