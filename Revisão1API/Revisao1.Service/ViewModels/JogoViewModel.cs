using System.ComponentModel.DataAnnotations;
using Revisao1.Application.Attributes;

namespace Revisao1.Application.ViewModels
{
	public class JogoViewModel
	{
		[CustomStringLength(3, 255, "O nome deve ter entre 3 e 255 caracteres.")]
		public string Nome { get; set; }
		[CPFValidation]
		public string CPF { get; set; }
		[Range(1, 60)]
		public int Numero1 { get; set; }
		[Range(1, 60)]
		public int Numero2 { get; set; }
		[Range(1, 60)]
		public int Numero3 { get; set; }
		[Range(1, 60)]
		public int Numero4 { get; set; }
		[Range(1, 60)]
		public int Numero5 { get; set; }
		[Range(1, 60)]
		public int Numero6 { get; set; }

	}
}
