using APIProdutos.Domain.Entities;

namespace APIProdutos.Domain.Interfaces.Services
{
	public interface IProdutoService : IServiceBase<Produto>
	{
		public IList<Produto> GetProdutosComEstoque();
		public IList<Produto> GetAtivos();
	}
}
