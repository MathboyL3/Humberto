using CartasPapaiNoel.Application.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Application.ViewModels
{
	public class CartaViewModel
	{

		[CustomStringLegthValidation(3, 255)]
		[Required]
		public string Nome { get; set; }

		[Required]
		public EnderecoViewModel Endereco { get; set; }

		[Range(0, 15)]
		[Required]
		public int Idade { get; set; }

		[CustomStringLegthValidation(0, 500)]
		[Required]
		public string Conteudo { get; set; }

	}
}
