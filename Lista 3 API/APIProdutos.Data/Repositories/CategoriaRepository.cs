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
	public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
	{
		public override string db_path { get; protected set; } = @".\Data Base\Categorias.json";

		public Categoria? GetCategoriaPorNome(string nome)
		{
			return GetAll().FirstOrDefault(c => c.Nome.ToLower().Equals(nome.ToLower()));
		}
	}
}
