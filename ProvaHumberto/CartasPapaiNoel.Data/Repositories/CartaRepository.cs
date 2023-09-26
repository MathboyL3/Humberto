using CartasPapaiNoel.Domain.Entities;
using CartasPapaiNoel.Domain.Interfaces.Specialized;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Data.Repositories
{
	public class CartaRepository : RepositoryBase<Carta>, ICartaRepository
	{
		public CartaRepository() {
			CartasFolder = "./Data/";
			CartasPath = $"{CartasFolder}Cartas.json";
		}

		public IList<Carta> GetCartasIdadeMaiorQue(int idade)
		{
			return GetAll().Where(c => c.Idade > idade).ToList();
		}

		public IList<Carta> GetCartasIdadeMenorQue(int idade)
		{
			return GetAll().Where(c => c.Idade < idade).ToList();

		}
	}
}
