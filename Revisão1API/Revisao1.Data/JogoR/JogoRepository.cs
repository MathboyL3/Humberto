using Revisao1.Domain.Entities;
using Revisao1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace Revisao1.Data.JogoR
{
	public class JogoRepository : IRepository<Jogo>
	{
		private const string path = "./jogos.json";

		public bool Add(Jogo jogo)
		{
			if(!File.Exists(path))
				File.Create(path).Close();

			IList<Jogo> jogos = GetAll();

			jogo.ID = GetNextID();
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

		public int GetNextID()
		{
			IList<Jogo> list = GetAll();
			return list.Count > 0 ? list.Max(x => x.ID) : 0;
		}
	}
}
