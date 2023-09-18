using APIProdutos.Domain.Entities;
using APIProdutos.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProdutos.Data.Repositories
{
	public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
	{
		public override string db_path { get; protected set; } = @".\Data Base\Fornecedores.json";

		public IList<Fornecedor> GetFornecedoresCadastradosAntesDe(DateTime antes)
		{
			return GetAll().Where(f => f.DataCadastro < antes).ToList();
		}

		public IList<Fornecedor> GetFornecedoresCadastradosDepoisDe(DateTime depois)
		{
			return GetAll().Where(f => f.DataCadastro > depois).ToList();
		}
	}
}
