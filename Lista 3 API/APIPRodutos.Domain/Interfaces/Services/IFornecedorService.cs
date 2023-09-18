using APIProdutos.Domain.Entities;

namespace APIProdutos.Domain.Interfaces.Services
{
	public interface IFornecedorService : IServiceBase<Fornecedor>
	{
		public IList<Fornecedor> GetFornecedoresCadastradosAntesDe(DateTime antes);
		public IList<Fornecedor> GetFornecedoresCadastradosDepoisDe(DateTime depois);
	}
}
