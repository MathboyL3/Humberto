using System.ComponentModel.DataAnnotations;

namespace APIProdutos.Application.ViewModel
{
	public class ProdutoViewModel
	{
		public int ID { get; set; }
		[Required]
		public string Descricao { get; set; }

		[Required]
		public string Nome { get; set; }

		[Range(0, int.MaxValue)]
		public decimal Preco { get; set; }

		[Range(0, int.MaxValue)]
		public int QuantidadeEstoque { get; set; }

		public bool Ativo { get; set; }
	}
}
