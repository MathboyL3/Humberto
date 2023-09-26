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
		public string Nome { get; set; }

		public EnderecoViewModel Endereco { get; set; }

		[Range(0, 15)]
		public int Idade { get; set; }

		[CustomStringLegthValidation(0, 500)]
		public string Conteudo { get; set; }

	}
}
