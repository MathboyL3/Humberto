using APIProdutos.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace APIProdutos.Domain.Entities
{
	public class Fornecedor : EntityBase
	{
		#region Constructors
		private Fornecedor() { }
		public Fornecedor(int ID, string Nome, string EmailContato, string CNPJ, string RazaoSocial, bool Ativo)
		{
			this.ID = ID;
			this.Ativo = Ativo;
			this.Nome = Nome;
			this.EmailContato = EmailContato;
			this.CNPJ = CNPJ;
			this.RazaoSocial = RazaoSocial;
			DataCadastro = DateTime.Now;
		}
		#endregion

		#region Properties
		public string Nome { get; private set; }
		public string RazaoSocial { get; private set; }
		public string CNPJ { get; private set; }
		public bool Ativo { get; private set; }
		public string EmailContato { get; private set; }
		public DateTime DataCadastro { get; private set; }
		#endregion

		#region Methods
		public void Ativar() => Ativo = true;
		public void Desativar() => Ativo = false;
		public void UpdateDataCadastro() => DataCadastro = DateTime.Now;
		#endregion
	}
}
