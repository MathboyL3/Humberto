using CartasPapaiNoel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasPapaiNoel.Domain.Interfaces.Specialized
{
	public interface ICartaRepository : IRepositoryBase<Carta>
	{
		public Carta GetCartasIdadeMaiorQue(int idade);
		public Carta GetCartasIdadeMenorQue(int idade);
	}
}
