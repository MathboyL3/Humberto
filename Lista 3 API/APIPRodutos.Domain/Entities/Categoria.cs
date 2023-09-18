using APIProdutos.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace APIProdutos.Domain.Entities
{
	public class Categoria : IIdentifiable
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
		public int ID { get; private set; }
		public string Descricao { get; private set; }
		public string Nome { get; private set; }
		#endregion

		#region Methods
		public bool IsValid() => string.IsNullOrEmpty(Descricao) || string.IsNullOrEmpty(Nome);
		public int SetNextID(IList<IIdentifiable> categorias)
		{
			ID = categorias.Count > 0 ? categorias.Max(f => f.ID) + 1 : 0;
			return ID;
		}
		#endregion
	}
}
