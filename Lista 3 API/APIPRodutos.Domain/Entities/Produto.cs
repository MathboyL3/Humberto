using APIProdutos.Domain.Interfaces;

namespace APIProdutos.Domain.Entities
{
	public class Produto : IIdentifiable
	{
		private Produto() { }
		#region Constructors
		public Produto(string Nome, string Descricao, decimal Preco, int QuantidadeEstoque, bool Ativo) 
		:this (Nome, Descricao, Preco, QuantidadeEstoque)
		{
			this.Ativo = Ativo;
		}

		public Produto(string Nome, string Descricao, decimal Preco, int QuantidadeEstoque)
		{
			this.Nome = Nome;
			this.Descricao = Descricao;
			this.Preco = Preco;
			this.QuantidadeEstoque = QuantidadeEstoque;
			DataCadastro = DateTime.Now;
		}
		#endregion

		#region Properties
		public int ID { get; private set; }
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
		public int SetNextID(IList<IIdentifiable> produtos) => (ID = produtos.Count > 0 ? produtos.Max(p => p.ID) + 1 : 0);
		public void UpdateDataCadastro() => DataCadastro = DateTime.Now;
		#endregion
	}
}
