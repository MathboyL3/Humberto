using APIProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProdutos.Domain.Interfaces.Services
{
	public interface ICategoriaService : IServiceBase<Categoria>
	{
		public Categoria GetCategoriaPorNome(string nome);
	}
}
