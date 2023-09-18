using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces;
using APIProdutos.Domain.Interfaces.Repositories;
using APIProdutos.Domain.Interfaces.Services;

namespace APIProdutos.Application.Services
{
	public class ProdutoService : IProdutoService
	{
		private IProdutoRepository _repository { get; set; }

		public ProdutoService(IProdutoRepository repository) => _repository = repository;

		public bool Add(Produto entity)
		{
			Console.WriteLine("COUNT: " + GetAll().Count);
			entity.SetNextID(GetAll().Select(e => e as IIdentifiable).ToList());
			entity.UpdateDataCadastro();
			return _repository.Add(entity);
		}

		public Produto Get(int id)
		{
			return _repository.Get(id);
		}

		public IList<Produto> GetAll()
		{
			return _repository.GetAll();
		}

		public IList<Produto> GetAtivos()
		{
			return _repository.GetAll().Where(p => p.Ativo).ToList();
		}

		public IList<Produto> GetProdutosComEstoque()
		{
			return _repository.GetAll().Where(p => p.QuantidadeEstoque > 0).ToList();
		}

		public bool Remove(int id)
		{
			return _repository.Remove(id);
		}

		public bool Update(int id, Produto entity)
		{
			return _repository.Update(id, entity);
		}
	}
}
