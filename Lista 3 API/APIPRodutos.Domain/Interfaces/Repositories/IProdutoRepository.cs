using APIProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProdutos.Domain.Interfaces.Repositories
{
	public interface IProdutoRepository : IRepositoryBase<Produto>
	{
		public IList<Produto> GetProdutosComEstoque();
		public IList<Produto> GetAtivos();
	}
}
