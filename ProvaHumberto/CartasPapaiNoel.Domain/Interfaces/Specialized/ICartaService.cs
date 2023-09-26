using CartasPapaiNoel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Domain.Interfaces.Specialized
{
	public interface ICartaService : IServiceBase<Carta>
	{
		public IList<Carta> GetCartasIdadeMaiorQue(int idade);
		public IList<Carta> GetCartasIdadeMenorQue(int idade);
	}
}
