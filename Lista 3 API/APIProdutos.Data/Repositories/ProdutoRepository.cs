using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIProdutos.Data.Repositories
{
	public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
	{
		public override string db_path { get; protected set; } = @".\Data Base\Produtos.json";

		public IList<Produto> GetAtivos()
		{
			return GetAll().Where(p => p.Ativo).ToList();
		}

		public IList<Produto> GetProdutosComEstoque()
		{
			return GetAll().Where(p => p.TemEstoque()).ToList();
		}
	}
}
