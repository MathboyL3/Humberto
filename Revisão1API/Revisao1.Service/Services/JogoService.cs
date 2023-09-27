using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces;
using Revisao1.Domain.Interfaces.Repositories;
using Revisao1.Domain.Interfaces.Services;

namespace Revisao1.Application.Services
{
    public class JogoService : IJogoService
	{
		IJogoRepository _repository { get; set; }

		public JogoService(IJogoRepository repository) {
			_repository = repository;
		}


		public bool Add(Jogo jogo)
		{
			if (!jogo.IsNumerosValidos()) return false;
			jogo.UpdateNextID(GetAll());
			jogo.RegisterTimeNow();
			_repository.Add(jogo);
			return true;
		}

		public IList<Jogo> GetAll()
		{
			return _repository.GetAll();
		}

		public IList<Jogo> GetJogosOfCPF(string CPF) {
			return _repository.GetJogosOfCPF(CPF);

		}
		public Jogo GetByID(int id)
		{
			return _repository.GetByID(id);
		}
	}
}
