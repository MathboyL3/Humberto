using Revisao1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao1.Domain.Interfaces
{
	public interface IService<T>
	{
		
		public bool AddJogo(T jogo);
		public IList<Jogo> GetJogos();
	}
}
