using System.ComponentModel.DataAnnotations;

namespace APIProdutos.Application.ViewModel
{
	public class CategoriaViewModel
	{
		[Required]
		public string Descricao { get; set; }

		[Required]
		public string Nome { get; set; }
	}
}
