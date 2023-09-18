using APIProdutos.Domain.Entities;

namespace APIProdutos.Domain.Interfaces.Repositories
{
	public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
	{
		public IList<Fornecedor> GetFornecedoresCadastradosAntesDe(DateTime antes);	
		public IList<Fornecedor> GetFornecedoresCadastradosDepoisDe(DateTime depois);
	}
}
