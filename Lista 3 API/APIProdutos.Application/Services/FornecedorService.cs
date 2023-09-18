using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces;
using APIProdutos.Domain.Interfaces.Repositories;
using APIProdutos.Domain.Interfaces.Services;

namespace APIProdutos.Application.Services
{
	public class FornecedorService : IFornecedorService
	{
		private IFornecedorRepository _repository { get; set; }

		public FornecedorService(IFornecedorRepository repository) => _repository = repository;

		public bool Add(Fornecedor entity)
		{
			entity.SetNextID(GetAll().Select(e => (IIdentifiable)e).ToList());
			entity.UpdateDataCadastro();
			return _repository.Add(entity);
		}

		public Fornecedor Get(int id)
		{
			return _repository.Get(id);
		}

		public IList<Fornecedor> GetAll()
		{
			return _repository.GetAll();
		}

		public IList<Fornecedor> GetFornecedoresCadastradosAntesDe(DateTime antes)
		{
			return _repository.GetFornecedoresCadastradosAntesDe(antes);
		}

		public IList<Fornecedor> GetFornecedoresCadastradosDepoisDe(DateTime depois)
		{
			return _repository.GetFornecedoresCadastradosDepoisDe(depois);
		}

		public bool Remove(int id)
		{
			return _repository.Remove(id);
		}

		public bool Update(int id, Fornecedor entity)
		{
			return _repository.Update(id, entity);
		}
	}
}
