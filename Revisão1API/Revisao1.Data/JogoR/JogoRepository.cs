using Newtonsoft.Json;
using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces.Repositories;

namespace Revisao1.Data.JogoR
{
	public class JogoRepository : IJogoRepository
	{
		private const string path = "./Jogos DB/jogos.json";

		public bool Add(Jogo jogo)
		{
			if(!File.Exists(path))
				File.Create(path).Close();

			IList<Jogo> jogos = GetAll();

			jogo.UpdateNextID(jogos);
			jogo.RegisterTimeNow();

			jogos.Add(jogo);
			File.WriteAllText(path, JsonConvert.SerializeObject(jogos));
			return true;
		}

		public Jogo Get(int id)
		{
			IList<Jogo> jogos = GetAll();

			if (jogos == null)
				return null;

			foreach(var jogo in jogos)
				if (jogo.ID.Equals(id))
					return jogo;
			
			return null;
		}

		public IList<Jogo> GetAll()
		{
			if (!File.Exists(path)) 
				return new List<Jogo>();

			string content = File.ReadAllText(path);

			IList<Jogo> list = JsonConvert.DeserializeObject<IList<Jogo>>(content);
			
			return list == null ? new List<Jogo>() : list;
		}

		public IList<Jogo> GetJogosOfCPF(string CPF)
		{
			return GetAll().Where(j => j.CPF.Equals(CPF)).ToList();
		}
	}
}
