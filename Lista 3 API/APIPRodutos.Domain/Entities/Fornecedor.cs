using APIProdutos.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace APIProdutos.Domain.Entities
{
	public class Fornecedor : IIdentifiable
	{
		#region Constructors
		private Fornecedor() { }
		public Fornecedor(string Nome, string EmailContato, string CNPJ, string RazaoSocial, bool Ativo)
			: this(Nome, EmailContato, CNPJ, RazaoSocial)
		{
			this.Ativo = Ativo;
		}
		public Fornecedor(string Nome, string EmailContato, string CNPJ, string RazaoSocial) {
			this.Nome = Nome;
			this.EmailContato = EmailContato;
			this.CNPJ = CNPJ;
			this.RazaoSocial = RazaoSocial;
			DataCadastro = DateTime.Now;
		}
		#endregion

		#region Properties
		public int ID { get; private set; }
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
		public int SetNextID(IList<IIdentifiable> fornecedores) => (ID = fornecedores.Count > 0 ? fornecedores.Max(f => f.ID) + 1 : 0);
		public void UpdateDataCadastro() => DataCadastro = DateTime.Now;
		#endregion
	}
}
