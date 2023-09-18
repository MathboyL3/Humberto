using APIProdutos.Domain.Entities;

namespace APIProdutos.Domain.Interfaces.Repositories
{
	public interface ICategoriaRepository : IRepositoryBase<Categoria>
	{
		public Categoria GetCategoriaPorNome(string nome);
	}
}
