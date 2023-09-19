using APIProdutos.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace APIProdutos.Domain.Entities
{
	public class Categoria : EntityBase
	{
		#region Constructors
		private Categoria() { }
		public Categoria(string Nome, string Descricao)
		{
			this.Nome = Nome;
			this.Descricao = Descricao;
		}
		#endregion

		#region Properties
		public string Descricao { get; private set; }
		public string Nome { get; private set; }
		#endregion

		#region Methods
		public bool IsValid() => string.IsNullOrEmpty(Descricao) || string.IsNullOrEmpty(Nome);
		#endregion
	}
}
