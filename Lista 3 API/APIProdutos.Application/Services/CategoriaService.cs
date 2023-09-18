using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces.Repositories;
using APIProdutos.Domain.Interfaces.Services;

namespace APIProdutos.Application.Services
{
	public class CategoriaService : ICategoriaService
	{
		private ICategoriaRepository _repository { get; set; }

		public CategoriaService(ICategoriaRepository repository) => _repository = repository;

		public bool Add(Categoria entity)
		{
			return _repository.Add(entity);
		}

		public Categoria Get(int id)
		{
			return _repository.Get(id);
		}

		public IList<Categoria> GetAll()
		{
			return _repository.GetAll();
		}

		public Categoria GetCategoriaPorNome(string nome)
		{
			return _repository.GetCategoriaPorNome(nome);
		}

		public bool Remove(int id)
		{
			return _repository.Remove(id);
		}

		public bool Update(int id, Categoria entity)
		{
			return _repository.Update(id, entity);
		}
	}
}
