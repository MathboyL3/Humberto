using APIProdutos.Domain.Interfaces;

namespace APIProdutos.Domain.Entities
{
	public class Produto : EntityBase
	{

		#region Constructors
		private Produto() { }

		public Produto(int ID, string Nome, string Descricao, decimal Preco, int QuantidadeEstoque, bool Ativo)
		{
			this.ID = ID;
			this.Nome = Nome;
			this.Descricao = Descricao;
			this.Preco = Preco;
			this.QuantidadeEstoque = QuantidadeEstoque;
			DataCadastro = DateTime.Now;
			this.Ativo = Ativo;
		}

		#endregion

		#region Properties
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

		public void UpdateDataCadastro() => DataCadastro = DateTime.Now;

		#endregion
	}
}
