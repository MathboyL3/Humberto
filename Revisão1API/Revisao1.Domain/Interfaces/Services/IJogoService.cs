using Revisao1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Interfaces.Services
{
	public interface IJogoService : IServiceBase<Jogo>
	{
		public IList<Jogo> GetJogosOfCPF(string CPF);
	}
}
