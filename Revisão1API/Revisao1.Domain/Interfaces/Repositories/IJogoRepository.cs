using Revisao1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Interfaces.Repositories
{
	public interface IJogoRepository : IRepositoryBase<Jogo>
	{
		public IList<Jogo> GetJogosOfCPF(string CPF);
	}
}
