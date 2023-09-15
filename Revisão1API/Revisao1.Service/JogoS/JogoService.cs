using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces;


namespace Revisao1.Service.JogoS
{
	public class JogoService : IService<Jogo>
	{
		IRepository<Jogo> _repository { get; set; }

		public JogoService(IRepository<Jogo> repository) {
			_repository = repository;
		}


		public bool AddJogo(Jogo jogo)
		{
			if (!jogo.IsNumerosValidos()) return false;
			_repository.Add(jogo);
			return true;
		}

		public IList<Jogo> GetJogos()
		{
			return _repository.GetAll();
		}
	}
}
