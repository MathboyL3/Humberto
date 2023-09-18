using APIProdutos.Domain.Interfaces;

namespace APIProdutos.Domain.Entities
{
	public class Produto : IIdentifiable
	{

		#region Constructors
		private Produto() { }

		public Produto(string Nome, string Descricao, decimal Preco, int QuantidadeEstoque, bool Ativo)
		{
			this.Nome = Nome;
			this.Descricao = Descricao;
			this.Preco = Preco;
			this.QuantidadeEstoque = QuantidadeEstoque;
			DataCadastro = DateTime.Now;
			this.Ativo = Ativo;
		}
		#endregion

		#region Properties
		public int ID { get; private set;  }
		public string Descricao { get; private set; }
		public string Nome { get; private set; }
		public decimal Preco { get; private set; }
		public int QuantidadeEstoque { get; private set; }
		public bool Ativo { get; private set; }
		public DateTime DataCadastro { get; private set; }
		#endregion

		#region Methods
		public void Ativar() => Ativo = true;
		public void Desativar() => Ativo = false;
		public bool TemEstoque() => QuantidadeEstoque > 0;
		public bool TemEstoqueSuficiente(int quantidade_para_tirar) => QuantidadeEstoque >= quantidade_para_tirar;
		public int SetNextID(IList<IIdentifiable> produtos)
		{
			ID = 90;
			Console.WriteLine(GetID());
			return 100;
		}
		public void UpdateDataCadastro() => DataCadastro = DateTime.Now;
		public int GetID() => (this as IIdentifiable).ID;
		#endregion
	}
}
