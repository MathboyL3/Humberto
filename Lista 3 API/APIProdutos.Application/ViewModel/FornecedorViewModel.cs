using APIProdutos.Application.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace APIProdutos.Application.ViewModel
{
	public class FornecedorViewModel
	{
		[Required]
		public string Nome { get; set; }

		[Required]
		public string RazaoSocial { get; set; }

		[Required]
		[CNPJValidadtion]
		public string CNPJ { get; set; }

		[Required]
		[EmailAddress]
		public string EmailContato { get; set; }

		public bool Ativo { get; set; }

	}
}
